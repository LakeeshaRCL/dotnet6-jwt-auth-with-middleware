using AutoMapper;
using JwtAuthenticationWithMiddlewares.DTOs;
using JwtAuthenticationWithMiddlewares.DTOs.Pagination;
using JwtAuthenticationWithMiddlewares.Helpers.Pagination;
using JwtAuthenticationWithMiddlewares.Helpers.Requests.Story;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;
using JwtAuthenticationWithMiddlewares.Models;

namespace JwtAuthenticationWithMiddlewares.Services.StoryService
{
    public class StoryService : IStoryService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly QueryPaginator queryPaginator;

        public StoryService(ApplicationDbContext dbContext, IMapper mapper, QueryPaginator queryPaginator)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.queryPaginator = queryPaginator;
        }

        /// <summary>
        /// Example description
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BaseResponse AddStory(AddStoryRequest request)
        {
            try
            {

                UserModel? requestedUser = dbContext.User.Where(u => u.id == request.user_id).FirstOrDefault();

                // check requested user is available
                if(requestedUser == null)
                {
                    return new BaseResponse { status_code = StatusCodes.Status400BadRequest, data = new MessageDTO("No user found for the given user id") };
                }

                StoryModel newStory = new StoryModel();
                newStory.title = request.title;
                newStory.description = request.description;
                newStory.user_id = request.user_id;

                dbContext.Story.Add(newStory);
                dbContext.SaveChanges();

                return new BaseResponse { status_code = StatusCodes.Status200OK, data = new MessageDTO("Sotry added successfully") };

            }
            catch (Exception ex)
            {
                return new BaseResponse { status_code = StatusCodes.Status500InternalServerError, data = new MessageDTO(ex.Message) };
            }
        }



        public BaseResponse AddStories()
        {
            try
            {
                int recordCount = 150;

                for (int i=0; i < recordCount; i++)
                {
                    StoryModel newStory = new StoryModel();
                    newStory.title = String.Concat("Title", (i+1));
                    newStory.description = String.Concat("Sample description for ", (i + 1));
                    newStory.user_id = 1;

                    dbContext.Story.Add(newStory);
                    dbContext.SaveChanges();
                }

                
                return new BaseResponse { status_code = StatusCodes.Status200OK, data = new MessageDTO("Sotry added successfully") };

            }
            catch (Exception ex)
            {
                return new BaseResponse { status_code = StatusCodes.Status500InternalServerError, data = new MessageDTO(ex.Message) };
            }
        }



        public BaseResponse GetAll(GetStoriesRequest request)
        {
            try
            {

                BaseResponse response;
                var query = dbContext.Story.AsEnumerable().Join(dbContext.User.ToList(), story => story.user_id, user => user.id, (s, u) => new { story = s, user = u })
                    .Select(su => new StoryUserDTO
                    {
                        id = su.story.id,
                        author_id = su.user.id,
                        description = su.story.description,
                        title = su.story.title,
                        author_name = new UserNameDTO { first_name = su.user.first_name, last_name = su.user.last_name }
                    });

                // get paginated data
                PaginationMetaDataDTO<List<StoryUserDTO>> paginatedData = queryPaginator.GetPaginatedData(query, request.page_number);

                response = new BaseResponse { status_code = StatusCodes.Status200OK, data = new { stories = paginatedData } };

                return response;

            }
            catch (Exception ex)
            {
                return new BaseResponse { status_code = StatusCodes.Status500InternalServerError, data = new MessageDTO(ex.Message) };
            }
        }
    }
}

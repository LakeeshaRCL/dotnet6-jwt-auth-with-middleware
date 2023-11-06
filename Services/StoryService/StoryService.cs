using AutoMapper;
using JwtAuthenticationWithMiddlewares.DTOs;
using JwtAuthenticationWithMiddlewares.Helpers.Requests.Story;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;
using JwtAuthenticationWithMiddlewares.Models;

namespace JwtAuthenticationWithMiddlewares.Services.StoryService
{
    public class StoryService : IStoryService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public StoryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


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


        public BaseResponse GetAll()
        {
            try
            {
                List<StoryDTO> storyDTOs = new List<StoryDTO>();

                // get stories from the database
                List<StoryModel> stories = dbContext.Story.ToList();

                // map models to DTOs
                foreach (StoryModel story in stories)
                {
                    storyDTOs.Add(mapper.Map<StoryDTO>(story));
                }

                return new BaseResponse { status_code = StatusCodes.Status200OK, data = new { stories = storyDTOs} };

            }
            catch (Exception ex)
            {
                return new BaseResponse { status_code = StatusCodes.Status500InternalServerError, data = new MessageDTO(ex.Message) };
            }
        }
    }
}

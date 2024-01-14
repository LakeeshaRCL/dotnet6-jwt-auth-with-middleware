using JwtAuthenticationWithMiddlewares.Helpers.Requests.Story;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;

namespace JwtAuthenticationWithMiddlewares.Services.StoryService
{
    public interface IStoryService
    {
        BaseResponse AddStory(AddStoryRequest request);
        BaseResponse AddStories();

        /// <summary>
        /// Example description
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BaseResponse GetAll(GetStoriesRequest request);
    }
}

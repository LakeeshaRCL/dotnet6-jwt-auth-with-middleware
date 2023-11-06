using JwtAuthenticationWithMiddlewares.Helpers.Requests.Story;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;

namespace JwtAuthenticationWithMiddlewares.Services.StoryService
{
    public interface IStoryService
    {
       BaseResponse AddStory(AddStoryRequest request);

       BaseResponse GetAll();
    }
}

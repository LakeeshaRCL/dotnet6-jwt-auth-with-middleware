using JwtAuthenticationWithMiddlewares.Helpers.Requests.Story;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;
using JwtAuthenticationWithMiddlewares.Services.StoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationWithMiddlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService storyService;

        public StoryController(IStoryService storyService)
        {
            this.storyService = storyService;
        }



        [HttpPost("addStory")]
        public BaseResponse AddStory(AddStoryRequest request)
        {
            return storyService.AddStory(request);
        }


        [HttpGet("getAll")]
        public BaseResponse GetAll()
        {
            return storyService.GetAll();
        }

    }
}

using JwtAuthenticationWithMiddlewares.Attributes;

namespace JwtAuthenticationWithMiddlewares.Helpers.Requests.Story
{
    public class GetStoriesRequest
    {

        [PositiveNumberValidation]
        public int page_number { get; set; } = 1;
    }
}

using System.ComponentModel.DataAnnotations;

namespace JwtAuthenticationWithMiddlewares.Helpers.Requests.Story
{
    public class AddStoryRequest
    {
        [Required]
        public long user_id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

    }
}

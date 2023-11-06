using System.Diagnostics.Eventing.Reader;

namespace JwtAuthenticationWithMiddlewares.DTOs
{
    public class StoryDTO
    {
        public long id { get; set; }

        public long user_id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthenticationWithMiddlewares.Models
{
    [Table("story")]
    public class StoryModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long user_id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
    }
}

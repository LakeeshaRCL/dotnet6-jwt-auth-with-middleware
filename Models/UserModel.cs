using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuthenticationWithMiddlewares.Models
{
    [Table("user")]
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string first_name { get; set; }  

        public string last_name { get; set;}

        public string username { get; set;}

        public string email { get; set; }

        public string password { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime created_at { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set;}


    }
}

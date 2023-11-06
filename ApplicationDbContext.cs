using JwtAuthenticationWithMiddlewares.Helpers.Utils.GlobalAttributes;
using JwtAuthenticationWithMiddlewares.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthenticationWithMiddlewares
{
    public class ApplicationDbContext: DbContext
    {

        // constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
        {
        }

        public ApplicationDbContext()
        {
             // default constructor   
        }


        // declare models

        public virtual DbSet<UserModel> User { get; set; }
        public virtual DbSet<LoginDetailModel> LoginDetails { get; set; }
        public virtual DbSet<StoryModel> Story { get; set; }



        // MySQL configuration to use with default ApplicationDbContext constructor if not configured
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(GlobalAttributes.mysqlConfiguration.connectionString, ServerVersion.AutoDetect(GlobalAttributes.mysqlConfiguration.connectionString));
            }
        }
    }
}

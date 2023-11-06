namespace JwtAuthenticationWithMiddlewares.Helpers.Utils.GlobalAttributes
{
    public static class GlobalAttributes
    {
        public static MySQLConfiguration mysqlConfiguration = new MySQLConfiguration(); 
    }


    public class MySQLConfiguration
    {
        public string connectionString { get; set; } 
    }
}

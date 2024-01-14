namespace JwtAuthenticationWithMiddlewares.Helpers.Exceptions.Pagination
{
    public class InvalidPageNumberException : Exception
    {
        public InvalidPageNumberException() { 
        }


        public InvalidPageNumberException(string message) : base(message) { }


        public InvalidPageNumberException(string message, Exception inner) : base(message, inner) { }
    }
}

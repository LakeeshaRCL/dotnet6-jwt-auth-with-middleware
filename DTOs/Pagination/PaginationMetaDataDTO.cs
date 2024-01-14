namespace JwtAuthenticationWithMiddlewares.DTOs.Pagination
{
    public class PaginationMetaDataDTO<T>
    {
        public int page_count { get; set; } 
        public int current_page { get; set; }
        public T items { get; set; }

    }
}

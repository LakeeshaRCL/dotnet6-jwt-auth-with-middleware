using JwtAuthenticationWithMiddlewares.DTOs.Pagination;
using JwtAuthenticationWithMiddlewares.Helpers.Exceptions.Pagination;

namespace JwtAuthenticationWithMiddlewares.Helpers.Pagination
{
    public class QueryPaginator
    {

        public QueryPaginator()
        {

        }


        /// <summary>
        /// Returns paginated results using given query and page number
        /// </summary>
        /// <typeparam name="T">Data Type to be return</typeparam>
        /// <param name="enumerableQuery">Enumerable database query</param>
        /// <param name="pageNumber">request page number</param>
        /// <returns>PaginationMetaDataDTO of a given return type</returns>
        /// <exception cref="InvalidPageNumberException"></exception>
        public PaginationMetaDataDTO<List<T>> GetPaginatedData<T>(IEnumerable<T> enumerableQuery, int pageNumber)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                int pageSize = 10;
                int startPosition = (pageNumber - 1) * pageSize;
                double pageCount = 0;

                // this can be loosely coupled (pass query and get count from common class)
                int recordCount = enumerableQuery.Count();

                // get page count
                pageCount = Math.Ceiling((double)recordCount / pageSize);

                // get data
                if (pageCount >= pageNumber)
                {
                    List<T> paginatedDbData = enumerableQuery.Skip(startPosition).Take(pageSize).ToList();

                    // make return dto
                    PaginationMetaDataDTO<List<T>> paginatedData = new PaginationMetaDataDTO<List<T>>
                    {
                        current_page = pageNumber,
                        page_count = (int)pageCount,
                        items = paginatedDbData
                    };

                    return paginatedData;
                }
                else
                {
                    throw new InvalidPageNumberException("Invalid Page Number");
                }

            }
        }

    }
}

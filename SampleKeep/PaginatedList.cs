namespace SampleKeep
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> item, int pageIndex, int pageSize, int count)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(item);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static PaginatedList<T> Create(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(count).ToList();
            return new PaginatedList<T>(items, pageIndex, pageSize, count);
        }
    }

    //public void Index()
    //{
    //    var pageSize = 5;
    //    return PaginatedList<string>.Create();
    //}



    //Dapper connection of storeProcedure:In summary,
    //the DapperContext class has a constructor that takes an
    //IConfiguration object as a parameter. It retrieves the connection
    //string from the configuration using the key "MiddleWareContext" and
    //stores it in the _connectionString field.
    //The class also provides a CreateConnection method that returns a new
    //instance of SqlConnection using the connection string retrieved from the
    //configuration.This method can be used to create a database connection when working with Dapper.

    //Overall, the DapperContext class serves as a helper class to manage the creation of database connections for Dapper operations within the application.
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MiddleWareContext");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
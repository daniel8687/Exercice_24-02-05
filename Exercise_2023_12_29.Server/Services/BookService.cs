using Exercise_2023_12_29.Server.Models;
using Exercise_2023_12_29.Server.Models.Interfaces;
using System.Data;

namespace Exercise_2023_12_29.Server.Services
{
    public class BookService : IBookService
    {
        private readonly IDBService _dbService;

        public BookService(IDBService dbService)
        {
            _dbService = dbService;
        }

        public IEnumerable<Book> GetBooksInfoBy(string searchBy, string searchValue)
        {
            var response = new List<Book>();
            var query =
                searchBy.ToLower().Equals("author") ? $"select * from dbo.books where first_name like '%{searchValue}%' or last_name like '%{searchValue}%'" :
                searchBy.ToLower().Equals("isbn") ? $"select * from dbo.books where isbn like '%{searchValue}%'" :
                searchBy.ToLower().Equals("category") ? $"select * from dbo.books where category like '%{searchValue}%'" :
                 $"select * from books";
            var dbResponse = _dbService.ExecuteQuery(query);
            foreach (DataRow row in dbResponse.Rows)
            {
                var model = new Book()
                {
                    BookTitle = row["title"].ToString(),
                    Publisher = "Publisher",
                    Authors = $"{row["first_name"]} {row["last_name"]}",
                    Type = row["type"].ToString(),
                    ISBN = row["isbn"].ToString(),
                    Category = row["category"].ToString(),
                    AvailableCopies = $"{row["copies_in_use"]}/{row["total_copies"]}"
                };
                response.Add(model);
            }
            return response;
        }       
    }
}
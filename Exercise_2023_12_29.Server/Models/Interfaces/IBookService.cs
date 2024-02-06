namespace Exercise_2023_12_29.Server.Models.Interfaces
{
    public interface IBookService
    {
        public IEnumerable<Book> GetBooksInfoBy(string searchBy, string searchValue);
    }
}

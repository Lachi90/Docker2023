using ExampleBackend.Model;

namespace ExampleBackend.Services;

public interface IBookService
{
    public Task<Book> CreateBookAsync(Book book);

    public Task<Book?> GetBookAsync(int id);

    public Task<Book> UpdateBookAsync(Book book);

    public Task DeleteBookAsync(int id);

    public Task<IEnumerable<Book>> GetBooksAsync();
}
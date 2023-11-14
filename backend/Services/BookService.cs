using ExampleBackend.Database;
using ExampleBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace ExampleBackend.Services;

public class BookService : IBookService
{
    private readonly ExampleContext _context;

    public BookService(ExampleContext context)
    {
        _context = context;
    }

    public async Task<Book> CreateBookAsync(Book book)
    {
        var createdBook = await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return createdBook.Entity;
    }

    public async Task<Book?> GetBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        return book;
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        var updatedBook = _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return updatedBook.Entity;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksAsync() => await _context.Books.ToListAsync();
}
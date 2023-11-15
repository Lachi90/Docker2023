using ExampleBackend.Model;
using ExampleBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleBackend.Controllers;

public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateBookAsync([FromBody] Book book)
    {
        var createdBook = await _bookService.CreateBookAsync(book);
        return Ok(createdBook);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBookAsync(int id)
    {
        var book = await _bookService.GetBookAsync(id);
        return Ok(book);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateBookAsync([FromBody] Book book)
    {
        var updatedBook = await _bookService.UpdateBookAsync(book);
        return Ok(updatedBook);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBookAsync(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetBooksAsync()
    {
        var books = await _bookService.GetBooksAsync();
        return Ok(books);
    }
}
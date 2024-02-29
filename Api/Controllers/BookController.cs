using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStorage.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Execute books query
    /// </summary>
    /// <returns>Returns a list with all books</returns>
    [HttpGet("getAll")]
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks(int pageNumber, int pageSize)
    {
        try
        {
            return Ok(await _bookService.ListAll(pageNumber, pageSize));
        }
        catch (Exception ex)
        {
            return BadRequest(new Exception(ex.Message.ToString()));
        }
    }

    /// <summary>
    /// Store a new book
    /// </summary>
    /// <returns>Realizes a new book insertion</returns>
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status201Created)]
    public async Task<IActionResult> InsertBook([FromBody] Book book)
    {
        try
        {
            await _bookService.InsertBook(book);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new Exception(ex.Message.ToString()));
        }
    }

    /// <summary>
    /// Updates an specific book
    /// </summary>
    /// <returns>Updates an specific book</returns>
    [HttpPut]
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status202Accepted)]
    public async Task<IActionResult> UpdateBook([FromBody] Book book, [FromQuery] Guid Id)
    {
        try
        {
            var BookUpdated = await _bookService.UpdateBook(Id, book);
            return Ok(BookUpdated);
        }
        catch (Exception ex)
        {
            return BadRequest(new Exception(ex.Message.ToString()));
        }
    }
    
    /// <summary>
    /// Deleta um Bookro específico
    /// </summary>
    /// <returns>Deleção de um Bookro específico</returns>
    [HttpDelete]
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteBook([FromQuery] Guid Id)
    {
        try
        {
            await _bookService.DeleteBook(Id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new Exception(ex.Message.ToString()));
        }
    }
}
using BibleWebApi.Models.DataContext;
using BibleWebApi.Models.UseCases;
using BibleWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BibleWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BibleController : ControllerBase
{
    private readonly IBibleService _service;


    public BibleController(IBibleService service)
    {
        _service = service;
    }


    [HttpPost("register/book")]
    public async Task<IActionResult> RegisterBook([FromBody] BookModel bookModel)
    {
        try
        {
            await _service.RegisterBookAsync(bookModel);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("register/verses/{bookId}/{chapterNumber}")]
    public async Task<IActionResult> RegisterVerse(
        int bookId,
        int chapterNumber,
        [FromBody] List<VerseInputModel> versesInput)
    {
        try
        {
            var verses = versesInput.Select(x => new VerseModel
            {
                BookId = bookId,
                ChapterNumber = chapterNumber,
                Number = x.Number,
                Text = x.Text,
                Title = x.Title
            });

            await _service.RegisterVersesAsync(verses);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("verse/{bookId}/{chapterNumber}")]
    public async Task<IActionResult> GetVerses(int bookId, int chapterNumber, [FromQuery] params int[] versesNumbers)
    {
        try
        {
            var result = await _service.GetVersesAsync(bookId, chapterNumber, versesNumbers);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

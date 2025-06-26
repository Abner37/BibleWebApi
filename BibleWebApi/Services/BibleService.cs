using BibleWebApi.Models.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BibleWebApi.Services;


public interface IBibleService
{
    Task RegisterBookAsync(BookModel book);
    Task RegisterVersesAsync(IEnumerable<VerseModel> verses);

    Task<IEnumerable<VerseModel>> GetVersesAsync(int bookId, int chapterNumber, params int[] versesNumbers);
}


public class BibleService : IBibleService
{
    private readonly BibleDbContext _context;


    public BibleService(BibleDbContext context)
    {
        _context = context;
    }



    public async Task RegisterBookAsync(BookModel bookModel)
    {
        await _context.Books.AddAsync(bookModel);
        await _context.SaveChangesAsync();
    }
    public async Task RegisterVersesAsync(IEnumerable<VerseModel> verses)
    {
        await _context.AddRangeAsync(verses);
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<VerseModel>> GetChapterAsync(int bookId, int chapterNumber)
    {
        var verses = _context.Verses.Where(x => x.BookId == bookId && x.Number == chapterNumber)
            .OrderBy(x => x.Number);

        if (verses.Any() == false)
            throw new Exception("Book or Chapter not found.");

        return verses;
    }

    public async Task<IEnumerable<VerseModel>> GetVersesAsync(int bookId, int chapterNumber, params int[] versesNumbers)
    {
        //var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookId)
        //    ?? throw new Exception("Book not found.");

        var verses = _context.Verses.Where(x => x.BookId == bookId && x.ChapterNumber == chapterNumber);

        if (verses.Any() == false)
            throw new Exception("Book chapter not found.");

        if (versesNumbers.Length != 0)
        {
            var versesAux = verses.Where(x => versesNumbers.Contains(x.Number));
            verses = versesAux;
        }

        //foreach (var verse in verses)
        //    verse.Book = book;

        return verses;
    }
}

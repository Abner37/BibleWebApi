namespace BibleWebApi.Models.DataContext;

public class VerseModel
{
    public int Id { get; set; }

    public int BookId { get; set; }
    public BookModel? Book { get; set; }

    public int ChapterNumber { get; set; }

    public int Number { get; set; }
    public string Text { get; set; }

    public string? Title { get; set; }



    public override string ToString()
    {
        return $"{Number}. {Text}";
    }
}

namespace BibleWebApi.Models.UseCases;


public class VerseInputModel
{
    public int Number { get; set; }
    public string Text { get; set; } = string.Empty;

    public string? Title { get; set; }
}

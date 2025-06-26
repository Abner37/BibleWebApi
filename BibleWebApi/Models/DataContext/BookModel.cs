namespace BibleWebApi.Models.DataContext;

public class BookModel
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Title { get; set; }

    public string Acronym { get; set; }
    public int Order { get; set; }

    public int ChaptersCount { get; set; }

    //public List<VerseModel>? Verses { get; set; }


    public override string ToString()
    {
        return $"{Name}";
    }
}

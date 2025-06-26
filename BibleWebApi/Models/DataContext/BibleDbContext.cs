using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BibleWebApi.Models.DataContext;

public class BibleDbContext : DbContext
{
    public DbSet<BookModel> Books { get; set; }
    public DbSet<VerseModel> Verses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=bible.db;Cache=Shared");
    }
}
﻿// <auto-generated />
using BibleWebApi.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibleWebApi.Migrations
{
    [DbContext(typeof(BibleDbContext))]
    [Migration("20250504224353_InitialCreation")]
    partial class InitialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("BibleWebApi.Models.BookModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BibleWebApi.Models.ChapterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("BibleWebApi.Models.TitleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VerseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VerseId");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("BibleWebApi.Models.VerseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChapterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Verses");
                });

            modelBuilder.Entity("BibleWebApi.Models.ChapterModel", b =>
                {
                    b.HasOne("BibleWebApi.Models.BookModel", "Book")
                        .WithMany("Chapters")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BibleWebApi.Models.TitleModel", b =>
                {
                    b.HasOne("BibleWebApi.Models.VerseModel", "Verse")
                        .WithMany()
                        .HasForeignKey("VerseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Verse");
                });

            modelBuilder.Entity("BibleWebApi.Models.VerseModel", b =>
                {
                    b.HasOne("BibleWebApi.Models.ChapterModel", "Chapter")
                        .WithMany("Verses")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("BibleWebApi.Models.BookModel", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("BibleWebApi.Models.ChapterModel", b =>
                {
                    b.Navigation("Verses");
                });
#pragma warning restore 612, 618
        }
    }
}

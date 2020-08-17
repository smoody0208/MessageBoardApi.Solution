﻿// <auto-generated />
using System;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoard.Migrations
{
    [DbContext(typeof(MessageBoardContext))]
    partial class MessageBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MessageBoard.Models.Board", b =>
                {
                    b.Property<int>("BoardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("BoardId");

                    b.ToTable("Boards");

                    b.HasData(
                        new
                        {
                            BoardId = 1,
                            Description = "General discussions about computer programming i.e., best prectices, tips-and-trick, etc...",
                            Name = "Programming"
                        },
                        new
                        {
                            BoardId = 2,
                            Description = "A place where we can share cute things our pets have done",
                            Name = "Pets"
                        },
                        new
                        {
                            BoardId = 3,
                            Description = "Trading nutrition tips, recipes, and support",
                            Name = "Diet/Nutrition"
                        },
                        new
                        {
                            BoardId = 4,
                            Description = "A friendly chat about what video games we are playing these days",
                            Name = "Video Games"
                        },
                        new
                        {
                            BoardId = 5,
                            Description = "Best places to eat around Portland",
                            Name = "Eats!"
                        });
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardId");

                    b.Property<string>("Body");

                    b.Property<DateTime>("DatePosted");

                    b.Property<string>("Heading");

                    b.HasKey("MessageId");

                    b.HasIndex("BoardId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.HasOne("MessageBoard.Models.Board", "Board")
                        .WithMany("Messages")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingList.Data;

#nullable disable

namespace ShoppingList.Migrations
{
    [DbContext(typeof(ShoppingListDbContext))]
    partial class ShoppingListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingList.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Product Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Products", t =>
                        {
                            t.HasComment("Shopping List Product");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ham"
                        });
                });

            modelBuilder.Entity("ShoppingList.Data.Models.ProductNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Note Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("Note Content");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasComment("ProductIdentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductNotes", t =>
                        {
                            t.HasComment("Product Note");
                        });
                });

            modelBuilder.Entity("ShoppingList.Data.Models.ProductNote", b =>
                {
                    b.HasOne("ShoppingList.Data.Models.Product", "Product")
                        .WithMany("ProductNotes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShoppingList.Data.Models.Product", b =>
                {
                    b.Navigation("ProductNotes");
                });
#pragma warning restore 612, 618
        }
    }
}

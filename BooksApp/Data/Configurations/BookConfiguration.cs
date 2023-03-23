using BooksApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.PublicationDate)
                .IsRequired();

            builder.Property(x => x.PageCount)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();
        }
    }
}

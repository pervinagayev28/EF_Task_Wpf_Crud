using ConsoleApp5.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(b => b.Theme)
                .WithMany(t => t.Books)
                .HasForeignKey(b => b.Id_Theme);

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.Id_Category);

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.Id_Author);

            builder.HasOne(b => b.Press)
             .WithMany(a => a.Books)
             .HasForeignKey(b => b.Id_Press);

            builder.HasMany(b => b.S_Cards)
                .WithOne(s => s.Book)
                .HasForeignKey(s => s.Id_Book);

            builder.HasMany(b => b.T_Cards)
                .WithOne(t => t.Book)
                .HasForeignKey(t => t.Id_Book);

            

        }
    }
    
}

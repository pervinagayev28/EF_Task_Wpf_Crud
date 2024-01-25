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
    public class FacultieConfiguration: IEntityTypeConfiguration<Facultie>
    {
        public void Configure(EntityTypeBuilder<Facultie> builder)
        {
            builder.HasMany(f => f.Groups)
                .WithOne(g => g.Facultie)
                .HasForeignKey(g => g.Id_Facultie);
        }
    }
}

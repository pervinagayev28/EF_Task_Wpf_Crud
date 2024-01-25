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
    public class S_CardConfiguration: IEntityTypeConfiguration<S_Card>
    {
        public void Configure(EntityTypeBuilder<S_Card> builder)
        {
            builder.HasOne(sc => sc.Student)
                .WithMany(s => s.S_Cards)
                .HasForeignKey(s=>s.Id_Student);
        }
    }
    
    
}

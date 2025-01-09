using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class AnalystAnalisysResponsibleConfiguration : IEntityTypeConfiguration<AnalystAnalisysResponsible>
    {
        public void Configure(EntityTypeBuilder<AnalystAnalisysResponsible> builder)
        {

            builder.HasOne(u => u.Analyst)
                .WithMany(s => s.AnalystAnalisys)
                .HasForeignKey(u => u.AnalystId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Analisys)
                .WithMany(s => s.ResponsibleAnalists)
                .HasForeignKey(u => u.AnalisysId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.IsMain);

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
               .IsRequired()
               .HasMaxLength(36);

            builder.Property(u => u.CreatedAt)
                .IsRequired();

            builder.Property(u => u.UpdatedAt);

            builder.Property(u => u.Deleted)
                .IsRequired();

            builder.HasOne(u => u.CreatedByUserLaboratory)
                .WithMany(x => x.AnalystAnalisysResponsiblesCreatedBy)
                .HasForeignKey(u => u.CreatedById)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.AnalystAnalisysResponsiblesUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

        }
       
    }
}

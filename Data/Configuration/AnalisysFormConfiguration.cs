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
    public class AnalisysFormConfiguration : IEntityTypeConfiguration<AnalisysForm>
    {
        public void Configure(EntityTypeBuilder<AnalisysForm> builder)
        {
            builder.HasAlternateKey(u => new { u.FormId, u.Current });
            
            builder.HasOne(u => u.Form)
                 .WithMany(s => s.AnalisysForms)
                .HasForeignKey(u => u.FormId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Analisys)
                .WithMany(s => s.AnalisysForms)
                .HasForeignKey(u => u.AnalisysId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.Current)
                .HasDefaultValue(false)
                .IsRequired();

            //Base entity Data

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
               .WithMany(x => x.AnalisysFormCreatedBy)
               .HasForeignKey(u => u.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.AnalisysFormUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data
        }
    }
}

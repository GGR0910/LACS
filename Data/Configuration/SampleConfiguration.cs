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
    public class SampleConfiguration : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
           builder.HasOne(u => u.Solicitation)
                .WithMany(s => s.Samples)
                .HasForeignKey(u => u.SolicitationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.SampleType)
                .WithMany(s => s.Samples)
                .HasForeignKey(u => u.SampleTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.SamplePhisicalState)
                .WithMany(s => s.Samples)
                .HasForeignKey(u => u.SamplePhisicalStateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.SampleAnalisysExpectedDate);
            builder.Property(u => u.SampleAnalisysDone);
            builder.Property(u => u.SampleAnalysisResult);

            builder.HasOne(u => u.Analisty)
                .WithMany(s => s.Samples)
                .HasForeignKey(u => u.AnalistyId)
                .OnDelete(DeleteBehavior.Restrict);

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

            builder.Property(u => u.CreatedBy)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(u => u.UpdatedBy)
                .HasMaxLength(36);
            //End base entity Data


        }
    }
}

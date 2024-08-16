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
    public class SolicitationConfiguration : IEntityTypeConfiguration<Solicitation>
    {
        public void Configure(EntityTypeBuilder<Solicitation> builder)
        {
            builder.HasOne(u => u.SolicitationType)
                .WithMany(s => s.Solicitations)
                .HasForeignKey(u => u.SoliciationTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.SamplesReceivedDate);
            
            builder.Property(u => u.ExpectedCompletionDate);

            builder.Property(u => u.CompletionDate);

            builder.Property(u => u.ResultsDelivered)
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
                 .WithMany(x => x.SolicitationsCreatedBy)
                 .HasForeignKey(u => u.CreatedById)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.SolicitationsUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data


        }
    }
}

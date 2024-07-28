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
            builder.HasOne(u => u.Requester)
                .WithMany(u => u.Solicitations)
                .HasForeignKey(u => u.RequesterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.SolicitationType)
                .WithMany(s => s.Solicitations)
                .HasForeignKey(u => u.SoliciationTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(builder => builder.SamplesDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(builder => builder.AnalysisGoalDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(u => u.AnalisysType)
                .WithMany(s => s.Solicitations)
                .HasForeignKey(u => u.AnalisysTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.DesiredMagnefication);

            builder.Property(u => u.NeedsRecobriment)
                .IsRequired();

            builder.Property(u => u.RecobrimentMaterial);
            
            builder.Property(u => u.SpecialPrecautions)
                .IsRequired();
            builder.Property(u => u.DesiredDeadline)
                .IsRequired();
            builder.Property(u => u.DeliveryLocation)
                .IsRequired();
            builder.Property(u => u.DesireToAccompanyAnalysis)
                .IsRequired();
            builder.Property(u => u.Observations);
            
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

            builder.Property(u => u.CreatedBy)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(u => u.UpdatedBy)
                .HasMaxLength(36);
            //End base entity Data


        }
    }
}

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
    public class AnalisysFormSubmitConfiguration : IEntityTypeConfiguration<AnalisysFormSubmit>
    {
        public void Configure(EntityTypeBuilder<AnalisysFormSubmit> builder)
        {

            builder.HasOne(u => u.Form)
                .WithMany(s => s.Submissions)
                .HasForeignKey(u => u.AnalisysFormId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Requester)
                .WithMany(s => s.Submissions)
                .HasForeignKey(u => u.RequesterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Solicitation)
                .WithOne(s => s.AnalisysFormSubmit)
                .IsRequired()
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

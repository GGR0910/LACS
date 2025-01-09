using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class RequesterNotesConfiguration : IEntityTypeConfiguration<RequesterNotes>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RequesterNotes> builder)
        {
            builder.Property(u => u.NoteText)
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            builder.Property(u => u.Important)
                .IsRequired();

            builder.HasOne(u => u.Solicitation)
                .WithMany(s => s.RequesterNotes)
                .HasForeignKey(u => u.SolicitationId)
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

            builder.HasOne(u => u.CreatedByUserLaboratory)
               .WithMany(x => x.RequesterNotesCreatedBy)
               .HasForeignKey(u => u.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.RequesterNotesUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data
        }   
    }
}

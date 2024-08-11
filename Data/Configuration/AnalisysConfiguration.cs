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
    public class AnalisysConfiguration : IEntityTypeConfiguration<Analisys>
    {
        public void Configure(EntityTypeBuilder<Analisys> builder)
        {
           builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.AmountDonePerDay)
                .IsRequired();

            builder.HasOne(u => u.Environment)
                .WithMany(s => s.Analisys)
                .HasForeignKey(u => u.EnvironmentId)
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

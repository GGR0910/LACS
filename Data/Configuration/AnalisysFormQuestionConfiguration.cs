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
    public class AnalisysFormQuestionConfiguration : IEntityTypeConfiguration<AnalisysFormQuestion>
    {
        public void Configure(EntityTypeBuilder<AnalisysFormQuestion> builder)
        {
           builder.Property(u => u.Question)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.HasOptions)
                .IsRequired();

            builder.Property(u => u.Order)
                .IsRequired();

            builder.HasOne(u => u.AnalisysForm)
                .WithMany(s => s.Questions)
                .HasForeignKey(u => u.AnalisysFormId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.QuestionType)
                .WithMany(s => s.Questions)
                .HasForeignKey(u => u.QuestionTypeId)
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

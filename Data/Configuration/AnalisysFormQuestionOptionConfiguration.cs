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
    public class AnalisysFormQuestionOptionConfiguration : IEntityTypeConfiguration<AnalisysFormQuestionOption>
    {
        public void Configure(EntityTypeBuilder<AnalisysFormQuestionOption> builder)
        {
           builder.Property(u => u.Option)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.OptionName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Enabled)
                .IsRequired();

            builder.HasOne(u => u.Question)
                .WithMany(s => s.Options)
                .HasForeignKey(u => u.QuestionId)
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

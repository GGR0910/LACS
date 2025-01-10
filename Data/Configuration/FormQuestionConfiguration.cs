using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration
{
    public class FormQuestionConfiguration : IEntityTypeConfiguration<FormQuestion>
    {
        public void Configure(EntityTypeBuilder<FormQuestion> builder)
        {
           builder.Property(u => u.QuestionText)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(u => u.QuestionInstructions)
                .HasMaxLength(200);

            builder.Property(u => u.QuestionPlaceholder)
                .HasMaxLength(200);

            builder.Property(u => u.Order)
                .IsRequired();

            builder.Property(u => u.IsRequired)
                .IsRequired();

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

            builder.HasOne(u => u.CreatedByUserLaboratory)
                  .WithMany(x => x.FormQuestionCreatedBy)
                  .HasForeignKey(u => u.CreatedById)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.FormQuestionUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data


        }
    }
}

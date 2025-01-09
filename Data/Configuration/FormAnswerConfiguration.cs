using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class FormAnswerConfiguration : IEntityTypeConfiguration<FormAnswer>
    {
        public void Configure(EntityTypeBuilder<FormAnswer> builder)
        {
           builder.Property(u => u.Answer)
                .IsRequired()
                .HasMaxLength(int.MaxValue);


            builder.HasOne(u => u.Question)
                .WithMany(s => s.Answers)
                .HasForeignKey(u => u.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Submission)
                .WithMany(s => s.Answers)
                .HasForeignKey(u => u.FormSubmitId)
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
               .WithMany(x => x.FormAnswerCreatedBy)
               .HasForeignKey(u => u.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.FormAnswerUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data


        }
    }
}

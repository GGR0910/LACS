using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration
{
    public class FormQuestionOptionConfiguration : IEntityTypeConfiguration<FormQuestionOption>
    {
        public void Configure(EntityTypeBuilder<FormQuestionOption> builder)
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

            builder.HasOne(u => u.CreatedByUserLaboratory)
                .WithMany(x => x.FormQuestionOptionCreatedBy)
                .HasForeignKey(u => u.CreatedById)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.FormQuestionOptionUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data


        }
    }
}

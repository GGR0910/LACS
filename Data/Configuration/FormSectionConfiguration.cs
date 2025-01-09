using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration
{
    public class FormSectionConfiguration : IEntityTypeConfiguration<FormSection>
    {

        public void Configure(EntityTypeBuilder<FormSection> builder)
        {

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Order).IsRequired();

            builder.HasOne(x => x.Form)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.FormId)
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
               .WithMany(x => x.FormSectionCreatedBy)
               .HasForeignKey(u => u.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.FormSectionUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data


        }

    }
}

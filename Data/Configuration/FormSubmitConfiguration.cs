using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configuration
{
    public class FormSubmitConfiguration : IEntityTypeConfiguration<FormSubmit>
    {
        public void Configure(EntityTypeBuilder<FormSubmit> builder)
        {

            builder.HasOne(u => u.Form)
                .WithMany(s => s.Submissions)
                .HasForeignKey(u => u.FormId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Requester)
                .WithMany(s => s.Submissions)
                .HasForeignKey(u => u.RequesterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Solicitation)
                .WithOne(s => s.FormSubmit)
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
                .WithMany(x => x.FormSubmitCreatedBy)
                .HasForeignKey(u => u.CreatedById)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.FormSubmitUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data


        }
    }
}

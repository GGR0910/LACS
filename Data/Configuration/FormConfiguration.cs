using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
           builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.FormVersion)
                .IsRequired();

            builder.Property(u => u.CollectDetailedSampleInformation);

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
               .WithMany(x => x.FormCreatedBy)
               .HasForeignKey(u => u.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.FormUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data


        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratory = Domain.Entities.Laboratory;

namespace Data.Configuration
{
    public class LaboratoryConfiguration : IEntityTypeConfiguration<Laboratory>
    {
        public void Configure(EntityTypeBuilder<Laboratory> builder)
        {
            
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.ResponsibleDocument)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.LaboratoryAdress)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.LaboratoryContactInfo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.LaboratoryEmail)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.DepartmentName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.CountryName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.ResponsibleName)
                .IsRequired()
                .HasMaxLength(200);

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
                .WithMany(x => x.LaboratoriesCreatedBy)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.LaboratoriesUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data


        }
    }
}

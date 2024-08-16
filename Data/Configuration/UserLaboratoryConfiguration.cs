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
    public class UserLaboratoryConfiguration : IEntityTypeConfiguration<UserLaboratory>
    {
        public void Configure(EntityTypeBuilder<UserLaboratory> builder)
        {
            builder.HasOne(u => u.Role)
                .WithMany(r => r.UserLaboratories)
                .HasForeignKey(u => u.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Laboratory)
                .WithMany(r => r.UserLaboratories)
                .HasForeignKey(u => u.LaboratoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.User)
               .WithMany(r => r.UserLaboratories)
               .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(ul => new { ul.LaboratoryId, ul.UserId }).IsUnique();

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
                .WithMany(x => x.UserLaboratoriesCreatedBy)
                .HasForeignKey(u => u.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.UpdatedByUserLaboratory)
                .WithMany(x => x.UserLaboratoriesUpdatedBy)
                .HasForeignKey(u => u.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
            //End base entity Data


        }
    }
}

﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class UserInteractionConfiguration : IEntityTypeConfiguration<UserInteraction>
    {
        public void Configure(EntityTypeBuilder<UserInteraction> builder)
        { 
            
            builder.Property(UI => UI.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(UI => UI.TargetId)
                .HasMaxLength(36);
            
            builder.HasOne(UI => UI.User)
                    .WithMany(U => U.UserInteractions)
                    .HasForeignKey(UI => UI.UserId)
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

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class FormQuestionTypeConfiguration : IEntityTypeConfiguration<FormQuestionType>
    {
        public void Configure(EntityTypeBuilder<FormQuestionType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}

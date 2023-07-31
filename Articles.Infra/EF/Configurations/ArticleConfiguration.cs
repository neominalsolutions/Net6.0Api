using Articles.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Infra.EF.Configurations
{
  public class ArticleConfiguration : IEntityTypeConfiguration<Article>
  {
    public void Configure(EntityTypeBuilder<Article> builder)
    {
      //builder.ToTable("Makale");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Name).HasMaxLength(100);
      builder.Property(x => x.Name).IsRequired();
      builder.HasIndex(x => x.Name).IsUnique();

      //builder.Property(x => x.Description).HasColumnName("Aciklama");

      builder.HasMany(x => x.Comments);

    }
  }
}

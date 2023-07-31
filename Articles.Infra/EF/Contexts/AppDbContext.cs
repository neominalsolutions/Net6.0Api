using Articles.Domain.Entities;
using Articles.Infra.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Infra.EF.Contexts
{
  public class AppDbContext:DbContext
  {

    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
      // DbContextOptions<AppDbContext farklı provide rbağlantısı için kullanıyoruz.
    }

    // sadece sorgulayacağımız nesne tiplerini tanımlıyoruz
    // root nesler ile ilgili entityler tablo olarak root nesne üzerinden oluşuyor
    public DbSet<Article> Articles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      //modelBuilder.Entity<Article>().ToTable("Makale");
      //modelBuilder.Entity<Article>().HasKey(x => x.Id);
      //modelBuilder.Entity<Article>().Property(x => x.Name).HasMaxLength(100);
      //modelBuilder.Entity<Article>().Property(x => x.Name).IsRequired();
      //modelBuilder.Entity<Article>().HasIndex(x => x.Name).IsUnique();

      //modelBuilder.Entity<Article>().Property(x => x.Description).HasColumnName("Aciklama");

      //modelBuilder.Entity<Article>().HasMany(x => x.Comments);

      modelBuilder.ApplyConfiguration(new ArticleConfiguration());

      base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
      return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
      return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }


  }
}

using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Infra.EF.Contexts
{
 
  public class AppIdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
  {
    public AppIdentityDbContext CreateDbContext(string[] args)
    {

      var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
      optionsBuilder.UseSqlServer("Server=(localDB)\\MyLocalDb;Database=ArticleDB;Trusted_Connection=True;");

      return new AppIdentityDbContext(optionsBuilder.Options);
    }
  }
}

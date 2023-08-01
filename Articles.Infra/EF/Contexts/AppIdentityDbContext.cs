using Articles.Infra.EF.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Infra.EF.Contexts
{
  public class AppIdentityDbContext:IdentityDbContext<AppUser,AppRole,string>
  {
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> opt):base(opt)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      //builder.Entity<AppUser>().ToTable("Users");

      base.OnModelCreating(builder);
    }
  }
}

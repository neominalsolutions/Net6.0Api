using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Core.EF
{
  public class EFUnitOfWork<TContext> : IUnitOfWork
    where TContext : DbContext
  {
    private readonly TContext context;

    public EFUnitOfWork(TContext context)
    {
      this.context = context;
    }

    public int Commit()
    {

      int result = 0;

      using (var tra = this.context.Database.BeginTransaction())
      {
        
        try
        {
          // ef de auto commit odugu için 
          // context.SaveChanges() manuel transaction yönetime gerek kalmıyor
          result =  this.context.SaveChanges();
          tra.Commit();
           
        }
        catch (Exception ex)
        {
          tra.Rollback();

          return result;
        }
      }

      return result;
      
    }
  }
}

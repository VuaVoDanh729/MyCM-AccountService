
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountInfrastructure.context
{
    public class EFConfiguration : IDesignTimeDbContextFactory<AccountContext>
    {
        public AccountContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountContext>();
            //           optionsBuilder.UseNpgsql(@"Server=orcm-system.c43jmtu6ijbj.ap-southeast-1.rds.amazonaws.com;Database=postgres;Port=5431;User Id=ngochoi1999;Password=sasasasa;Ssl Mode=Require;Trust Server Certificate=true");
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=AccountDb;Trusted_Connection=True;");
            return new AccountContext(optionsBuilder.Options);
        }
    }
}

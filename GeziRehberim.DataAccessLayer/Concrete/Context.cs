using GeziRehberim.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeziRehberim.DataAccessLayer.Concrete
{
	public class Context :IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-C3RSTJQ\\SQLEXPRESS;initial catalog=GeziRehberimDb;integrated Security=true");
		}
		public DbSet<CustomerAccount> CustomerAccounts { get; set; }
		public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
	}
}

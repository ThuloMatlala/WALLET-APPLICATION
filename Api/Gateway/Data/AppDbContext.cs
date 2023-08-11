using Gateway.Models;
using Microsoft.EntityFrameworkCore;

namespace Gateway.Data
{
	public class AppDbContext : DbContext
    {
		public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }
}


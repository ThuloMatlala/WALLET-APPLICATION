using AccountManagementService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManagementService.Data
{
	public class AppDbContext : DbContext
    {
		public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}


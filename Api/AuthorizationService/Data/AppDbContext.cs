using AccountManagementService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Data
{
	public class AppDbContext : DbContext
    {
		public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }
        public DbSet<UserAccount> Platforms { get; set; }
    }
}


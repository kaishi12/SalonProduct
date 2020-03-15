using Microsoft.EntityFrameworkCore;

namespace Salon.Account.Repository.DbContext
{
    public class AccountDataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Account.Domain.Entity.Account> Accounts { get; set; }

        public AccountDataContext(DbContextOptions<AccountDataContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountDataContext).Assembly);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WalletEcom.DB.EnityTypeConfigurations.AccontEntityConfigurations;
using WalletEcom.DB.EnityTypeConfigurations.ActionEntiryConfigurations;
using WalletEcom.DB.EnityTypeConfigurations.WalletEntityConfigurations;
using WalletEcom.Models.Account;
using WalletEcom.Models.Action;
using WalletEcom.Models.Wallet;

namespace WalletEcom.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Account> AccountDb { get; set; } = null!;
        public DbSet<AccountType> AccountTypeDb { get; set; } = null!;

        public DbSet<ActionType> ActionDb { get; set; } = null!;
        public DbSet<ActionFee> ActionFeeDb { get; set; } = null!;
        public DbSet<Wallet> WalletDb { get; set; } = null!;

        public DbSet<WalletHistory> WalletHistoryDb { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WalletEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WalletHistoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActionFeeEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
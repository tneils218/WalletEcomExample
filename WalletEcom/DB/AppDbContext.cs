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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Account> Account { get; set; } = null!;
        public DbSet<AccountType> AccountType { get; set; } = null!;

        public DbSet<ActionType> Action { get; set; } = null!;
        public DbSet<ActionFee> ActionFee { get; set; } = null!;
        public DbSet<Wallet> Wallet { get; set; } = null!;

        public DbSet<WalletHistory> WalletHistory { get; set; } = null!;





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

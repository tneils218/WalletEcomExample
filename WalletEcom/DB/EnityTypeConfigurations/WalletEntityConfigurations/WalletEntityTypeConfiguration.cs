using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletEcom.Models.Wallet;

namespace WalletEcom.DB.EnityTypeConfigurations.WalletEntityConfigurations
{
    public class WalletEntityTypeConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("tbl_wallet");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Amount).HasColumnName("wallet_amount");
            builder.Property(e => e.UpdatedAt).HasColumnName("wallet_updated_at");
            builder.HasOne(e => e.Account)
                    .WithMany()
                    .HasForeignKey("account_id");
        }
    }
}

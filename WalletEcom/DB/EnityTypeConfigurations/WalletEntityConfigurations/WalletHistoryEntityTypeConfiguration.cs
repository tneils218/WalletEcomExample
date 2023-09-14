

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletEcom.Models.Wallet;

namespace WalletEcom.DB.EnityTypeConfigurations.WalletEntityConfigurations
{
    public class WalletHistoryEntityTypeConfiguration : IEntityTypeConfiguration<WalletHistory>

    {
        public void Configure(EntityTypeBuilder<WalletHistory> builder)
        {
            builder.ToTable("tbl_wallet_history");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Wallet)
             .WithMany()
             .HasForeignKey("wallet_id");
            builder.HasOne(e => e.AccountType)
            .WithMany()
            .HasForeignKey("wallet_account_type");
            builder.HasOne(e => e.ActionType)
          .WithMany()
          .HasForeignKey("wallet_action_type");
            builder.Property(e => e.Amount).HasColumnName("wallet_amount");
            builder.Property(e => e.SourceWalletId).HasColumnName("source_wallet_id");
            builder.Property(e => e.DestinationWalletId).HasColumnName("destination_wallet_id");
            builder.Property(e => e.CreatedAt).HasColumnName("wallet_createdat");
            builder.Property(e => e.Fee).HasColumnName("wallet_fee");


        }
    }
}

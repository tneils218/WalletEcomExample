using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletEcom.Models.Account;
using WalletEcom.Models.Action;

namespace WalletEcom.DB.EnityTypeConfigurations.ActionEntiryConfigurations
{
    public class ActionFeeEntityTypeConfiguration : IEntityTypeConfiguration<ActionFee>
    {
        public void Configure(EntityTypeBuilder<ActionFee> builder)
        {
            builder.ToTable("tbl_action_fee");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.AccountType)
                .WithMany()
                .HasForeignKey("action_fee_account_type");
            builder.HasOne(e => e.ActionType)
               .WithMany()
               .HasForeignKey("action_fee_action_type");
            builder.Property(e => e.Fee).HasColumnName("fee");
        }
    } 
}

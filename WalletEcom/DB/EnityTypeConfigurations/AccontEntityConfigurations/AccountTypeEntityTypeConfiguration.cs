using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletEcom.Models.Account;

namespace WalletEcom.DB.EnityTypeConfigurations.AccontEntityConfigurations
{
    public class AccountTypeEntityTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.ToTable("tbl_account_type");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnName("account_type_name").HasMaxLength(50);
        }
    }
}
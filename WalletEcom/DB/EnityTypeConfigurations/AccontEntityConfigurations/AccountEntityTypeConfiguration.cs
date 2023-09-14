using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletEcom.Models.Account;

namespace WalletEcom.DB.EnityTypeConfigurations.AccontEntityConfigurations
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("tbl_account");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.UserName)
                       .IsUnique();
            builder.Property(e => e.UserName).HasColumnName("user_name");
            builder.Property(e => e.DOB).HasColumnName("dob");

            builder.Property(e => e.Email).
                HasColumnName("email")
               .HasMaxLength(50) 
               .IsRequired();

            builder.HasIndex(e => e.Email)
                 .IsUnique();

            builder.Property(e => e.FullName)
                  .HasColumnName("full_name")
                  .HasMaxLength(200)
                  .IsRequired();

            builder.Property(e => e.CreatedAt)
             .HasColumnName("created_at");

            builder.Property(e => e.Status).HasColumnName("status");

            builder.HasOne(e => e.AccountType)
               .WithMany()
               .HasForeignKey("account_type_id");

        }
    }
}
    
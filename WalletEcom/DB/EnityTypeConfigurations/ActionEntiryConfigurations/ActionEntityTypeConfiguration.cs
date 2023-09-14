using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletEcom.Models.Action;

namespace WalletEcom.DB.EnityTypeConfigurations.ActionEntiryConfigurations
{
    public class ActionEntityTypeConfiguration : IEntityTypeConfiguration<ActionType>
    {
        public void Configure(EntityTypeBuilder<ActionType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("tbl_action");
            builder.Property(e => e.Name).HasColumnName("action_name").HasMaxLength(50).IsRequired();
        }
    }
}
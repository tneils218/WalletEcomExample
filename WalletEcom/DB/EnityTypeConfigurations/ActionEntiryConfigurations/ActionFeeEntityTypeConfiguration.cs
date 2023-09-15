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
            builder.Property(e => e.AccountTypeId)
              .HasColumnName("action_fee_account_type");
            builder.HasOne(e => e.AccountType)
                .WithMany()
                .HasForeignKey(e => e.AccountTypeId);
            builder.Property(e => e.ActionTypeId)
            .HasColumnName("action_fee_action_type");
            builder.HasOne(e => e.ActionType)
               .WithMany()
               .HasForeignKey(e => e.ActionTypeId);
            builder.Property(e => e.Fee).HasColumnName("fee");
            builder.HasData(CreateActionFee());
        }
        private ActionFee[] CreateActionFee()
        {
            return new ActionFee[]
            {
                   new ActionFee(id: 1, accountTypeId: 1, actionTypeId: 1, fee: 0),
                   new ActionFee(id: 2, accountTypeId: 2, actionTypeId: 1, fee: 0),
                   new ActionFee(id: 3, accountTypeId: 3, actionTypeId: 1, fee: 0),
                   new ActionFee(id: 4, accountTypeId: 1, actionTypeId: 2, fee: 30),
                   new ActionFee(id: 5, accountTypeId:2, actionTypeId: 2, fee: 20),
                    new ActionFee(id: 6, accountTypeId:3, actionTypeId: 2, fee: 0),
            };
        }

        //private ActionType[] CreateActionType()
        //{
        //    return new ActionType[]
        //    {
        //           new ActionType(1, "Add money"),
        //           new ActionType(2, "Transfer money"),
        //           new ActionType(3, "Withdraw money"),
        //           new ActionType(4, "Receive money"),
        //    };

       }
    }
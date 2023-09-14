using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WalletEcom.Models.Account;

namespace WalletEcom.Models.Action
{
    public class ActionFee
    {
     
        public int Id { get; set; }


        public AccountType AccountType { get; set; } = null!;


        public ActionType ActionType { get; set; } = null!;

       
        public decimal Fee { get; set; }
    }
}

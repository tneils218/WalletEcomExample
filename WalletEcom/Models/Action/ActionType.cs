using System.ComponentModel.DataAnnotations;

namespace WalletEcom.Models.Action
{
    public class ActionType
    {
      
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}

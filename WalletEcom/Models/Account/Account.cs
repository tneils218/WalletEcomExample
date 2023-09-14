namespace WalletEcom.Models.Account
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public DateTime DOB { get; set; }
                
        public bool Status { get; set; }

        public AccountType AccountType { get; set; } = null!;
 
        public DateTime CreatedAt { get; set; }

    }
}

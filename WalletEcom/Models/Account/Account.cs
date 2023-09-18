namespace WalletEcom.Models.Account
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public bool Status { get; set; }
        public AccountType? AccountType { get; set; }
        public int AccountTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ActivatedAt { get; set; }

        public Account() { }

        public Account(string userName, string fullName, string email, DateTime dob, int typeId)
        {
            UserName = userName;
            FullName = fullName;
            Email = email;
            DOB = dob;
            Status = false;
            CreatedAt = DateTime.Now;
            AccountTypeId = typeId;
        }

        public void Active()
        {
            Status = true;
            ActivatedAt = DateTime.Now;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using WalletEcom.Controllers.Request;
using WalletEcom.Models.Account;

namespace WalletEcom.Services.DTOs
{
    namespace WalletEcom.Services.DTOs
    {
        public class AccountDTO
        {
            public int AccountTypeId { get; private set; }
            public string UserName { get; private set; }
            public string FullName { get; private set; }
            public string Email { get; private set; }
            public DateTime DOB { get; private set; }
            private AccountDTO(string userName, string fullName, string email, DateTime dob, int typeId) 
            {
                AccountTypeId = typeId;
                UserName = userName;
                FullName = fullName;
                Email = email;
                DOB = dob;
            }

            public static AccountDTO Create(string userName, string fullName, string email, DateTime dob, int accountTypeId)
            {
                return new AccountDTO(userName, fullName, email, dob, accountTypeId);
            }
        }
    }
}

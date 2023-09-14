using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using WalletEcom.Controllers.Request;

namespace WalletEcom.Services.DTOs
{
    public class AccountDTO
    {
        public string UserName { get; private set; } = null!;
        
        public string FullName { get; private set; } = null!;
       
        public string Email { get; private set; } = null!;

        public DateTime DOB { get; private set; }
        public AccountDTO(string userName, string fullName, string email, DateTime dob)
        {
            UserName = userName;
            FullName = fullName;
            Email = email;
            DOB = dob;
        }
        public static AccountDTO Create(AccountRequest request)
        {
            return new AccountDTO(request.UserName, request.FullName, request.Email, request.DOB);
        } 
    }
}

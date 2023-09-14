﻿using System.ComponentModel.DataAnnotations;

namespace WalletEcom.Controllers.Request
{
    public class AccountRequest
    {
        [Required]
        [MaxLength(50)]

        public string UserName { get; set; } = null!;
        [Required]
        [MaxLength(200)]
        public string FullName { get; set; } = null!;
        
        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        
        [Required]
        public DateTime DOB { get; set; } 
    }
}
﻿using System.ComponentModel.DataAnnotations;

namespace WalletEcom.Controllers.Request
{
    public class WalletAmountRequest
    {
        [Range(1, double.MaxValue, ErrorMessage = "The field {0} must be greater than or equal to {1}.")]
        public decimal amount { get; set; }
    }
}

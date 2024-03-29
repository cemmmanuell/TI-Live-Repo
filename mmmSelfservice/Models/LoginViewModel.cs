﻿namespace mmmSelfservice.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class LoginViewModel
    {
        [Required, Display(Name="Email"), EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), Display(Name="Password")]
        public string Password { get; set; }

        [Display(Name="Remember me?")]
        public bool RememberMe { get; set; }
    }
}


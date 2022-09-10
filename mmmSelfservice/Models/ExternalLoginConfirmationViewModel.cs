namespace mmmSelfservice.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class ExternalLoginConfirmationViewModel
    {
        [Required, Display(Name="Email")]
        public string Email { get; set; }
    }
}


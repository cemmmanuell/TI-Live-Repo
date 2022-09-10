namespace mmmSelfservice.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class AddPhoneNumberViewModel
    {
        [Required, Phone, Display(Name="Phone Number")]
        public string Number { get; set; }
    }
}


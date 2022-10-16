﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LoginIdentityCore.Models
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Cofirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passawords aren't match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}

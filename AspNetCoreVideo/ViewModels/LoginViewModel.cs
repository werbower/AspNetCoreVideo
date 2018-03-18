﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreVideo.ViewModels{
    public class LoginViewModel    {
        [Required]
        public string Username { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}

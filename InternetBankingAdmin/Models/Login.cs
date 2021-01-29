﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBankingAdmin.Models
{
    public class Login
    {
        [StringLength(8), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Login ID")]
        public string LoginID { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [Required, StringLength(64)]
        public string PasswordHash { get; set; }

        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modify Date")]
        public DateTime ModifyDate { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}

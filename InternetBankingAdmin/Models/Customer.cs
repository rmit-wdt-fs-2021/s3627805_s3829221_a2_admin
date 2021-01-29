﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBankingAdmin.Models
{

    public enum State
    {
        VIC = 1,
        NSW = 2,
        SA = 3,
        QLD = 4,
        TAS = 5
    }


    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string TFN { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        public State? State { get; set; }

        [StringLength(4, MinimumLength = 4)]
        public string PostCode { get; set; }

        [Required, StringLength(15), RegularExpression(@"^\+61 [0-9]{4} [0-9]{4}$")]
        public string Phone { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }
}

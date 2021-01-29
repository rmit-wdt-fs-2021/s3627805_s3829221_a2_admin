using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBankingAPI.Models
{

    public enum AccountType
    {
        Saving = 'S',
        Checking = 'C'
    }


    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Account Number")]
        public int AccountNumber { get; set; }

        [Display(Name = "Type")]
        public AccountType AccountType { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [Required, DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modify Date")]
        public DateTime ModifyDate { get; set; }

        public virtual List<Transaction> Transactions { get; set; }

        public virtual List<BillPay> BillPays { get; set; }


        public decimal GetBalance()
        {
            decimal balance = 0;
            foreach (var x in Transactions)
            {
                if (x.TransactionType == TransactionType.Deposit 
                    || x.TransactionType == TransactionType.Transfer && x.DestAccount == null)
                    balance += x.Amount;
                else
                    balance -= x.Amount;
            }

            return balance;
        }


        // Check if this account has free transaction left
        public bool HasServiceFee()
        {
            var count = Transactions.Count(x => x.TransactionType == TransactionType.Withdrawal 
                                                || x.TransactionType == TransactionType.Transfer
                                                && x.DestAccount != null);

            if (count < 4)
                return false;
            else
                return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Models.Accounts
{
    public abstract class Account
    {
        //Properties
        public string AccountNumber { get; private set; }
        public string HolderName { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public string AccountType => this.GetType().Name;

        //Constructor
        protected Account(string accountNumber, string holderName, decimal balance, string accountType)
        {
            if(string.IsNullOrWhiteSpace(accountNumber)) throw new ArgumentException("account number cannot be empty");
            if(string.IsNullOrWhiteSpace(holderName)) throw new ArgumentException("holder name cannot be empty");
            if (balance < 0) throw new ArgumentException("initial ballance cannot be negative");
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }
        //Methods 
        public abstract decimal CalculateInterest();
        public abstract string GetAccountBenefits();

        public virtual void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Holder Name: {HolderName}");
            Console.WriteLine($"Balance: {Balance:C}");
            Console.WriteLine($"Created Date: {CreatedDate:d}");
            Console.WriteLine($"Account Type: {this.GetType().Name}");
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAccountAppUsingList.Model
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public double AccountBalance { get; set; }
        public long AadharNumber { get; set; }
        public static double MAXIMUM_BALANCE = 0;
        public const double MIN_BALANCE = 500;
        public int maxBalanceAccountNumber;

        public Account()
        { }


        public Account(int accountNumber, string bankName, string accountHolderName, long aadharNumber) : this(accountNumber, bankName, accountHolderName, aadharNumber, MIN_BALANCE)
        { }

        public Account(int accountNumber, string bankName, string accountHolderName, long aadharNumber, double accountBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            BankName = bankName;
            AadharNumber = aadharNumber;
        }

        public string DepositAmount(double amount)
        {
            AccountBalance += amount;
            return $"{amount} deposited successfully";
        }

        public string WithdrawAmount(double amount)
        {
            if ((AccountBalance - amount) < MIN_BALANCE)
                return "No withdrawl possilbe";
            AccountBalance -= amount;
            return $"{amount} is withdrawn.";
        }

        public void PrintAccountDetails()
        {
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Account Holder Name : {AccountHolderName}");
            Console.WriteLine($"Account's Bank Name : {BankName}");
            Console.WriteLine($"Account Balance : {AccountBalance}");
            Console.WriteLine($"Aadhar Number : {AadharNumber}");
            Console.WriteLine();
        }

        public void CheckAccountBalance()
        {
            Console.WriteLine($"The account balance for {AccountNumber} is {AccountBalance}\n");
        }

        public int GetAccountNumber()
        {
            return AccountNumber;
        }

        public static double ReturnMaxBalance(List<Account> accounts)
        {
            foreach (Account account in accounts)
            {
                if (account != null && account.AccountBalance > MAXIMUM_BALANCE)
                {
                    MAXIMUM_BALANCE = account.AccountBalance;
                }
            }
            return MAXIMUM_BALANCE;
        }
    }
}

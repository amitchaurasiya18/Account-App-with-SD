using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAccountAppUsingList.Model
{
    internal class AccountManager : Account
    {
        public static void Add(List<Account> accounts)
        {
            Account account = new Account();
            Console.Write("Enter the Account Number : ");
            account.AccountNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the Account Holder Name : ");
            account.AccountHolderName = Console.ReadLine();

            Console.Write("Enter the Bank Name : ");
            account.BankName = Console.ReadLine();

            Console.Write("Enter the Aadhar Number : ");
            account.AadharNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter the Initial Account balance : ");
            account.AccountBalance = double.Parse(Console.ReadLine());
            if (account.AccountBalance < MIN_BALANCE || account.AccountBalance == null)
                account.AccountBalance = MIN_BALANCE;
            else
                account.AccountBalance = account.AccountBalance;

            accounts.Add(account);

            Console.WriteLine("Account added successfully");
            return;
        }

        public static void Update(List<Account> accounts)
        {
            Console.Write("Enter the account for which you want to Update Details : ");
            int accountNumber = int.Parse(Console.ReadLine());

            Account account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                Console.WriteLine("Enter Updated Account Holder Name: ");
                account.AccountHolderName = Console.ReadLine();

                Console.WriteLine("Enter Updated Bank Name: ");
                account.BankName = Console.ReadLine();

                Console.WriteLine("Account updated successfully");
                return;
            }
            Console.WriteLine("Account not found");
            return;
        }

        public static void Delete(List<Account> accounts)
        {
            Console.Write("Enter the Account number to delete account : ");
            int accountNumber = int.Parse(Console.ReadLine());

            Account account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                accounts.Remove(account);
                Console.WriteLine("Account deleted successfully");
                return;
            }
            Console.WriteLine("Account not found");
            return;
        }

        public static void Display(List<Account> accounts)
        {
            Console.Write("Enter the Account number to delete account : ");
            int accountNumber = int.Parse(Console.ReadLine());

            Account account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                account.PrintAccountDetails();
                Console.WriteLine("Account deleted successfully");
                return;
            }
            Console.WriteLine("Account not found");
            return;
        }


        public static void Transactions(List<Account> accounts)
        {
            bool continueTransactions = true;

            while (continueTransactions)
            {
                Console.Write("Enter the account number to perform transactions (or enter 0 to exit): ");
                int accountNumber = int.Parse(Console.ReadLine());

                if (accountNumber == 0)
                {
                    continueTransactions = false;
                    break;
                }

                Account selectedAccount = null;

                foreach (Account account in accounts)
                {
                    if (account.GetAccountNumber() == accountNumber)
                    {
                        selectedAccount = account;
                        break;
                    }
                }

                if (selectedAccount != null)
                {
                    bool continueAccount = true;
                    while (continueAccount)
                    {
                        Console.WriteLine("\n------Select transaction:------\nPress 1 for Check Balance\nPress 2 for Deposit\nPress 3 for Withdrawl\nPress 4 to Exit");
                        int selectTransaction = int.Parse(Console.ReadLine());

                        switch (selectTransaction)
                        {
                            case 1:
                                selectedAccount.CheckAccountBalance();
                                break;
                            case 2:
                                Console.Write("Enter the amount which you want to deposit : ");
                                double depositAmount = double.Parse(Console.ReadLine());
                                Console.WriteLine(selectedAccount.DepositAmount(depositAmount));
                                break;
                            case 3:
                                Console.Write("Enter the amount which you want to Withdraw : ");
                                double withdrawAmount = double.Parse(Console.ReadLine());
                                Console.WriteLine(selectedAccount.WithdrawAmount(withdrawAmount));
                                break;
                            case 4:
                                continueAccount = false;
                                break;
                            default:
                                Console.WriteLine("Select Transaction again...");
                                break;
                        }
                    }
                }
                else
                    Console.WriteLine("Account not found. Please try again.");
            }
        }

        public static void ManageAccount()
        {
            List<Account> accounts = new List<Account>();

            accounts = SerialiseDeserialise.Deserialize();

            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("Select Operations: \n1. Add Account\n2. Update Account\n3. Delete Account\n4. Account Details\n5. Perform Transactions\n6. To get Maximum balance account\n7. Exit");
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Add(accounts);
                        break;
                    case 2:
                        Update(accounts);
                        break;
                    case 3:
                        Delete(accounts);
                        break;
                    case 4:
                        Display(accounts);
                        break;
                    case 5:
                        Transactions(accounts);
                        break;
                    case 6:
                        Console.WriteLine($"The Maximum account balance is : {ReturnMaxBalance(accounts)}");
                        break;
                    case 7:
                        continueProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                SerialiseDeserialise.Serialize(accounts);
            }
        }
    }
}
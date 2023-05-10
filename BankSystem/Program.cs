using System;
using System.Collections.Generic;

namespace BankSystem
{
    class BankSystem
    {
        static Dictionary<string, double> accounts = new Dictionary<string, double>();
        static string currentUser = "";

        static void Main(string[]args)
        {
            RunBankSystem();
            
        }
        
        
        static void RunBankSystem()
        {
            bool isRunning = true;
            bool isLoggedIn = false;


            // Default username and password
            accounts.Add("defaultuser", 1234.56);
    
            while (isRunning)
            {
                Console.WriteLine("Please choose from one of the following options...");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Create an Account (Current or Savings)");
                Console.WriteLine("4. Deposit");
                Console.WriteLine("5. Withdraw");
                Console.WriteLine("6. View Account Statement/Show Balance");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Signup();
                        break;
                    case 2:
                        isLoggedIn = Login();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                    case 3:
                        if (isLoggedIn)
                        {
                            CreateAccount();
                            Deposit();
                            Withdraw();

                        }
                        else
                        {
                            Console.WriteLine("Please login first.");
                        }
                        break;

                    case 4:
                        if (isLoggedIn)
                        {
                            double viewBalance = 1000.00;
                            Console.WriteLine("Your account balance is: " + viewBalance);
                        }
                        else
                        {
                            Console.WriteLine("Please login first.");
                        }
                        break;
                    case 5:
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;

                }

                Console.WriteLine();
            }
        }

        static bool Login()
        {
            Console.Write("Please Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (accounts.ContainsKey(username) && accounts[username] == double.Parse(password))
            {
                currentUser = username;
                Console.WriteLine($"Welcome, {currentUser}!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }
        }
        static void Signup()
        {
            Console.Write("Please enter your username: ");
            string username = Console.ReadLine();

            if (accounts.ContainsKey(username))
            {
                Console.WriteLine("Username already exists. Please try again.");
                return;
            }

            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();

            accounts.Add(username, double.Parse(password));
            Console.WriteLine($"Signup successful! Welcome, {username}!");
        }

        static void CreateAccount()
        {
            Console.Write("Enter the account type (Current or Savings): ");
            string accountType = Console.ReadLine();
            Console.Write("Enter the initial balance: ");
            double initialBalance = double.Parse(Console.ReadLine());
            Console.Write("Enter a username for the account: ");
            string username = Console.ReadLine();
            Console.Write("Enter a password for the account: ");
            string password = Console.ReadLine();

           

        
        accounts.Add(username, initialBalance);

            Console.WriteLine($"Account created successfully! Username: {username}, Account number: {username}");
        }

        static void Deposit()
        {
            Console.Write("Enter the account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter the amount to deposit: ");
            double amount = double.Parse(Console.ReadLine());

            if (accounts.ContainsKey(accountNumber))
            {
                accounts[accountNumber] += amount;
                Console.WriteLine($"Deposit successful! New balance: {accounts[accountNumber]}");
            }
            else
            {
                Console.WriteLine("Invalid account number.");
            }
        }

        static void Withdraw()
        {
            Console.Write("Enter the account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter the amount to withdraw: ");
            double amount = double.Parse(Console.ReadLine());

            if (accounts.ContainsKey(accountNumber))
            {
                if (accounts[accountNumber] >= amount)
                {
                    accounts[accountNumber] -= amount;
                    Console.WriteLine($"Withdrawal successful! New balance: {accounts[accountNumber]}");
                }


            }
        }
    }
}

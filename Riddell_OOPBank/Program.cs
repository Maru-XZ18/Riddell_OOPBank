using System;

namespace Riddell_OOPBank
{
    class Bank
    {
        private decimal balance;

        public Bank(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited ${amount:F2}. New balance: ${balance:F2}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                if (amount <= 500)
                {
                    balance -= amount;
                    if (balance < 0)
                    {
                        balance = 0;
                    }
                    Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${balance:F2}");
                }
                else
                {
                    Console.WriteLine("Withdrawal amount exceeds the limit of $500.");
                }
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Current balance: ${balance:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal initialBalance = 1000.0M;
            Bank bank = new Bank(initialBalance);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Quit");

                Console.Write("Enter your choice (1/2/3/4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the deposit amount: $");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            bank.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid decimal value.");
                        }
                        break;
                    case "2":
                        Console.Write("Enter the withdrawal amount: $");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
                        {
                            bank.Withdraw(withdrawalAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid decimal value.");
                        }
                        break;
                    case "3":
                        bank.CheckBalance();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using Bank of Centralia. Have a great day!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
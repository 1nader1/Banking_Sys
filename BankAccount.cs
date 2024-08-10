using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public abstract class BankAccount
{
    private decimal balance;

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount:C}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew: {amount:C}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
    }

    public decimal GetBalance()
    {
        return balance;
    }
}

public class SavingsAccount : BankAccount
{
    private decimal interestRate;

    public SavingsAccount(decimal initialBalance, decimal interestRate)
        : base(initialBalance)
    {
        this.interestRate = interestRate;
    }

    public void CalculateInterest()
    {
        decimal interest = GetBalance() * interestRate;
        Deposit(interest);
        Console.WriteLine($"Interest added: {interest:C}");
    }
}

public class CheckingAccount : BankAccount
{
    public CheckingAccount(decimal initialBalance)
        : base(initialBalance)
    {
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Banking System!");

        Console.Write("Enter initial balance for Savings Account: ");
        decimal savingsInitialBalance = decimal.Parse(Console.ReadLine());
        Console.Write("Enter interest rate for Savings Account (as a decimal, e.g., 0.05 for 5%): ");
        decimal interestRate = decimal.Parse(Console.ReadLine());
        SavingsAccount savingsAccount = new SavingsAccount(savingsInitialBalance, interestRate);

        Console.Write("Enter initial balance for Checking Account: ");
        decimal checkingInitialBalance = decimal.Parse(Console.ReadLine());
        CheckingAccount checkingAccount = new CheckingAccount(checkingInitialBalance);

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Deposit to Savings Account");
            Console.WriteLine("2. Withdraw from Savings Account");
            Console.WriteLine("3. Calculate interest on Savings Account");
            Console.WriteLine("4. Get Savings Account balance");
            Console.WriteLine("5. Deposit to Checking Account");
            Console.WriteLine("6. Withdraw from Checking Account");
            Console.WriteLine("7. Get Checking Account balance");
            Console.WriteLine("8. Exit");

            string choice = Console.ReadLine();
            if (choice == "8")
                break;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter amount to deposit into Savings Account: ");
                    decimal savingsDeposit = decimal.Parse(Console.ReadLine());
                    savingsAccount.Deposit(savingsDeposit);
                    break;
                case "2":
                    Console.Write("Enter amount to withdraw from Savings Account: ");
                    decimal savingsWithdraw = decimal.Parse(Console.ReadLine());
                    savingsAccount.Withdraw(savingsWithdraw);
                    break;
                case "3":
                    savingsAccount.CalculateInterest();
                    break;
                case "4":
                    Console.WriteLine($"Savings Account Balance: {savingsAccount.GetBalance():C}");
                    break;
                case "5":
                    Console.Write("Enter amount to deposit into Checking Account: ");
                    decimal checkingDeposit = decimal.Parse(Console.ReadLine());
                    checkingAccount.Deposit(checkingDeposit);
                    break;
                case "6":
                    Console.Write("Enter amount to withdraw from Checking Account: ");
                    decimal checkingWithdraw = decimal.Parse(Console.ReadLine());
                    checkingAccount.Withdraw(checkingWithdraw);
                    break;
                case "7":
                    Console.WriteLine($"Checking Account Balance: {checkingAccount.GetBalance():C}");
                    break;


                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Banking System. Goodbye!");
    }
}

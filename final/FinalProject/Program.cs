using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Transaction> transactions = new List<Transaction>();
    static int nextId = 1;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Personal Finance Tracker ===");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. View All Transactions");
            Console.WriteLine("4. View Financial Summary");
            Console.WriteLine("5. Sort Transactions by Date");
            Console.WriteLine("6. Sort Transactions by Amount");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddIncome();
                    break;
                case "2":
                    AddExpense();
                    break;
                case "3":
                    DisplayAllTransactions();
                    break;
                case "4":
                    DisplaySummary();
                    break;
                case "5":
                    SortTransactionsByDate();
                    Console.WriteLine("Transactions sorted by date.");
                    break;
                case "6":
                    SortTransactionsByAmount();
                    Console.WriteLine("Transactions sorted by amount.");
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddIncome()
    {
        Console.Write("Enter amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter source: ");
        string source = Console.ReadLine();

        IncomeTransaction income = new IncomeTransaction(
            nextId,
            DateTime.Now,
            amount,
            category,
            description,
            source
        );

        transactions.Add(income);
        nextId++;

        Console.WriteLine("Income added successfully.");
    }

    static void AddExpense()
    {
        Console.Write("Enter amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter payment method: ");
        string paymentMethod = Console.ReadLine();

        ExpenseTransaction expense = new ExpenseTransaction(
            nextId,
            DateTime.Now,
            amount,
            category,
            description,
            paymentMethod
        );

        transactions.Add(expense);
        nextId++;

        Console.WriteLine("Expense added successfully.");
    }

    static void DisplayAllTransactions()
    {
        if (transactions.Count == 0)
        {
            Console.WriteLine("No transactions found.");
            return;
        }

        Console.WriteLine("\n--- All Transactions ---");
        foreach (Transaction transaction in transactions)
        {
            Console.WriteLine(transaction.GetSummary());
        }
    }

    static void DisplaySummary()
    {
        decimal totalIncome = 0;
        decimal totalExpenses = 0;

        foreach (Transaction transaction in transactions)
        {
            if (transaction is IncomeTransaction)
            {
                totalIncome += transaction.Amount;
            }
            else if (transaction is ExpenseTransaction)
            {
                totalExpenses += transaction.Amount;
            }
        }

        decimal balance = totalIncome - totalExpenses;

        Console.WriteLine("\n--- Financial Summary ---");
        Console.WriteLine($"Total Income:   ${totalIncome:F2}");
        Console.WriteLine($"Total Expenses: ${totalExpenses:F2}");
        Console.WriteLine($"Balance:        ${balance:F2}");
    }

    static void SortTransactionsByDate()
    {
        transactions = transactions.OrderBy(t => t.Date).ToList();
    }

    static void SortTransactionsByAmount()
    {
        transactions = transactions.OrderByDescending(t => t.Amount).ToList();
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        FinanceTracker tracker = new FinanceTracker();
        FileManager fileManager = new FileManager();

        string transactionFile = "transactions.txt";
        string budgetFile = "budgets.txt";

        // Load existing data
        List<Transaction> loadedTransactions = fileManager.LoadTransactions(transactionFile);
        foreach (Transaction transaction in loadedTransactions)
        {
            tracker.AddTransaction(transaction);
        }

        List<BudgetCategory> loadedBudgets = fileManager.LoadBudgets(budgetFile);
        foreach (BudgetCategory budget in loadedBudgets)
        {
            tracker.GetBudgets().Add(budget);
        }

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
            Console.WriteLine("7. Add Budget");
            Console.WriteLine("8. Check Budgets");
            Console.WriteLine("9. Save Data");
            Console.WriteLine("10. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddIncome(tracker);
                    break;
                case "2":
                    AddExpense(tracker);
                    break;
                case "3":
                    tracker.DisplayAllTransactions();
                    break;
                case "4":
                    tracker.DisplaySummary();
                    break;
                case "5":
                    tracker.SortTransactionsByDate();
                    Console.WriteLine("Transactions sorted by date.");
                    break;
                case "6":
                    tracker.SortTransactionsByAmount();
                    Console.WriteLine("Transactions sorted by amount.");
                    break;
                case "7":
                    AddBudget(tracker);
                    break;
                case "8":
                    tracker.CheckBudgets();
                    break;
                case "9":
                    fileManager.SaveTransactions(transactionFile, tracker.GetTransactions());
                    fileManager.SaveBudgets(budgetFile, tracker.GetBudgets());
                    Console.WriteLine("Data saved successfully.");
                    break;
                case "10":
                    fileManager.SaveTransactions(transactionFile, tracker.GetTransactions());
                    fileManager.SaveBudgets(budgetFile, tracker.GetBudgets());
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AddIncome(FinanceTracker tracker)
    {
        Console.Write("Enter amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter source: ");
        string source = Console.ReadLine();

        tracker.AddTransaction(new IncomeTransaction(
            tracker.GetNextId(),
            DateTime.Now,
            amount,
            category,
            description,
            source
        ));

        Console.WriteLine("Income added.");
    }

    static void AddExpense(FinanceTracker tracker)
    {
        Console.Write("Enter amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter payment method: ");
        string paymentMethod = Console.ReadLine();

        tracker.AddTransaction(new ExpenseTransaction(
            tracker.GetNextId(),
            DateTime.Now,
            amount,
            category,
            description,
            paymentMethod
        ));

        Console.WriteLine("Expense added.");
    }

    static void AddBudget(FinanceTracker tracker)
    {
        Console.Write("Enter budget category: ");
        string category = Console.ReadLine();

        Console.Write("Enter spending limit: ");
        decimal limit = decimal.Parse(Console.ReadLine());

        tracker.AddBudget(category, limit);
        Console.WriteLine("Budget added.");
    }
}
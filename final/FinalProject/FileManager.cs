using System;
using System.Collections.Generic;
using System.IO;

public class FileManager
{
    public void SaveTransactions(string fileName, List<Transaction> transactions)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Transaction transaction in transactions)
            {
                writer.WriteLine(transaction.ToFileString());
            }
        }
    }

    public List<Transaction> LoadTransactions(string fileName)
    {
        List<Transaction> transactions = new List<Transaction>();

        if (!File.Exists(fileName))
        {
            return transactions;
        }

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            string type = parts[0];
            int id = int.Parse(parts[1]);
            DateTime date = DateTime.Parse(parts[2]);
            decimal amount = decimal.Parse(parts[3]);
            string category = parts[4];
            string description = parts[5];

            if (type == "Income")
            {
                string source = parts[6];
                transactions.Add(new IncomeTransaction(id, date, amount, category, description, source));
            }
            else if (type == "Expense")
            {
                string paymentMethod = parts[6];
                transactions.Add(new ExpenseTransaction(id, date, amount, category, description, paymentMethod));
            }
        }

        return transactions;
    }

    public void SaveBudgets(string fileName, List<BudgetCategory> budgets)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (BudgetCategory budget in budgets)
            {
                writer.WriteLine(budget.ToFileString());
            }
        }
    }

    public List<BudgetCategory> LoadBudgets(string fileName)
    {
        List<BudgetCategory> budgets = new List<BudgetCategory>();

        if (!File.Exists(fileName))
        {
            return budgets;
        }

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            string name = parts[0];
            decimal limit = decimal.Parse(parts[1]);

            budgets.Add(new BudgetCategory(name, limit));
        }

        return budgets;
    }
}
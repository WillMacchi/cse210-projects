using System;
using System.Collections.Generic;
using System.Linq;

public class FinanceTracker
{
    private List<Transaction> _transactions = new List<Transaction>();
    private List<BudgetCategory> _budgets = new List<BudgetCategory>();
    private int _nextId = 1;

    public List<Transaction> GetTransactions()
    {
        return _transactions;
    }

    public List<BudgetCategory> GetBudgets()
    {
        return _budgets;
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        _nextId++;
    }

    public int GetNextId()
    {
        return _nextId;
    }

    public void SetNextId(int nextId)
    {
        _nextId = nextId;
    }

    public decimal GetTotalIncome()
    {
        return _transactions
            .Where(t => t is IncomeTransaction)
            .Sum(t => t.Amount);
    }

    public decimal GetTotalExpenses()
    {
        return _transactions
            .Where(t => t is ExpenseTransaction)
            .Sum(t => t.Amount);
    }

    public decimal GetBalance()
    {
        return GetTotalIncome() - GetTotalExpenses();
    }

    public void DisplayAllTransactions()
    {
        if (_transactions.Count == 0)
        {
            Console.WriteLine("No transactions found.");
            return;
        }

        foreach (Transaction transaction in _transactions)
        {
            Console.WriteLine(transaction.GetSummary());
        }
    }

    public void SortTransactionsByDate()
    {
        _transactions = _transactions.OrderBy(t => t.Date).ToList();
    }

    public void SortTransactionsByAmount()
    {
        _transactions = _transactions.OrderByDescending(t => t.Amount).ToList();
    }

    public void AddBudget(string name, decimal limit)
    {
        _budgets.Add(new BudgetCategory(name, limit));
    }

    public decimal GetSpentByCategory(string category)
    {
        return _transactions
            .Where(t => t is ExpenseTransaction && t.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .Sum(t => t.Amount);
    }

    public void CheckBudgets()
    {
        if (_budgets.Count == 0)
        {
            Console.WriteLine("No budgets set.");
            return;
        }

        foreach (BudgetCategory budget in _budgets)
        {
            decimal spent = GetSpentByCategory(budget.Name);
            Console.WriteLine(budget.GetSummary(spent));
        }
    }

    public void DisplaySummary()
    {
        Console.WriteLine("\n--- Financial Summary ---");
        Console.WriteLine($"Total Income:   ${GetTotalIncome():F2}");
        Console.WriteLine($"Total Expenses: ${GetTotalExpenses():F2}");
        Console.WriteLine($"Balance:        ${GetBalance():F2}");
    }
}
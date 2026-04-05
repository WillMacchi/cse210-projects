public class BudgetCategory
{
    public string Name { get; set; }
    public decimal Limit { get; set; }

    public BudgetCategory(string name, decimal limit)
    {
        Name = name;
        Limit = limit;
    }

    public bool IsOverBudget(decimal spent)
    {
        return spent > Limit;
    }

    public string GetSummary(decimal spent)
    {
        string status = IsOverBudget(spent) ? "OVER BUDGET" : "Within Budget";
        return $"{Name}: Spent ${spent:F2} / Limit ${Limit:F2} - {status}";
    }

    public string ToFileString()
    {
        return $"{Name}|{Limit}";
    }
}
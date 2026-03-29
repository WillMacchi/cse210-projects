public class IncomeTransaction : Transaction
{
    public string Source { get; set; }

    public IncomeTransaction(int id, DateTime date, decimal amount, string category, string description, string source)
        : base(id, date, amount, category, description)
    {
        Source = source;
    }

    public override string GetTransactionType()
    {
        return "Income";
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" | Source: {Source}";
    }

    public override string ToFileString()
    {
        return $"{GetTransactionType()}|{Id}|{Date}|{Amount}|{Category}|{Description}|{Source}";
    }
}
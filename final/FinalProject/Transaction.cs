public abstract class Transaction
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }

    public Transaction(int id, DateTime date, decimal amount, string category, string description)
    {
        Id = id;
        Date = date;
        Amount = amount;
        Category = category;
        Description = description;
    }

    public abstract string GetTransactionType();

    public virtual string GetSummary()
    {
        return $"{Id} | {Date.ToShortDateString()} | {GetTransactionType()} | {Category} | ${Amount:F2} | {Description}";
    }

    public virtual string ToFileString()
    {
        return $"{GetTransactionType()}|{Id}|{Date}|{Amount}|{Category}|{Description}";
    }
}
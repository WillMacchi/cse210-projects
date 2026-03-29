public class ExpenseTransaction : Transaction
{
    public string PaymentMethod { get; set; }

    public ExpenseTransaction(int id, DateTime date, decimal amount, string category, string description, string paymentMethod)
        : base(id, date, amount, category, description)
    {
        PaymentMethod = paymentMethod;
    }

    public override string GetTransactionType()
    {
        return "Expense";
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" | Payment: {PaymentMethod}";
    }

    public override string ToFileString()
    {
        return $"{GetTransactionType()}|{Id}|{Date}|{Amount}|{Category}|{Description}|{PaymentMethod}";
    }
}
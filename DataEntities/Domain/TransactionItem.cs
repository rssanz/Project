namespace Data.Domain
{ 
    public class TransactionItem
    {
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public TransactionItem(string sku, decimal amount, string currency)
        {
            Sku = sku;
            Amount = amount;
            Currency = currency;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Sku, Amount, Currency);
        }
    }
}

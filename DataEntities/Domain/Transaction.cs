namespace DataEntities.Domain
{ 
    public class Transaction : Entity
    {
        public int TransactionId { get; set; }
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public Transaction() { }

        public Transaction(string sku, decimal amount, string currency)
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

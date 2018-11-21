namespace DataEntities.Domain
{
    public class Rate : Entity
    {
        public int RateId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Ratio { get; set; }

        public Rate() { }

        public Rate(string from, string to, double ratio)
        {
            From = from;
            To = to;
            Ratio = ratio;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", From, To, Ratio);
        }
    }
}

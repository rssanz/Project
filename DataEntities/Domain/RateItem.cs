namespace Data.Domain
{
    public class RateItem
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Rate { get; set; }

        public RateItem(string from, string to, double rate)
        {
            From = from;
            To = to;
            Rate = rate;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", From, To, Rate);
        }
    }
}

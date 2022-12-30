using System;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShare)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShare;
            MarketCapitalization = PricePerShare * TotalNumberOfShares;
        }
        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        private string director;
        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        private decimal pricePerShare;
        public decimal PricePerShare
        {
            get { return pricePerShare; }
            set { pricePerShare = value; }
        }

        private int totalNumberOfShares;
        public int TotalNumberOfShares
        {
            get { return totalNumberOfShares; }
            set { totalNumberOfShares = value; }
        }

        private decimal marketCapitalization;
        public decimal MarketCapitalization
        {
            get { return marketCapitalization; }
            set { marketCapitalization = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Company: {CompanyName}");
            result.AppendLine($"Director: {Director}");
            result.AppendLine($"Price per share: ${PricePerShare}");
            result.AppendLine($"Market capitalization: ${MarketCapitalization}");

            return result.ToString().Trim();
        }
    }
}

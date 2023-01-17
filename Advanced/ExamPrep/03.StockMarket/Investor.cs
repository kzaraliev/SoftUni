using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        public Investor(string fullNmae, string emailAddres, decimal moneyToInvest, string brokerName)
        {
            portfolio = new List<Stock>();
            FullName = fullNmae;
            EmailAddress = emailAddres;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private decimal moneyToInvest;
        public decimal MoneyToInvest
        {
            get { return moneyToInvest; }
            set { moneyToInvest = value; }
        }

        private string brokerName;

        public string BrokerName
        {
            get { return brokerName; }
            set { brokerName = value; }
        }

        public int Count { get { return portfolio.Count; } }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            portfolio.Remove(stock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            Stock stock = portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            return stock;
        }

        public Stock FindBiggestCompany()
        {
            if (portfolio.Count == 0)
            {
                return null;
            }

            List<Stock> sortedList = portfolio.OrderBy(s => s.MarketCapitalization).ToList();

            return sortedList[sortedList.Count-1];
        }

        public string InvestorInformation()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The investor {fullName} with a broker {brokerName} has stocks:");

            foreach (var stock in portfolio)
            {
                result.AppendLine(stock.ToString());
            }

            return result.ToString().Trim();
        }
    }
}

using System.Collections.Generic;

namespace BitcoinWalletManagementSystem
{
    public class User
    {
        public User()
        {
            Wallets = new List<Wallet>();
            Transactions = new List<Transaction>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Wallet> Wallets { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
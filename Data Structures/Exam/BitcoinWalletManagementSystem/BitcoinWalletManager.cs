using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManagementSystem
{
    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Wallet> wallets = new Dictionary<string, Wallet>();

        public void CreateUser(User user)
        {
            users.Add(user.Id, user);
        }

        public void CreateWallet(Wallet wallet)
        {
            wallet.User = users[wallet.UserId];
            wallets.Add(wallet.Id, wallet);

            users[wallet.UserId].Wallets.Add(wallet);
        }

        public bool ContainsUser(User user)
        {
            return users.ContainsKey(user.Id);
        }

        public bool ContainsWallet(Wallet wallet)
        {
            return wallets.ContainsKey(wallet.Id);
        }

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
        {
            return users[userId].Wallets;
        }

        public void PerformTransaction(Transaction transaction)
        {
            var receiverWalletId = transaction.ReceiverWalletId;
            var senderWalletId = transaction.SenderWalletId;
            var transactionAmount = transaction.Amount;

            if (!wallets.ContainsKey(receiverWalletId) || !wallets.ContainsKey(senderWalletId) || wallets[senderWalletId].Balance < transactionAmount)
            {
                throw new ArgumentException();
            }

            wallets[senderWalletId].Balance -= transactionAmount;
            wallets[receiverWalletId].Balance += transactionAmount;
            users[wallets[senderWalletId].UserId].Transactions.Add(transaction);
            users[wallets[receiverWalletId].UserId].Transactions.Add(transaction);
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
        {
            return users[userId].Transactions;
        }

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
        {
            return wallets
                .Select(w => w.Value)
                .OrderByDescending(w => w.Balance);
        }

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
        {
            return users
                .Select(u => u.Value)
                .OrderByDescending(u => u.Wallets.Select(w => w.Balance).Sum());
        }

        public IEnumerable<User> GetUsersByTransactionCount()
        {
            return users
                .Select(u => u.Value)
                .OrderByDescending(u => u.Transactions.Count);
        }
    }
}
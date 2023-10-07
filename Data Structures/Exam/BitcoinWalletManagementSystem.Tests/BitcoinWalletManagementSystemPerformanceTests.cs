using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using BitcoinWalletManagementSystem;

namespace BitcoinWalletManagementSystem.Tests
{
    public class BitcoinWalletManagementSystemPerformanceTests
    {
        private IBitcoinWalletManager _walletManager;

        [SetUp]
        public void Setup()
        {
            this._walletManager = new BitcoinWalletManager();
        }
        
        [Test]
        public void ContainsUsers_ShouldPassQuickly_With1000000Users()
        {
            // Arrange
            var targetUser = null as User;
            for (int i = 0; i < 1000000; i++)
            {
                var user = new User { Id = Guid.NewGuid().ToString() };
                this._walletManager.CreateUser(user);

                if (i == 500000)
                {
                    targetUser = user;
                }
            }

            // Act
            var sw = new Stopwatch();
            
            sw.Start();

            var result = this._walletManager.ContainsUser(targetUser);
            
            sw.Stop();

            // Assert
            Assert.True(result);
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
        }
        
        [Test]
        public void ContainsWallet_ShouldPassQuickly_With1000000Wallets()
        {
            // Arrange
            var user = new User { Id = Guid.NewGuid().ToString() };
            this._walletManager.CreateUser(user);

            var targetWallet = null as Wallet;
            for (int i = 0; i < 1000000; i++)
            {
                var wallet = new Wallet { Id = Guid.NewGuid().ToString(), Balance = 1000, UserId = user.Id };

                this._walletManager.CreateWallet(wallet);

                if (i == 500000)
                {
                    targetWallet = wallet;
                }
            }

            // Act
            var sw = new Stopwatch();
            
            sw.Start();

            var result = this._walletManager.ContainsWallet(targetWallet);
            
            sw.Stop();

            // Assert
            Assert.True(result);
            Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
        }
        
        [Test]
        public void GetTransactionsByUser_ShouldPassQuickly()
        {
            // Arrange
            var wallets = new List<Wallet>();
            var userByWalletId = new Dictionary<string, string>();
            var transactionsCountByUserId = new Dictionary<string, int>();
            
            for (int i = 0; i < 5; i++)
            {
                var user = new User
                {
                    Id = Guid.NewGuid().ToString(),
                };

                var wallet = new Wallet
                {
                    Balance = 100000,
                    UserId = user.Id,
                    Id = Guid.NewGuid().ToString(),
                };
                
                this._walletManager.CreateUser(user);
                this._walletManager.CreateWallet(wallet);
                
                wallets.Add(wallet);
                userByWalletId[wallet.Id] = user.Id;
            }

            var random = new Random();
            for (int i = 0; i < 10000000; i++)
            {
                var sender = wallets[random.Next(0, wallets.Count)];
                var receiver = wallets[random.Next(0, wallets.Count)];

                var transaction = new Transaction
                {
                    SenderWalletId = sender.Id,
                    ReceiverWalletId = receiver.Id,
                    Id = Guid.NewGuid().ToString(),
                    Amount = 1,
                    Timestamp = DateTime.Now,
                };
                
                this._walletManager.PerformTransaction(transaction);

                var senderUserId = userByWalletId[sender.Id];
                var receiverUserId = userByWalletId[receiver.Id];

                transactionsCountByUserId[senderUserId] = transactionsCountByUserId.ContainsKey(senderUserId)
                    ? transactionsCountByUserId[senderUserId] + 1
                    : 1;

                transactionsCountByUserId[receiverUserId] = transactionsCountByUserId.ContainsKey(receiverUserId)
                    ? transactionsCountByUserId[receiverUserId] + 1
                    : 1;
            }

            foreach (var kvp in transactionsCountByUserId)
            {
                var sw = new Stopwatch();
            
                sw.Start();

                // Act
                var result = this._walletManager.GetTransactionsByUser(kvp.Key);
            
                sw.Stop();
                
                Assert.That(sw.ElapsedMilliseconds, Is.LessThanOrEqualTo(10));
                Assert.That(result.Count(), Is.EqualTo(kvp.Value));
            }
        }
    }
}
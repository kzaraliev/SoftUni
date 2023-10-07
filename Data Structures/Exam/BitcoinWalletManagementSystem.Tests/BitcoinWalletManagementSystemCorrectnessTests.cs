using System;
using System.Collections.Generic;
using NUnit.Framework;
using BitcoinWalletManagementSystem;

namespace BitcoinWalletManagementSystem.Tests
{
    public class BitcoinWalletManagementSystemCorrectnessTests
    {
        private IBitcoinWalletManager _walletManager;

        [SetUp]
        public void Setup()
        {
            this._walletManager = new BitcoinWalletManager();
        }
        
        [Test]
        public void CreateUser_AddsUser()
        {
            // Arrange
            var user = new User { Id = "user1" };

            // Act
            this._walletManager.CreateUser(user);

            // Assert
            Assert.IsTrue(this._walletManager.ContainsUser(user));
        }
        
        [Test]
        public void CreateWallet_AddsWallet()
        {
            // Arrange
            var user = new User { Id = "user1" };
            var wallet = new Wallet { Id = "wallet1", UserId = "user1"};

            // Act
            this._walletManager.CreateUser(user);
            this._walletManager.CreateWallet(wallet);

            // Assert
            Assert.IsTrue(this._walletManager.ContainsWallet(wallet));
        }
        
        [Test]
        public void GetWalletsByUser_ReturnsOnlyWalletsAssociatedWithUserId()
        {
            // Arrange
            var user1 = new User { Id = "user1" };
            var user2 = new User { Id = "user2" };
            
            this._walletManager.CreateUser(user1);
            var user1Wallets = new List<Wallet>();
            for (int i = 0; i < 5; i++)
            {
                var wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user1.Id};

                this._walletManager.CreateWallet(wallet);
                user1Wallets.Add(wallet);
            }
            
            this._walletManager.CreateUser(user2);
            for (int i = 0; i < 3; i++)
            {
                var wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user2.Id};

                this._walletManager.CreateWallet(wallet);
            }
            
            // Act
            var wallets = this._walletManager.GetWalletsByUser(user1.Id);

            // Assert
            Assert.That(wallets, Is.EquivalentTo(user1Wallets));
        }
        
        [Test]
        public void GetTransactionsByUser_ReturnsOnlyTransactionsAssociatedWithUserId()
        {
            // Arrange
            var user1 = new User { Id = "user1" };
            var user2 = new User { Id = "user2" };
            var user3 = new User { Id = "user3" };

            this._walletManager.CreateUser(user1);
            this._walletManager.CreateUser(user2);
            this._walletManager.CreateUser(user3);

            var user1Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user1.Id, Balance = 1000 };
            var user2Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user2.Id, Balance = 1000 };
            var user3Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user3.Id, Balance = 1000 };
            
            this._walletManager.CreateWallet(user1Wallet);
            this._walletManager.CreateWallet(user2Wallet);
            this._walletManager.CreateWallet(user3Wallet);

            var transaction1 = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user1Wallet.Id,
                ReceiverWalletId = user2Wallet.Id,
                Amount = 100,
                Timestamp = DateTime.Now,
            };

            var transaction2 = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user1Wallet.Id,
                ReceiverWalletId = user3Wallet.Id,
                Amount = 100,
                Timestamp = DateTime.Now,
            };

            this._walletManager.PerformTransaction(transaction1);
            this._walletManager.PerformTransaction(transaction2);

            // Act
            var user1Transactions = this._walletManager.GetTransactionsByUser(user1.Id);
            var user2Transactions = this._walletManager.GetTransactionsByUser(user2.Id);
            var user3Transactions = this._walletManager.GetTransactionsByUser(user3.Id);

            // Assert
            Assert.That(user1Transactions, Is.EquivalentTo(new List<Transaction> { transaction1, transaction2 }));
            Assert.That(user2Transactions, Is.EquivalentTo(new List<Transaction> { transaction1 }));
            Assert.That(user3Transactions, Is.EquivalentTo(new List<Transaction> { transaction2 }));
        }
        
        [Test]
        public void GetWalletsSortedByBalanceDescending_ShouldReturnWalletsOrderedByBalanceInDescendingOrder()
        {
            // Arrange
            var user1 = new User { Id = "user1" };
            var user2 = new User { Id = "user2" };
            var user3 = new User { Id = "user3" };

            this._walletManager.CreateUser(user1);
            this._walletManager.CreateUser(user2);
            this._walletManager.CreateUser(user3);

            var user1Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user1.Id, Balance = 100 };
            var user2Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user2.Id, Balance = 50 };
            var user3Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user3.Id, Balance = 65 };
            
            this._walletManager.CreateWallet(user1Wallet);
            this._walletManager.CreateWallet(user2Wallet);
            this._walletManager.CreateWallet(user3Wallet);

            // Act
            var wallets = this._walletManager.GetWalletsSortedByBalanceDescending();

            // Assert
            Assert.That(wallets, Is.EquivalentTo(new List<Wallet> { user1Wallet, user3Wallet, user2Wallet  }));
        }
        
        [Test]
        public void GetUsersSortedByBalanceDescending_ShouldReturnUsersOrderedByBalanceInDescendingOrder()
        {
            // Arrange
            var user1 = new User { Id = "user1" };
            var user2 = new User { Id = "user2" };

            this._walletManager.CreateUser(user1);
            this._walletManager.CreateUser(user2);

            var user1Wallet1 = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user1.Id, Balance = 100 };
            var user1Wallet2 = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user1.Id, Balance = 100 };
            var user2Wallet1 = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user2.Id, Balance = 200 };
            var user2Wallet2 = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user2.Id, Balance = 50 };
            
            this._walletManager.CreateWallet(user1Wallet1);
            this._walletManager.CreateWallet(user1Wallet2);
            this._walletManager.CreateWallet(user2Wallet1);
            this._walletManager.CreateWallet(user2Wallet2);

            // Act
            var users = this._walletManager.GetUsersSortedByBalanceDescending();

            // Assert
            Assert.That(users, Is.EquivalentTo(new List<User> { user2, user1 }));
        }
        
        [Test]
        public void GetUsersByTransactionCount_ShouldReturnUsersOrderedByTransactionsInDescendingOrder()
        {
            // Arrange
            var user1 = new User { Id = "user1" };
            var user2 = new User { Id = "user2" };
            var user3 = new User { Id = "user3" };

            this._walletManager.CreateUser(user1);
            this._walletManager.CreateUser(user2);
            this._walletManager.CreateUser(user3);

            var user1Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user1.Id, Balance = 1000 };
            var user2Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user2.Id, Balance = 1000 };
            var user3Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user3.Id, Balance = 1000 };

            this._walletManager.CreateWallet(user1Wallet);
            this._walletManager.CreateWallet(user2Wallet);
            this._walletManager.CreateWallet(user3Wallet);
            
            this._walletManager.PerformTransaction(new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user1Wallet.Id,
                ReceiverWalletId = user2Wallet.Id,
                Amount = 100,
                Timestamp = DateTime.Now,
            });
            
            this._walletManager.PerformTransaction(new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user1Wallet.Id,
                ReceiverWalletId = user2Wallet.Id,
                Amount = 100,
                Timestamp = DateTime.Now,
            });

            this._walletManager.PerformTransaction(new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user1Wallet.Id,
                ReceiverWalletId = user2Wallet.Id,
                Amount = 100,
                Timestamp = DateTime.Now,
            });

            this._walletManager.PerformTransaction(new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user2Wallet.Id,
                ReceiverWalletId = user3Wallet.Id,
                Amount = 100,
                Timestamp = DateTime.Now,
            });
            
            // Act
            var users = this._walletManager.GetUsersByTransactionCount();

            // Assert
            Assert.That(users, Is.EquivalentTo(new List<User> { user2, user1, user3 }));
        }
    }
}
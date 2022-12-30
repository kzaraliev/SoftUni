using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        //AddItem Method

        [Test]
        public void CantAddValueOnUnexistingCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123");

            Assert.Throws<ArgumentException>(() => { bankVault.AddItem(":)", item); });
        }

        [Test]
        public void BankVaultIsAlreadyTaken()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123");
            Item item2 = new Item("Gosho", "321");

            bankVault.AddItem("A1",item2);
            Assert.Throws<ArgumentException>(() => { bankVault.AddItem("A1", item); });
        }

        [Test]
        public void AlreadyExistingItem()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123");
            Item item2 = new Item("Gosho", "123");

            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => { bankVault.AddItem("A2", item2); });
        }

        [Test]
        public void AddinCorrectlyItem()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123");

            bankVault.AddItem("A1", item);
            Assert.AreEqual(bankVault.VaultCells["A1"].ItemId, item.ItemId);
        }

        //Remove Item
        [Test]
        public void CantRemoveFromUnexistingCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123");

            Assert.Throws<ArgumentException>(() => { bankVault.RemoveItem(":)", item); });
        }

        [Test]
        public void ItemDontExistInCurrentCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123");
            bankVault.AddItem("A1", item);
            Item item1 = new Item("Goshow", "321");

            Assert.Throws<ArgumentException>(() => { bankVault.AddItem("A1", item1); });
        }

        [Test]
        public void RemoveWorkCorrectly()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123");
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);

            Assert.AreEqual(bankVault.VaultCells["A1"], null);
        }
    }
}
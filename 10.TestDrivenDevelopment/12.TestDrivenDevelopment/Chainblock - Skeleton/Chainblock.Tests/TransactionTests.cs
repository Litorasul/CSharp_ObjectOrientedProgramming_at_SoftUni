using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    class TransactionTests
    {
        private ITransaction transaction;

        [SetUp]
        public void TransactionTestSetup()
        {
            transaction = new Transaction
                (222, "Pesho", "Gosho", 222.22, "Successfull");
        }

        [Test]
        public void TestTransactionConstructorCorrectly()
        {
            int expectedId = 222;
            int actualId = this.transaction.Id;

            Assert.That(actualId, Is.EqualTo(expectedId));
        }

        [Test]
        public void TestConstructorByTransactionStatus()
        {
            TransactionStatus expectedStatus = TransactionStatus.Successfull;
            TransactionStatus actualStatus = this.transaction.Status;

            Assert.That(actualStatus, Is.EqualTo(expectedStatus));
        }

        [Test]
        public void TestTransactionWithNegativeAmount()
        {
            Assert.That(() => new Transaction
                (222, "Pesho", "Gosho", -222.22, "Successfull"), 
                Throws.ArgumentException.With.Message
                    .EqualTo("Transaction amount can not be negative"));
        }

        [Test]
        public void TestCompareTo()
        {
            int expected = 0;
            var transactionTwo = new Transaction
                (221, "Pesho", "Gosho", 222.22, "Successfull");

            int actual = this.transaction.CompareTo(transactionTwo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

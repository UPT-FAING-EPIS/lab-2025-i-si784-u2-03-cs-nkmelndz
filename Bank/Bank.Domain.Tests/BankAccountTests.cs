using Bank.Domain;
using NUnit.Framework;

namespace Bank.Domain.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, e.Message);
            }
        }
        [Test]
        public void Credit_WhenAmountIsMoreThanZero_ShouldIncreaseBalance()
        {
            // Arrange
            double beginningBalance = 100.0;
            double creditAmount = 50.0;
            double expectedBalance = 150.0;
            BankAccount account = new BankAccount("Test User", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [Test]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 100.0;
            double creditAmount = -10.0;
            BankAccount account = new BankAccount("Test User", beginningBalance);

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
            StringAssert.Contains("amount", ex.ParamName);
        }

    }
}
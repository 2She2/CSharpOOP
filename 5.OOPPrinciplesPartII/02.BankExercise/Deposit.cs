// Deposit accounts have no interest if their balance is positive and less than 1000.

namespace _02.BankExercise
{
    using System;

    /// <summary>
    /// Represent a bank deposit. Inherit abstract class "Account" and interfaces "IWithdrawable" and "IDepositable"
    /// </summary>
    public class Deposit : Account, IWithdrawable, IDepositable
    {
        // Given requirements. Better set it as constants, so we can easly change it. Do not use magic numbers, this is bad :)
        private const decimal NoInterestMinBalance = 0;
        private const decimal NoInterestMaxBalance = 1000;

        /// <summary>
        /// Only constructor. Initialize all fields
        /// </summary>
        /// <param name="customer">Name of customer</param>
        /// <param name="balance">Account balance</param>
        /// <param name="interestRate">Account interest</param>
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) // call constructor from the base class
        {
        }

        /// <summary>
        /// Withdraw money from account
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        public void Withdraw(decimal amount)
        {
            base.Balance -= amount;
        }

        /// <summary>
        /// Calculate account interest for given period of months
        /// </summary>
        /// <param name="months">Period in months</param>
        /// <returns>Account interest</returns>
        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0;

            // Only if the given requirements are not met, we calculate interest
            if (base.Balance < NoInterestMinBalance || base.Balance >= NoInterestMaxBalance)
            {
                interest = base.Balance * months * base.InterestRate / 100;
            }

            return interest;
        }
    }
}

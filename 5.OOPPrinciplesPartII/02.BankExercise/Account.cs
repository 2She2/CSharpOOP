// All accounts have customer, balance and interest rate (monthly based).
// Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money.
// All accounts can calculate their interest amount for a given period (in months).
// In the common case its is calculated as follows: number_of_months * interest_rate.


namespace _02.BankExercise
{
    using System;

    /// <summary>
    /// Represent a bank account. Abstract class, can't maki instances of it
    /// </summary>
    public abstract class Account : IDepositable
    {
        // Needed fields
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        /// <summary>
        /// Only constructor. Initialize all fields
        /// </summary>
        /// <param name="customer">Customer account</param>
        /// <param name="balance">Account balance</param>
        /// <param name="interestRate">Account interest</param>
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        /// <summary>
        /// Get balance
        /// </summary>
        public decimal Balance
        {
            get { return this.balance; }
            protected set { this.balance = value; }
        }

        /// <summary>
        /// Get interest rate
        /// </summary>
        public decimal InterestRate
        {
            get { return this.interestRate; }
            private set { this.interestRate = value; }
        }

        /// <summary>
        /// Deposit amount to the account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        /// <summary>
        /// Get customer
        /// </summary>
        public Customer Customer
        {
            get { return this.customer; }
            private set { this.customer = value; }
        }

        /// <summary>
        /// Claculate interest for a period of months
        /// </summary>
        /// <param name="months"></param>
        /// <returns>Interest for given period of months</returns>
        public virtual decimal CalculateInterest(int months)
        {
            return this.InterestRate * months;
        }
    }
}

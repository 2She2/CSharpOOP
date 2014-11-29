namespace _02.BankExercise
{
    using System;

    /// <summary>
    /// Account that we want to deposit, must implement this interface
    /// </summary>
    public interface IDepositable
    {
        /// <summary>
        /// Deposit money from account. Only method of the interface
        /// </summary>
        /// <param name="amount">Amount of money</param>
        void Deposit(decimal amount);
    }
}

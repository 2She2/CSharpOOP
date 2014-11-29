namespace _02.BankExercise
{
    using System;

    /// <summary>
    /// Account that we want to withdraw, must implement this interface
    /// </summary>
    public interface IWithdrawable
    {
        /// <summary>
        /// Withdraw money from account. Only method of the interface
        /// </summary>
        /// <param name="amount">Amount of money</param>
        void Withdraw(decimal amount);
    }
}

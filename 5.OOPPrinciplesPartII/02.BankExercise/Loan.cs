// Loan accounts have no interest for the first 3 months if are held by individuals
// and for the first 2 months if are held by a company.

namespace _02.BankExercise
{
    using System;

    /// <summary>
    /// Represent a bank loan. Inherit abstract class "Account" and interfaces "IDepositable"
    /// </summary>
    public class Loan : Account, IDepositable
    {
        // Given requirements. Better set it as constants, so we can easly change it. Do not use magic numbers, this is bad :)
        private const int IndividualGratisMonths = 3;
        private const int CompanyGratisMonths = 2;

        /// <summary>
        /// Only constructor. Initialize all fields
        /// </summary>
        /// <param name="customer">Name of customer</param>
        /// <param name="balance">Account balance</param>
        /// <param name="interestRate">Account interest</param>
        public Loan(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) // call constructor from the base class
        {
        }

        /// <summary>
        /// Calculate account interest for given period of months
        /// </summary>
        /// <param name="months">Period in months</param>
        /// <returns>Account interest</returns>
        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0;

            // Calculate different interest for "Individual" and "Company" as required
            if (base.Customer is Individual)
            {
                // If given period to calculate interest is less than gratis period, 0 is returned
                if (months > IndividualGratisMonths)
                {
                    interest = base.Balance * (months - IndividualGratisMonths) * base.InterestRate / 100;
                }
            }
            else if (base.Customer is Company)
            {
                if (months > CompanyGratisMonths)
                {
                    interest = base.Balance * (months - CompanyGratisMonths) * base.InterestRate / 100;
                }
            }

            return interest;
        }
    }
}

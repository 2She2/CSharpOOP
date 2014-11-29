/* 02. A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts.
 * Customers could be individuals or companies.
 * All accounts have customer, balance and interest rate (monthly based).
 * Deposit accounts are allowed to deposit and with draw money.
 * Loan and mortgage accounts can only deposit money.
*/

// In folder with the other files, there is a class "InterestCalculator"(it is not added here), to calculate all interests,
// but it doesn't look like a good idea to me!

namespace _02.BankExercise
{
    using System;

    class BankExercise
    {
        static void Main()
        {
            // Make some accounts to check if loans, deposits and mortgages are calculated properly
            Deposit individualDeposit = new Deposit(new Individual("Pesho Peshev", "Sofia", 7607214368), 16500M, 3.5M);
            Deposit companyDeposit = new Deposit(new Company("MacroSoft", "Varna", "SomeIban1"), 16500M, 3.5M);

            Loan individualLoan = new Loan(new Individual("Gosho Goshev", "Plovdiv", 7906145685), 5890M, 5.6M);
            Loan companyLoan = new Loan(new Company("Software Ltd", "Burgas", "SomeIban2"), 5890M, 5.6M);

            Mortgage individualMortgage = new Mortgage(new Individual("Sasho Sashev", "Pleven", 8311045389), 67500M, 3M);
            Mortgage companyMortgage = new Mortgage(new Company("Hardware Ltd", "Ruse", "SomeIban3"), 67500M, 3M);

            // Compare different accounts for individual and company
            Console.WriteLine("Individual Deposit: {0}".PadLeft(25), individualDeposit.CalculateInterest(12));
            Console.WriteLine("Company Deposit: {0}".PadLeft(25), companyDeposit.CalculateInterest(12));
            Console.WriteLine();
            Console.WriteLine("Individual Loan: {0}".PadLeft(25), individualLoan.CalculateInterest(12));
            Console.WriteLine("Company Loan: {0}".PadLeft(25), companyLoan.CalculateInterest(12));
            Console.WriteLine();
            Console.WriteLine("Individual Mortgage: {0}".PadLeft(25), individualMortgage.CalculateInterest(12));
            Console.WriteLine("Company Mortgage: {0}".PadLeft(25), companyMortgage.CalculateInterest(12));
        }
    }
}

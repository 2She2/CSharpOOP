namespace _02.BankExercise
{
    using System;

    public static class InterestCalculator
    {
        public static decimal CalculateInterest(this Account account, int months)
        {
            decimal interest = 0; // account.Balance * account.InterestRate * months;

            if (months < 0)
            {
                throw new ArgumentException("Months can't be less than 0");
            }

            if (account is Loan)
            {
                interest = CalcLoanInterest(account, months);
            }
            else if (account is Deposit)
            {
                interest = CalcDepositInterest(account, months);
            }
            else if (account is Mortgage)
            {
                interest = CalcMortgageInterest(account, months);
            }

            return interest;
        }

        private static decimal CalcLoanInterest(Account account, int months)
        {
            decimal interest = 0;

            if (account.Customer is Individual)
            {
                if (months > 3)
                {
                    interest = account.Balance * (months - 3) * account.InterestRate / 100;
                }
            }
            else if (account.Customer is Company)
            {
                if (months > 2)
                {
                    interest = account.Balance * (months - 2) * account.InterestRate / 100;
                }
            }

            return interest;
        }

        private static decimal CalcDepositInterest(Account account, int months)
        {
            decimal interest = 0;

            if (account.Balance < 0 || account.Balance >= 1000)
            {
                interest = account.Balance * months * account.InterestRate / 100;
            }

            return interest;
        }

        private static decimal CalcMortgageInterest(Account account, int months)
        {
            decimal interest = 0;

            if (account.Customer is Individual)
            {
                if (months > 6)
                {
                    interest = account.Balance * (months - 6) * account.InterestRate / 100;
                }
            }
            else if (account.Customer is Company)
            {
                if (months <= 12)
                {
                    interest = 0.5M * account.Balance * months;
                }
                else
                {
                    interest = (account.Balance * 12M * 0.5M) + account.Balance * ((months - 12M) * account.InterestRate / 100);
                }
            }

            return interest;
        }
    }
}

namespace _02.BankExercise
{
    using System;

    /// <summary>
    /// Represent a company. Inherit abstract class "Customer"
    /// </summary>
    public class Company : Customer
    {
        /// <summary>
        /// Only constructor. Initialize all fields
        /// </summary>
        /// <param name="name">Name of company</param>
        /// <param name="address">Address of company</param>
        /// <param name="iban">Iban of company</param>
        public Company(string name, string address, string iban)
            : base(name, address) // call constructor from the base class
        {
            this.Iban = iban;
        }

        /// <summary>
        /// Ger Iban of company
        /// </summary>
        public string Iban { get; private set; }
    }
}

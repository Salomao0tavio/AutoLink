using Models.CreateModels;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public List<Rental>? Rentals { get; set; }

        private Customer()
        {
            Rentals = new List<Rental>();
        }

        public Customer(string name, string cpf, string email, string phone)
            : this()
        {
            ID = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            CPF = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }

        internal static Customer Parse(CustomerCreateModel customer)
        {
            Customer Customer = new Customer
            {
                CPF = customer.CPF,
                Email = customer.Email,
                Phone = customer.Phone,
                Name = customer.Name,
                Rentals = null
            };

            return Customer;
        }
    }
}

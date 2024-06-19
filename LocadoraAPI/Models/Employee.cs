using Enums;
using Models.CreateModels;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EmployePosition Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Rental>? Rentals { get; set; }


        public Employee()
        {
            Id = Guid.NewGuid();
            Rentals = new List<Rental>();
        }

        public Employee(string name, EmployePosition position, string email, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Position = position;
            Email = email;
            Phone = phone;
            Rentals = new List<Rental>();
        }

        internal static Employee Parse(EmployeeCreateModel employee)
        {
            Employee _employee = new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                Position = employee.Position,
                Rentals = null
            };

            return _employee;
        }

    }
}


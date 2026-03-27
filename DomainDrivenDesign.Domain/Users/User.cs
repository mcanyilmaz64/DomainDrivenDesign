using DomainDrivenDesign.Domain.Abstraction;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid id) : base(id)
        {
            
        }
        private User(Guid id,Name name, Email email, Password password, Adress adress): base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            Adress = adress;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get;private set; }
        public Adress Adress { get; private set; }

        public static User CreateUser(string name, string email, string password,
            string country, string city, string street, string postalCode, string fullAdress)
        {
            return new User(
                Guid.NewGuid(),
                new Name(name),
                new Email(email),
                new Password(password),
                new Adress(country, city, street, fullAdress, postalCode)
            );
        }

        public void ChangeName(string name)
        {
             Name = new(name);
        }
        public void ChangeEmail(string email)
        {
            Email = new(email);
        }
        public void ChangePassword(string password)
        {
            Password = new(password);
        }
        public void ChangeAdress(string Country, string City, string Street, string FullAdress, string PostalCode)
        {
            Adress = new(Country, City, Street, FullAdress, PostalCode);
        }
    }
   
}

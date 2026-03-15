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
        public User(Guid id,Name name, Email email, Password password, Adress adress): base(id)
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

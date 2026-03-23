using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Users.CreateUser
{
    public sealed record CreateUserCommand(
        string Name,
        string Email,
        string Password,
        string Country,
        string City,
        string Street,
        string PostolCode,
        string FullAdress) : IRequest;

}
    
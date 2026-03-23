using DomainDrivenDesign.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Users.GetAllUser
{
    public sealed record GetAllUserQuery() : IRequest<List<User>>;
    
}

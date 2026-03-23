using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Categories.CreateCategory
{
    public sealed record CreateCategoryCommand(string name) : IRequest;
    
}

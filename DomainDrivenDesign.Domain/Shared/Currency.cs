using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Shared
{
    public sealed record Currency
    {
        public string Code { get; init; }
        private Currency(string code)
        {
            Code = code;
        }
    }
}

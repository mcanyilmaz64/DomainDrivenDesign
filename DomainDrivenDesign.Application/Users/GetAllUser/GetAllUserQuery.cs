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

    internal sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync(cancellationToken);
        }
    }
    
}

using AutoMapper;
using EMail.Application.Models;
using EMail.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EMail.Application.Queries
{
    public class ListEMailAccountsQueryHandler : IRequestHandler<ListEMailAccountsQuery, IEnumerable<EMailAccountAppModel>>
    {
        private readonly IEMailRepository repository;
        private readonly IMapper mapper;

        public ListEMailAccountsQueryHandler(IEMailRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EMailAccountAppModel>> Handle(ListEMailAccountsQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<EMailAccountAppModel>>(await repository.List());
        }
    }
}

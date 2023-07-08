using EMail.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace EMail.Application.Queries
{
    public class ListEMailAccountsQuery : IRequest<IEnumerable<EMailAccountAppModel>>
    {
    }
}

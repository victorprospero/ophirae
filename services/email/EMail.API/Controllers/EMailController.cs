using EMail.Application.Commands;
using EMail.Application.Models;
using EMail.Application.Queries;
using EMail.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMail.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EMailController : ControllerBase
    {
        private readonly IMediator mediator;

        public EMailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<EMailAccountAppModel>> ListAccounts()
        {
            return await mediator.Send(new ListEMailAccountsQuery());
        }

        [HttpPost]
        public async Task SaveAccount(EMailAccountToSave savingAccount)
        {
            await mediator.Publish(new SaveEMailAccountCommand()
            {
                EMailAddress = savingAccount.EMailAddress,
                SourceAgent = savingAccount.SavedBy
            });
        }
    }
}

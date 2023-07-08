using EMail.Domain.Entities;
using EMail.Domain.Enums;
using EMail.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EMail.Application.Commands
{
    public class SaveEMailAccountCommandHandler : INotificationHandler<SaveEMailAccountCommand>
    {
        private readonly IEMailRepository repository;

        public SaveEMailAccountCommandHandler(IEMailRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(SaveEMailAccountCommand notification, CancellationToken cancellationToken)
        {
            SourceAgent savedBy;

            if (notification.SourceAgent == "WebSite") savedBy = SourceAgent.WebSite;
            else if (notification.SourceAgent == "Crawling") savedBy = SourceAgent.Crawling;
            else savedBy = SourceAgent.API;

            await repository.Save(new EMailAccountModel()
            {
                Address = notification.EMailAddress,
            }, savedBy);
        }
    }
}

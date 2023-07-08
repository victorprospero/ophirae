using MediatR;

namespace EMail.Application.Commands
{
    public class SaveEMailAccountCommand : INotification
    {
        public string EMailAddress { get; set; }
        public string SourceAgent { get; set; }
    }
}

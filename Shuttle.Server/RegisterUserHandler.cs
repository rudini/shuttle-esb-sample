namespace Shuttle.Server
{
    using ESB.Core;
    using Contracts;
    using Core.Infrastructure;

    public class RegisterUserHandler : IMessageHandler<RegisterUserCommand>
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
      
        public void ProcessMessage(HandlerContext<RegisterUserCommand> context)
        {
            Log.Information(string.Format("Message received: {0}", context.Message.Name));
        }
    }
}

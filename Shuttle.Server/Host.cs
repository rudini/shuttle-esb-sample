namespace Shuttle.Server
{
    using System;
    using Core.Host;
    using ESB.Core;
    using Core.Infrastructure;
    using log4net;
    using System.Reflection;
    using Core.Infrastructure.Log4Net;
    using App_Start;

    public class Host : IHost, IDisposable
    {
        private IServiceBus bus;

        public void Dispose()
        {
            this.bus.Dispose();
        }

        public void Start()
        {
            Log4NetConfig.Init(true);

            Log.Assign(new Log4NetLog(LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)));

            this.bus = ServiceBus
                .Create(c => c.AddEnryptionAlgorithm(new TripleDesEncryptionAlgorithm())
                .AddCompressionAlgorithm(new DeflateCompressionAlgorithm()))
                .Start();
        }
    }
}

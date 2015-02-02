namespace Shuttle.Client
{
    using Contracts;
    using ESB.Core;

    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = ServiceBus
                .Create(c => c.AddEnryptionAlgorithm(new TripleDesEncryptionAlgorithm())
                .AddCompressionAlgorithm(new DeflateCompressionAlgorithm()))
                .Start())
            {
                bus.Send(new RegisterUserCommand { Name = "SuperUser" });
            }
        }
    }
}

namespace VideoStore.Sales
{
    using NServiceBus;
    using NServiceBus.Persistence;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, UsingTransport<MsmqTransport>
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.Conventions()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("VideoStore") && t.Namespace.EndsWith("Commands"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("VideoStore") && t.Namespace.EndsWith("Events"))
                .DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("VideoStore") && t.Namespace.EndsWith("RequestResponse"))
                .DefiningEncryptedPropertiesAs(p => p.Name.StartsWith("Encrypted"));
            configuration.RijndaelEncryptionService();
        
        }
    }

}

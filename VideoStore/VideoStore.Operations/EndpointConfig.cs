namespace VideoStore.Operations
{
    using NServiceBus.Persistence;
    using NServiceBus;

	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, UsingTransport<SqlServerTransport>
    {
	    public void Customize(BusConfiguration configuration)
        {

            configuration.UsePersistence<NHibernatePersistence>();
	        configuration.Conventions()
	            .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.StartsWith("VideoStore") && t.Namespace.EndsWith("Commands"))
	            .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("VideoStore") && t.Namespace.EndsWith("Events"))
	            .DefiningMessagesAs(t => t.Namespace != null && t.Namespace.StartsWith("VideoStore") && t.Namespace.EndsWith("RequestResponse"));
        }
    }
	

}

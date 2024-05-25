using Grpc.Net.Client;

namespace MeteorFlow.Infrastructure.Grpc;

public class ChannelFactory
{
    public static GrpcChannel Create(string address, string jwtToken = "")
    {
        if (jwtToken == "")
        {
            return GrpcChannel.ForAddress(address);
        }
        
        var httpClientHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                // TODO: verify the Certificate
                return true;
            }
        };

        var httpClient = new HttpClient(httpClientHandler);
        
        // Add JWT token to the Authorization header
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);

        var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
        {
            HttpClient = httpClient,
        });

        return channel;
    }
}
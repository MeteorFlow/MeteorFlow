using Confluent.Kafka;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MeteorFlow.Infrastructure.MessageBroker.Kafka;

public class KafkaHealthCheck(string bootstrapServers, string topic) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
    {
        try
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers, MessageTimeoutMs = 10000 };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var result = await producer.ProduceAsync(topic, new Message<Null, string>
            {
                Value = $"Health Check {DateTimeOffset.Now}",
            }, cancellationToken);

            if (result.Status == PersistenceStatus.NotPersisted)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, "Message was never transmitted to the broker, or failed with an error indicating it was not written to the log. Application retry risks ordering, but not duplication");
            }

            return HealthCheckResult.Healthy();
        }
        catch (Exception exception)
        {
            return new HealthCheckResult(context.Registration.FailureStatus, exception: exception);
        }
    }
}

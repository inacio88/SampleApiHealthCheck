using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace apiWithHealthChecksAndScalar.Endpoints.HealthChecks
{
    public class DegradedHealthcheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Degraded("Esse é degraded de saude"));
        }
    }
}
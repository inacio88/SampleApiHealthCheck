using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace apiWithHealthChecksAndScalar.Endpoints.HealthChecks
{
    public class UnHealthCheck: IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy("Esse é UnHealthCheck de saude"));
        }
        
    }
}
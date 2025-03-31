using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace apiWithHealthChecksAndScalar.Endpoints.HealthChecks
{
    public class HealthHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
                                                        CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy("Esse é um teste de saude"));
        }
    }
}
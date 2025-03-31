using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace apiWithHealthChecksAndScalar.Endpoints.HealthChecks
{
    public class RandomHealthCheckResult: IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int randomResult = Random.Shared.Next(1, 4);
            return randomResult switch
            {
                1 => Task.FromResult(HealthCheckResult.Healthy("Esse Healthy é um teste random")),
                2 => Task.FromResult(HealthCheckResult.Degraded("Esse Degraded é um teste random")),
                3 => Task.FromResult(HealthCheckResult.Unhealthy("Esse Unhealthy é um teste random")),
                _ => Task.FromResult(HealthCheckResult.Healthy("Esse é um teste random")),
            };
        }
        
    }
}
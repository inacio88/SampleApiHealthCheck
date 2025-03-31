using apiWithHealthChecksAndScalar.Endpoints.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace apiWithHealthChecksAndScalar.Startup
{
    public static class HealthChecksConfig
    {
        public static void AddAllHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<RandomHealthCheckResult>("Random", tags: ["random"])
                .AddCheck<HealthHealthCheck>("Health", tags: ["healthy"])
                .AddCheck<DegradedHealthcheck>("Degraded", tags: ["degraded"])
                .AddCheck<UnHealthCheck>("Unhealth", tags: ["unhealth"])
                ;
        }

        public static void MappAllHealthChecks(this WebApplication app)
        {
            app.MapHealthChecks("/health");

            app.MapHealthChecks("/health/healthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("healthy")
            });

            app.MapHealthChecks("/health/degraded", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("degraded")
            });

            app.MapHealthChecks("/health/unhealth", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("unhealth")
            });

            app.MapHealthChecks("/health/random", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("random")
            });

            app.MapHealthChecks("/health/ui", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.MapHealthChecks("/health/ui/healthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("healthy"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

            });

            app.MapHealthChecks("/health/ui/degraded", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("degraded"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

            });

            app.MapHealthChecks("/health/ui/unhealth", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("unhealth"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

            });

            app.MapHealthChecks("/health/ui/random", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("random"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

            });

        }
    }
}
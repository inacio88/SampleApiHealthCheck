namespace apiWithHealthChecksAndScalar.Startup
{
    public static class CorsConfig
    {
        private const string nomeAllowAllPolicyCors = "AllowAll";
        public static void AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy(nomeAllowAllPolicyCors, policy => {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }

        public static void ApplyCorsConfig(this WebApplication app)
        {
            app.UseCors(nomeAllowAllPolicyCors);
        }
    }
}
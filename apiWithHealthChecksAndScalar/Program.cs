using apiWithHealthChecksAndScalar.Endpoints;
using apiWithHealthChecksAndScalar.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();
app.ApplyCorsConfig();

app.MappAllHealthChecks();
app.AddRootEndpoints();
app.AddCourseEndpoints();
app.AddErrorEndpoints();


app.Run();
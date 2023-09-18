using Microsoft.OpenApi.Models;
using OrderStore.Grpc;
using OrderStoreAdaptors.Extensions;
using OrderStoreApp.Extensions;
using OrderStoreApp.Hub;
using OrderStoreApp.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddRouting();
builder.Services.AddGrpc();
// Configure MVC services for REST
builder.Services.AddControllers();
builder.Services.AddAppExtensions();
builder.Services.AddAdaptorExtensions();
builder.Services.AddSignalR();
builder.Services.AddRouting();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderStore", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
app.UseRouting();
app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowCredentials()); // allow credentials
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/hub");
});
app.MapGrpcService<OrderProviderService>();
app.MapGrpcService<OrderTransactionProviderService>();
app.MapControllers();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");
app.UseSwagger();

// Enable middleware to serve Swagger UI, specifying the Swagger JSON endpoint
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderStore");
});

var startup = app.Services.GetService<Startup>();
startup?.Start();

app.Run();

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
// Configure Kestrel to listen on the desired URL
//var desiredUrl = GetDesiredApplicationUrl();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.WebHost.UseUrls(desiredUrl);

var app = builder.Build();

// Configure the HTTP request pipeline.
ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/hub");
});
app.MapGrpcService<OrderProviderService>();
app.MapGrpcService<OrderTransactionProviderService>();
app.MapControllers();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.UseSwagger();
app.UseSwaggerUI();

var startup = app.Services.GetService<Startup>();
startup?.Start();

app.Run();

//// Implement a method to get the desired URL
// static string GetDesiredApplicationUrl()
//{
//    // Replace this with your logic to determine the desired URL
//      return "http://localhost:5213;http://localhost:5214;https://localhost:7213";
//}
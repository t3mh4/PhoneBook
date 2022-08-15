using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using PhoneBook.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls(BaseUrl.GatewayBaseHttpUrl, BaseUrl.GatewayBaseHttpsUrl);
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

app.Run();
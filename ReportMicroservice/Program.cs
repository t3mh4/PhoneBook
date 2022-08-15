using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Configuration;
using ReportMicroservice.DBContext;
using ReportMicroservice.Managers;
using ReportMicroservice.MassTransit;
using ReportMicroservice.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls(BaseUrl.ReportMsBaseHttpUrl, BaseUrl.ReportMsBaseHttpsUrl);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PhoneBookContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#region Dependency Injection
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<IReportManager, ReportManager>();
#endregion

#region MassTransit Configuration
builder.Services.AddMassTransit(m =>
{
    m.AddConsumer<CommandConsumer>();
    m.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://localhost"), hst =>
        {
            hst.Username("guest");
            hst.Password("guest");
        });
        cfg.ReceiveEndpoint("report.microservice", e =>
        {
            e.ConfigureConsumer<CommandConsumer>(context);
        });
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

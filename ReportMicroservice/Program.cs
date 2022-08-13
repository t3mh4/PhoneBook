using Microsoft.EntityFrameworkCore;
using ReportMicroservice.DBContext;
using ReportMicroservice.Managers;
using ReportMicroservice.Services;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<IReportManager, ReportManager>();
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

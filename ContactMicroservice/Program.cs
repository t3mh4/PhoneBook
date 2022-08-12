using ContactMicroservice.DBContext;
using ContactMicroservice.Repositories;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddTransient<IContactRepository, ConctactRepository>();
builder.Services.AddTransient<IContactInfoRepository, ContactInfoRepository>();
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

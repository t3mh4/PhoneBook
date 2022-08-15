using ContactMicroservice;
using ContactMicroservice.DBContext;
using ContactMicroservice.Managers;
using ContactMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);
//Http ve Https url deðiþtiriyoruz
builder.WebHost.UseUrls(BaseUrl.ContactMsBaseHttpUrl, BaseUrl.ContactMsBaseHttpsUrl);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PhoneBookContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --Migration için
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IContactInfoService, ContactInfoService>();
builder.Services.AddTransient<IContactManager, ContactManager>();
builder.Services.AddTransient<IContactInfoManager, ContactInfoManager>();
var app = builder.Build();

Database.Initialize(app);

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

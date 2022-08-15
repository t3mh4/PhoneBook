
namespace ContactMicroservice.DBContext
{
    public static class Database
    {
        public static void Initialize(WebApplication app)
        {
            using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PhoneBookContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}

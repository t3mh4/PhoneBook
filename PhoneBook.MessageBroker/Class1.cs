using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook.MessageBroker
{
    public class Consumer
    {
        public void Register(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((r, c) =>
                {
                    c.Host("rabbitmq--url");
                });
            });
        }
    }
}
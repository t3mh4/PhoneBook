using MassTransit;
using PhoneBook.Dtos;
using ReportMicroservice.Managers;

namespace ReportMicroservice.MassTransit
{
    public class CommandConsumer : IConsumer<Command>
    {
        private readonly IReportManager _manager;
        public CommandConsumer(IReportManager manager)
        {
            _manager = manager;
        }
        public async Task Consume(ConsumeContext<Command> context)
        {
            if (context.Message.Cmd == PhoneBook.Core.Enums.EnumReport.Command.Generate)
            {
                await _manager.GenerateReport();
            }
        }
    }
}

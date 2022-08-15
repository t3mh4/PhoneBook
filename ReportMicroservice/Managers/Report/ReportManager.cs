using PhoneBook.Core.Configuration;
using PhoneBook.Core.Enums;
using PhoneBook.Core.Extensions;
using PhoneBook.Dtos;
using ReportMicroservice.Entities;
using ReportMicroservice.Services;
using System.Reflection;

namespace ReportMicroservice.Managers
{
    public class ReportManager : IReportManager
    {
        private readonly IReportService _service;
        public ReportManager(IReportService service)
        {
            _service = service;
        }

        public async Task<List<ReportDto>> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task GenerateReport()
        {
            string fileName = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Reports";
            //insert report
            var report = new Report
            {
                CreatedDate = DateTime.UtcNow,
                Status = EnumReport.Status.Preparing.ToInt32(),
                ReportDate = DateTime.UtcNow,
                FullPath = Path.Combine(directory, fileName)
            };
            await Save(report);
            //save report file
            var reportData = await GetLocationReportData();
            await reportData.ExportToExcel(directory, fileName);
            Thread.Sleep(1000 * 60);
            //update status
            await UpdateStatus(report);
        }
        public async Task<List<LocationReportDto>> GetLocationReportData()
        {
            var _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl.ContactMsBaseHttpsUrl)
            };
            return await _httpClient.GetFromJsonAsync<List<LocationReportDto>>("api/contactinfo/GetLocationReport");
        }

        private async Task UpdateStatus(Report report)
        {
            report.Status = EnumReport.Status.Completed.ToInt32();
            report.CreatedDate = DateTime.UtcNow;
            await Save(report);
        }

        private async Task Save(Report report)
        {
            if (report.UUID == Guid.Empty)
            {
                report.UUID = Guid.NewGuid();
                await _service.AddAsync(report);
                await _service.SaveAsync();
            }
            else
            {
                await _service.UpdateAsync(report);
                await _service.SaveAsync();
            }
        }

        //todo:katmanlı mimari için ;
        //UserToAddDTO, ve UserToListDTO şeklinde DTO'lar oluşturulabilir
        //rabbitmq exception handling
    }
}

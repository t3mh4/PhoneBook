using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace PhoneBook.Core.Extensions
{
    public static class ListExtensions
    {
        public static async Task ExportToExcel<T>(this List<T> list, string directoryPath, string fileName, string extension = "xlsx")
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var pack = new ExcelPackage();
            var file = fileName + "." + extension;
            ExcelWorksheet ws = pack.Workbook.Worksheets.Add("Sheet 1");
            ws.Cells["A1"].LoadFromCollection(list, true, TableStyles.Light1);
            await pack.SaveAsAsync(Path.Combine(directoryPath, file));
        }
    }
}

using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using ForecastBudgetApp.Models;

namespace ForecastBudgetApp.Services
{
    public class ExportService
    {
        public void ExportToXLSX(List<object> data)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Data");

                // Add headers
                worksheet.Cells[1, 1].Value = "Id";
                worksheet.Cells[1, 2].Value = "Date";
                worksheet.Cells[1, 3].Value = "Revenue";
                worksheet.Cells[1, 4].Value = "Expenses";
                worksheet.Cells[1, 5].Value = "Profit";
                worksheet.Cells[1, 6].Value = "Comments";
                worksheet.Cells[1, 7].Value = "IsApproved";
                worksheet.Cells[1, 8].Value = "ApprovedBy";

                // Add data
                for (int i = 0; i < data.Count; i++)
                {
                    var item = data[i];
                    worksheet.Cells[i + 2, 1].Value = item.GetType().GetProperty("Id").GetValue(item, null);
                    worksheet.Cells[i + 2, 2].Value = item.GetType().GetProperty("Date").GetValue(item, null);
                    worksheet.Cells[i + 2, 3].Value = item.GetType().GetProperty("Revenue").GetValue(item, null);
                    worksheet.Cells[i + 2, 4].Value = item.GetType().GetProperty("Expenses").GetValue(item, null);
                    worksheet.Cells[i + 2, 5].Value = item.GetType().GetProperty("Profit").GetValue(item, null);
                    worksheet.Cells[i + 2, 6].Value = item.GetType().GetProperty("Comments").GetValue(item, null);
                    worksheet.Cells[i + 2, 7].Value = item.GetType().GetProperty("IsApproved")?.GetValue(item, null);
                    worksheet.Cells[i + 2, 8].Value = item.GetType().GetProperty("ApprovedBy")?.GetValue(item, null);
                }

                // Save the file
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ExportedData.xlsx");
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
    }
}

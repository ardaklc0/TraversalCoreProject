using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.IO;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> GetDestinationModels()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult StaticExcelReport()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();
            var ws = excelPackage.Workbook.Worksheets.Add("Sheet1");
            ws.Cells[1, 1].Value = "Rota";
            ws.Cells[1, 2].Value = "Rehber";
            ws.Cells[1, 3].Value = "Kontenjan";

            ws.Cells[2, 1].Value = "İstanbul";
            ws.Cells[2, 2].Value = "Ahmet";
            ws.Cells[2, 3].Value = "50";

            ws.Cells[3, 1].Value = "Sırbistan";
            ws.Cells[3, 2].Value = "Zeynep";
            ws.Cells[3, 3].Value = "30";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Rota.xlsx");
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Destinations");
                workSheet.Cell(1, 1).Value = "City";
                workSheet.Cell(1, 2).Value = "DayNight";
                workSheet.Cell(1, 3).Value = "Price";
                workSheet.Cell(1, 4).Value = "Capacity";
                var destinationModels = GetDestinationModels();
                int rowCount = 2;
                foreach (var destinationModel in destinationModels)
                {
                    workSheet.Cell(rowCount, 1).Value = destinationModel.City;
                    workSheet.Cell(rowCount, 2).Value = destinationModel.DayNight;
                    workSheet.Cell(rowCount, 3).Value = destinationModel.Price;
                    workSheet.Cell(rowCount, 4).Value = destinationModel.Capacity;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "NewDestinations.xlsx");
                }
            }
        }
    }
}

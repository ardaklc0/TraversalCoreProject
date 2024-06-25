using BusinessLayer.Abstract;
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
        private readonly IExcelService excelService;
        public ExcelController(IExcelService excelService)
        {
            this.excelService = excelService;
        }
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
            return File(excelService.ExcelList(GetDestinationModels()), 
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
                "Destinations.xlsx");
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

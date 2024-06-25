using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace TraversalCoreProject.Controllers
{
    public class PDFReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/file1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            
            document.Open();
            
            document.Add(new Paragraph("Traversal Rezervasyon PDF Raporu"));
            document.Close();

            return File("/pdfreports/file1.pdf", "application/pdf", "file1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/file2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable table = new PdfPTable(3);
            table.AddCell("Misafir Ad");    
            table.AddCell("Misafir Soyad");
            table.AddCell("Misafir TC");

            table.AddCell("Ahmet");
            table.AddCell("Yılmaz");
            table.AddCell("12345678901");

            table.AddCell("Mehmet");
            table.AddCell("Yıldız");
            table.AddCell("12345678902");

            table.AddCell("Ayşe");
            table.AddCell("Kaya");
            table.AddCell("12345678903");

            document.Add(table);
            document.Close();
            return File("/pdfreports/file2.pdf", "application/pdf", "file2.pdf");

        }
    }
}

using BusinessLayer.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] ExcelList<T>(List<T> list) where T : class
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();
            var ws = excelPackage.Workbook.Worksheets.Add("Sheet1");
            ws.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light10);
            return excelPackage.GetAsByteArray();
        }
    }
}

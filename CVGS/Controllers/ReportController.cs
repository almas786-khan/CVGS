using CVGS.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace CVGS.Controllers
{
    public class ReportController : Controller
    {
        cvgsEntities2 _context = new cvgsEntities2();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult l()
        {
            List<MemberDetailsView> list = new List<MemberDetailsView>();
            var query = from member in _context.Users
                        where member.UserType != "Admin"
                        select new MemberDetailsView
                        {
                            UserID = member.UserID,
                            UserName = member.UserName,
                            UserEmail = member.UserEmail,
                            UserFirstName = member.UserFirstName, 
                            UserLastName = member.UserLastName,
                            Gender = member.Gender,
                            Birthdate = member.Birthdate
                        };
            list = query.ToList();
            return View(list);
        }
        public void ExportToExcel()
        {
            List<MemberDetailsView> list = new List<MemberDetailsView>();
            var query = from member in _context.Users
                        where member.UserType != "Admin"
                        select new MemberDetailsView
                        {
                            UserID = member.UserID,
                            UserName = member.UserName,
                            UserEmail = member.UserEmail,
                            UserFirstName = member.UserFirstName,
                            UserLastName = member.UserLastName,
                            Gender = member.Gender,
                            Birthdate = member.Birthdate
                        };
            list = query.ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Communication";
            ws.Cells["B1"].Value = "Cpm1";

            ws.Cells["A2"].Value = "Report";
            ws.Cells["B2"].Value = "Report1";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "UserID";
            ws.Cells["B6"].Value = "UserName";
            ws.Cells["C6"].Value = "UserEmail";
            ws.Cells["D6"].Value = "EmployeeId";
            ws.Cells["E6"].Value = "UserFirstName";
            foreach (var item in list)
            {
                
            }



        }
        //[HttpPost]
        //[ValidateInput(false)]
        //public FileResult Export(string ExportData)
        //{
        //    using (MemoryStream stream = new System.IO.MemoryStream())
        //    {
        //        StringReader reader = new StringReader(ExportData);
        //        //Document PdfFile = new Document(PageSize.A4);
        //        //PdfWriter writer = PdfWriter.GetInstance(PdfFile, stream);
        //        //PdfFile.Open();
        //        //XMLWorkerHelper.GetInstance().ParseXHtml(writer, PdfFile, reader);
        //        //PdfFile.Close();
        //        //return File(stream.ToArray(), "application/pdf", "ExportData.pdf");
        //    }
        //}
    }
}
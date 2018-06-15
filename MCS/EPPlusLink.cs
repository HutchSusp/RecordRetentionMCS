using System.Linq;
using System.IO;
using OfficeOpenXml;
using System;

namespace RetentionDraft2
{
    public static class EPPlusLink
    {
        public static string ExportToExcel(IQueryable<Record> records, string title, string path = "Temp.xlsx") {
            ExcelPackage output = new ExcelPackage();
            var worksheet = output.Workbook.Worksheets.Add(title);

            string[] titlearray = { "Box Number", "Record ID", "Record Title", "Start Date","End Date", "Document Type",
                "Destory Date", "Notes", "Destoryed?", "Date Destoryed", "Authorized By", "Held?", "Date Held", "Hold Notes" };

            var formatrecord = from r in records
                               select new {
                                   r.BoxNumber,
                                   r.RecordID,
                                   r.Title,
                                   Start = r.StartDate.ToString(),
                                   End = r.EndDate.ToString(),
                                   DocType = (r.IsExecutive ? "Executive" : "General"),
                                   Retain = r.RetainUntil.ToString(),
                                   r.Notes,
                                   Destoryed = (r.IsDestoryed ? "Yes" : "No"),
                                   Destory = r.DestoryDate.ToString(),
                                   r.DestoryAuthorization,
                                   Held = (r.IsHeld ? "Yes" : "No"),
                                   Hold = r.HoldDate.ToString(),
                                   r.HoldNotes
                               };

            worksheet.Cells["A1"].Value = title;
            worksheet.Cells["A2"].Value = "Generated on";
            worksheet.Cells["B2"].Value = DateTime.Now.ToString();
            worksheet.Cells["A4"].LoadFromCollection(titlearray);
            worksheet.Cells["A5"].LoadFromCollection(formatrecord);
            worksheet.Cells.AutoFitColumns();

            output.SaveAs(new FileInfo(path));
            return path;
        }
    }
}
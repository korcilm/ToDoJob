﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using ToDoJob.Business.Interfaces;

namespace ToDoJob.Business.Concrete
{
    public class FileManager:IFileService
    {
        public byte[] AktarExcel<T>(List<T> list) where T : class, new()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            var excelPackage = new ExcelPackage();
            var excelBlank = excelPackage.Workbook.Worksheets.Add("Work");

            excelBlank.Cells["A1"].LoadFromCollection(list, true, TableStyles.Light10);

            return excelPackage.GetAsByteArray();
        }

        public string AktarPdf<T>(List<T> list) where T : class, new()
        {
            DataTable dataTable=new DataTable();
            dataTable.Load(ObjectReader.Create(list));

            var fileName = Guid.NewGuid() + ".pdf";
            var returnPath = "/documents/" + fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);
            var stream=new FileStream(path,FileMode.Create);

            Document document=new Document(PageSize.A4,25f,25f,25f,25f);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable=new PdfPTable(dataTable.Columns.Count);

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                pdfPTable.AddCell(dataTable.Columns[i].ColumnName);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdfPTable.AddCell(dataTable.Rows[i][j].ToString());
                }
            }

            document.Add(pdfPTable);
            document.Close();

            return returnPath;
        }
    }
}

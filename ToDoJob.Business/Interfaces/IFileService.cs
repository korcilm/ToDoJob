
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoJob.Business.Interfaces
{
    public interface IFileService
    {
        byte[] AktarExcel<T>(List<T> list) where T : class, new();
        string AktarPdf<T>(List<T> list) where T : class, new();
    }
}

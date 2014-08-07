using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCode.DataAccessLayer;
using NewLife.Log;
using System.Data;

namespace XCodeTestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            XTrace.WriteLine("Test Start");
            DAL dalPDM = DAL.Create("PDM");
            XTrace.WriteLine("DAL.Create");
            //List<IDataTable> pdmTables = dalPDM.Tables;

            DataSet ds = dalPDM.Select("SELECT * FROM INTER_PROJNO", null);

            XTrace.WriteLine("Test End");
        }
    }
}

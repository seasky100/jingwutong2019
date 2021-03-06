﻿using DbComponent;
using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSExportExcell
{
    public class Excell
    {
        public static int WSExportExcell(string tmpath,string[] dbs) { 
        ExcelFile excelFile = new ExcelFile();

        DataTable dataTable = new DataTable();
            for (int h = 0; h<dbs.Length; h++)
            {
               var worksheet = excelFile.Worksheets.Add(dbs[h]);
                if(dbs[h]== "EverydayInfo_Hour") {
                    dataTable = SQLHelper.ExecuteRead(CommandType.Text, "SELECT * FROM  " + dbs[h] + " where  Time >'2019-4-25 00:00:00.000'", "11");
                }
                else { 
               dataTable = SQLHelper.ExecuteRead(CommandType.Text, "SELECT * FROM  "+ dbs[h], "11");
                }
                worksheet.InsertDataTable(dataTable,
                new InsertDataTableOptions()
             {
            ColumnHeaders = true,
                    StartRow = 0
                });

            }
            excelFile.Save(tmpath);
            return 0;
        }
    }
}

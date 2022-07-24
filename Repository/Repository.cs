using IronXL;
using System.Linq;
using Classes;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace Repository
{
    public class Repository
    {
        public List<Columnname> ReadColumn(string filePath)
        {
            WorkBook workBook = WorkBook.Load($@"{filePath}");
            WorkSheet sheet = workBook.WorkSheets[0];

            var dataTable = sheet.ToDataTable(true);
            List<Columnname> columns = new List<Columnname>();
            foreach (DataColumn column in dataTable.Columns)
            {
                Columnname cName = new Columnname();
                cName.Name = column.ColumnName;
                columns.Add(cName);
            }
            int i = 0;
            return columns;
        }

        public bool Reader(List<MapClass> maps , string TargetPath, string OriginPath )
        {
            // Target
            WorkBook targetFile = WorkBook.Load($@"{TargetPath}");
            WorkSheet Tsheet = targetFile.WorkSheets.First();
            var dataTableTarget = Tsheet.ToDataTable(true);

            // Origin
            WorkBook originFile = WorkBook.Load($@"{OriginPath}");
            WorkSheet Osheet = originFile.WorkSheets.First();
            var dataTableOrigin = Osheet.ToDataTable(true);

            TargetVal targetVal = new TargetVal();


            List<TargetVal> Rows = new List<TargetVal>();
            foreach (DataRow Row in dataTableOrigin.Rows)
            {
                foreach( MapClass map in maps)
                {
                    if(map.Old == "Name")
                    {
                        targetVal.Name = Convert.ToString(Row[$"{map.New}"]);
                    }else if(map.Old == "ID")
                    {
                        targetVal.ID = Convert.ToString(Row[$"{map.New}"]);
                    }
                    else if(map.Old == "Age")
                    {
                        targetVal.Age = Convert.ToString(Row[$"{map.New}"]);
                    }
                    else if(map.Old == "Gender")
                    {
                        targetVal.Gender = Convert.ToString(Row[$"{map.New}"]);
                    }
                }
                Rows.Add(targetVal);
                int i = 0;
            }

            foreach( TargetVal targetVal1 in Rows)
            {
                foreach(DataRow dataRow in dataTableOrigin.Rows)
                {
                    dataRow["Name"] = targetVal1.Name;
                    dataRow["ID"] = targetVal1.ID;
                    dataRow["Age"] = targetVal1.Age;
                    dataRow["Gender"] = targetVal1.Gender;
                    int ii = 0;
                    targetFile.WorkSheets.First().ToDataTable(true).Rows.Add(dataRow);
                }
            }
            targetFile.SaveAs($@"{TargetPath}");
            return true;
        }
        public static void TargetWriter(string TargetPath,  string OriginPath , MapClass map)
         {
            // open excel file 
            WorkBook targetFile = WorkBook.Load($@"{TargetPath}");

            // open sheet
            WorkSheet Tsheet = targetFile.WorkSheets.First();

            // read Sheet
            var dataTableTarget = Tsheet.ToDataTable(true);

            // target value class
            TargetVal targetVal = new TargetVal();


            foreach (DataRow Row in Tsheet.ToDataTable(true).Rows)
            {
                OriginReader(OriginPath , map , targetVal );
            }
            Tsheet.ToDataTable(true).Rows.Add();

            // save file
         }

        public bool WtiteFile(MapClass map , string OriginPath , string TargetPath)
        {
            WorkBook originFile = WorkBook.Load($@"{OriginPath}");

            WorkSheet Osheet = originFile.WorkSheets.First();

            var dataTableOrigin = Osheet.ToDataTable(true);

            List<TargetVal> Data = new List<TargetVal>();


            // we have one row from origin table 
            // new --> origin
            // old --> target
            foreach (DataRow row in dataTableOrigin.Rows)
            {
                TargetVal item = new TargetVal();
                item.Name = row[$"{map.New}"].ToString();

                Data.Add(item);
            }



            List<string> OriginList = new List<string>();
            return true;
        }

        private static void OriginReader(string originPath, MapClass map, TargetVal targetVal)
        {
            WorkBook originFile = WorkBook.Load($@"{originPath}");
            WorkSheet Osheet = originFile.WorkSheets.First();
            var dataTableOrigin = Osheet.ToDataTable(true);
        }
    }
}
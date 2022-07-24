using IronXL;
using System.Linq;
using Classes;
using System.Data;
using Aspose;

namespace Repository
{
    public class Repository
    {

        public void ExportExcell(string jsonInput)
        {
            var workbook = new Aspose.Cells.Workbook();
            var worksheet = workbook.Worksheets[0];

            var option = new Aspose.Cells.Utility.JsonLayoutOptions();
            option.ArrayAsTable = true;

            Aspose.Cells.Utility.JsonUtility.ImportData(jsonInput, worksheet.Cells, 0, 0, option);

            workbook.Save("output.xls" , Aspose.Cells.SaveFormat.Auto);

        }
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

        public bool Reader(List<MapClass> maps, string TargetPath, string OriginPath)
        {
            // Target
            WorkBook targetFile = WorkBook.Load($@"{TargetPath}");
            WorkSheet Tsheet = targetFile.WorkSheets.First();
            var dataTableTarget = Tsheet.ToDataTable(true);

            // Origin
            WorkBook originFile = WorkBook.Load($@"{OriginPath}");
            WorkSheet Osheet = originFile.WorkSheets.First();
            var dataTableOrigin = Osheet.ToDataTable(true);




            List<TargetVal> Rows = new List<TargetVal>();
            foreach (DataRow Row in dataTableOrigin.Rows)
            {
                TargetVal targetVal = new TargetVal();
                foreach (MapClass map in maps)
                {
                    // 
                    if (map.TargetV == "Name")
                    {
                        targetVal.Name = Convert.ToString(Row[$"{map.OriginV}"]);
                    }
                    else if (map.TargetV == "ID")
                    {
                        targetVal.ID = Convert.ToString(Row[$"{map.OriginV}"]);
                    }
                    else if (map.TargetV == "Age")
                    {
                        targetVal.Age = Convert.ToString(Row[$"{map.OriginV}"]);
                    }
                    else if (map.TargetV == "Gender")
                    {
                        targetVal.Gender = Convert.ToString(Row[$"{map.OriginV}"]);
                    }
                }
                // True 
                Rows.Add(targetVal);
            }


            int OriginCounter = Osheet.Rows.Count();
            int i = 2;
            foreach (TargetVal targetVal1 in Rows)
            {
                while (true)
                {
                    Tsheet[$"A{i}"].Value = targetVal1.ID;
                    Tsheet[$"B{i}"].Value = targetVal1.Name;
                    Tsheet[$"C{i}"].Value = targetVal1.Gender;
                    Tsheet[$"D{i}"].Value = targetVal1.Age;
                    ++i;
                    break;
                }
            }
            targetFile.SaveAs($@"{TargetPath}");
            return true;
        }
        public static void TargetWriter(string TargetPath, string OriginPath, MapClass map)
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
                OriginReader(OriginPath, map, targetVal);
            }
            Tsheet.ToDataTable(true).Rows.Add();

            // save file
        }

        public bool WtiteFile(MapClass map, string OriginPath, string TargetPath)
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
                item.Name = row[$"{map.OriginV}"].ToString();

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
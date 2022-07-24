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

        public bool ReadExcel(string Opath, string targetPath , List<MapClass> maps)
        {
            DataTable dt = new DataTable();
            Aspose.Cells.Workbook orginWorkbook = new Aspose.Cells.Workbook($@"{Opath}");
            Aspose.Cells.Worksheet orginWorkSheet = orginWorkbook.Worksheets[0];
            dt = orginWorkSheet.Cells.ExportDataTable(0, 0, 5, 5,true);

            for( int k = 0; k < dt.Rows.Count; k++)
            {
                for(int h = 0; h < dt.Columns.Count; h++)
                {
                    var item = dt.Rows[k][h].ToString();
                    int i = 0;  
                }
            }


            DataTable result = new DataTable();
            Aspose.Cells.Workbook targetWorkbook = new Aspose.Cells.Workbook($@"{targetPath}");
            Aspose.Cells.Worksheet targetWorksheet = targetWorkbook.Worksheets[0];
            var totalColumn = targetWorksheet.Cells.Count;
            result = targetWorksheet.Cells.ExportDataTable(0, 0, 5, totalColumn, true);


            int counter = 0;
            foreach (DataRow item in dt.Rows)
            {                 
                foreach (MapClass map in maps)
                {
                    result.Rows[counter][map.TargetV] = item[map.OriginV];
                }
                counter++;
            }

            var option = new Aspose.Cells.ImportTableOptions();
            targetWorksheet.Cells.ImportData(result, 0, 0, option);
            targetWorkbook.Save($@"C:\Users\micro\Desktop\New folder\output.xls");



            return true;
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
            int counter = 0;

            List<string> Value = new List<string>();
            foreach (DataRow Row in dataTableOrigin.Rows)
            {
                TargetVal targetVal = new TargetVal();
                foreach (MapClass map in maps)
                {
                    Value.Add(map.OriginV);
                }
                Rows.Add(targetVal);
                counter++;
            }

            int l = 1;
            int j = 1;

            int OriginCounter1 = Osheet.Rows.Count();
            int OriginCounterX1 = Tsheet.Columns.Count();
            int k = 0;

            for (; l < OriginCounter1; ++l)
            {
                for (; j < OriginCounterX1; ++j)
                {
                    Tsheet.ToDataTable(true).Rows[l][j] = Convert.ToString(Value[k++]);
                }
            }
            targetFile.SaveAs($@"{TargetPath}");
            return true;




            int OriginCounter = Osheet.Rows.Count();
            int OriginCounterX = Osheet.Columns.Count();
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
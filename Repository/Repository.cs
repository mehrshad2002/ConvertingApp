using IronXL;
using System.Linq;
using Classes;
using System.Data;

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
            int id = 1;
            foreach (DataColumn column in dataTable.Columns)
            {
                Columnname cName = new Columnname();
                cName.Name = column.ColumnName;
                columns.Add(cName);
            }
            return columns;
        }
    }
}
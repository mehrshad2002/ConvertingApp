using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ValidationFileFormat
    {
        public string Path { get; set; }
        public string FileName { get; set; }

        public ValidationFileFormat(string path, string fileName)
        {
            Path = path;
            FileName = fileName;
        }

        public bool Validation()
        {
            FileInfo fileInfo = new FileInfo(Path);
            var ext = fileInfo.Extension;
            return true;
        }
    }
}

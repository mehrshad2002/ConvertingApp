using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;
using Classes;

namespace ConvertingApp.AppForm
{
    public partial class TargetFormat : Form
    {
        public string FirtFileFormat;
        public TargetFormat()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FmWelcome fmWelcome = new FmWelcome();
            this.Close();
            fmWelcome.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rbExcel.Checked)
            {
                string FileFormat = ".xlsx";
                TargetFile targetFile = new TargetFile();
                targetFile.FileFormat = FileFormat;
                targetFile.FirstFilePath = FirtFileFormat;
                this.Close();
                targetFile.Show();

            }else if (rbWord.Checked)
            {
                string FileFormat = ".docs";
                TargetFile targetFile = new TargetFile();
                targetFile.FileFormat = FileFormat;
                targetFile.FirstFilePath = FirtFileFormat;
                this.Close();
                targetFile.Show();
            }
        }
    }
}

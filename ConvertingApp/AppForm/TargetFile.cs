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
    public partial class TargetFile : Form
    {
        public static int Flag = 0 ;
        public string FileFormat;
        public string FirstFilePath;
        public TargetFile()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FmWelcome fmWelcome = new FmWelcome();
            this.Hide();
            fmWelcome.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if( Flag == 1)
            {
                Servic service = new Servic();
                //1 Read Columns From Origin File
                List<Columnname> columnsOrigin = service.ReadColumn(FirstFilePath);
                //2 Read Columns From Target File
                string FilePath = openFileDialogSelect.FileName;
                List<Columnname> Columnstarget = service.ReadColumn(FilePath);

                // in showColumns we need 2 filed for getting columns data
                ShowColumns showColumns = new ShowColumns(columnsOrigin, Columnstarget, FirstFilePath, FilePath);

                this.Close();
                showColumns.Show();
            }
            else
            {
                MessageBox.Show("Somthings Wrong");
                txtSelect.ResetText();
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Servic service = new Servic();

            openFileDialogSelect.Multiselect = false;
            if(openFileDialogSelect.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialogSelect.FileName);
                string FilePath = openFileDialogSelect.FileName;
                ValidationFileFormat vff = new ValidationFileFormat(FilePath, FileFormat);
                bool Result = vff.Validation();
                txtSelect.Text = openFileDialogSelect.FileName;

                if(FirstFilePath == FilePath)
                {
                    txtSelect.ResetText();
                    MessageBox.Show("Thats Same File With First File.");
                }
                else
                {
                    if (Result)
                    {
                        Flag = 1;
                    }
                    else
                    {
                        MessageBox.Show("File Format Was Wrong!");
                    }
                }
            }
        }
    }
}

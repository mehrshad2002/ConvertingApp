using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;


namespace ConvertingApp.AppForm
{
    public partial class DataFormat : Form
    {
        public DataFormat()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioExcel.Checked)
            {
                ImportData importData = new ImportData();
                importData.FileName = ".xlsx";
                this.Close();
                importData.Show();
            }
            else if (radioWord.Checked)
            {
                MessageBox.Show("We working on it !");
                radioExcel.Checked = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FmWelcome fmWelcome = new FmWelcome();
            this.Hide();
            fmWelcome.Show();
        }
    }
}

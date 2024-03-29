﻿using System;
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
    public partial class ImportData : Form
    {
        public  string FileName;
        public ImportData()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FmWelcome fmWelcome = new FmWelcome();
            this.Close();
            fmWelcome.Show();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialogSelect.Multiselect = false;
            if (openFileDialogSelect.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialogSelect.FileName);
                string filePath = openFileDialogSelect.FileName;

                ValidationFileFormat vff = new ValidationFileFormat(filePath , FileName);
                bool Result = vff.Validation();
                textBoxFilePath.Text = filePath;

                if (!Result)
                {
                    MessageBox.Show($"Your File Format Should Be {FileName.ToUpper()} .\nTry Again.");
                    textBoxFilePath.ResetText();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string FilePath = openFileDialogSelect.FileName;
            TargetFormat targetFormat = new TargetFormat();
            targetFormat.FirtFileFormat = FilePath;
            int i = 0;
            this.Close();
            targetFormat.Show();
        }
    }
}

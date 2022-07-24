using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertingApp.AppForm
{
    public partial class End : Form
    {
        public End()
        {
            InitializeComponent();
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            FmWelcome fmWelcome = new FmWelcome();
            this.Close();
            fmWelcome.Show();
        }
    }
}

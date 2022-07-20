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
    public partial class ShowColumns : Form
    {
        public List<Columnname> OriginColumns = new List<Columnname>();
        public List<Columnname> TargetColumns = new List<Columnname>();
        public ShowColumns( List<Columnname> Opath , List<Columnname> Tpath )
        {
            InitializeComponent();
            OriginColumns = Opath;
            TargetColumns = Tpath;

            CreateButtons();
            dgColumns.DataSource = OriginColumns;
        }

        private void CreateButtons()
        {

            DataGridViewComboBoxColumn TargetDataGrid = new DataGridViewComboBoxColumn();
            TargetDataGrid.HeaderText = "Target";
            foreach( Columnname col in TargetColumns)
            {
                TargetDataGrid.Items.Add( col.Name );
            }
            dgColumns.Columns.Add(TargetDataGrid);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FmWelcome fmWelcomev = new FmWelcome();
            this.Close();
            fmWelcomev.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //Next

            foreach (var item in dgColumns.Rows)
            {
                var ii = item;
                int i = 0;
            }
        }

        private void dgColumns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

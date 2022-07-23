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
        public static string origin;
        public static string target;

        public List<Columnname> OriginColumns = new List<Columnname>();
        public List<Columnname> TargetColumns = new List<Columnname>();
        public ShowColumns( List<Columnname> Opath , List<Columnname> Tpath )
        {
            InitializeComponent();
            OriginColumns = Opath;
            TargetColumns = Tpath;

            CreateTextBox();
        }

        private void CreateTextBox()
        {
            foreach (Columnname col in OriginColumns)
            {
                var row = new DataGridViewRow();
                var comboCell = new DataGridViewComboBoxCell();
                foreach (Columnname colTarget in TargetColumns)
                {
                    comboCell.Items.Add(colTarget.Name);
                    //comboCell.Value = colTarget.Name;
                }

                if (TargetColumns.Exists(i=>i.Name == col.Name) )
                {
                    comboCell.Value = col.Name;
                }
                else
                {
                    comboCell.Items.Add("...");
                    comboCell.Value = "...";
                }

                row.Cells.Add(comboCell);

                var textbox = new DataGridViewTextBoxCell();
                textbox.Value = col.Name;
                row.Cells.Add(textbox);
                Newdg.Rows.Add(row);
            }
        }

        private void CreateButtons()
        {
            var row = new DataGridViewRow();
            var comboCell = new DataGridViewComboBoxCell();
            foreach(Columnname col in TargetColumns)
            {
                comboCell.Items.Add(col.Name);
            }
            row.Cells.Add(comboCell);

            var comboCell2 = new DataGridViewTextBoxCell();
            foreach (Columnname col in OriginColumns)
            {
                comboCell2.Value = col.Name;
            }
            row.Cells.Add(comboCell2);

            Newdg.Rows.Add(row);
             
            

            //foreach( Columnname col in OriginColumns)
            //{
            //    originColumn.Value = col.Name;
            //}
            //comboCell.Items.Add("ID");
            //comboCell.Items.Add("Name");
            //comboCell.Items.Add("mehrshad");
            //comboCell.Value = "mehrshad";
            //var comboCell2 = new DataGridViewComboBoxCell();
            //comboCell2.Items.Add("ID");
            //comboCell2.Items.Add("Name");
            //comboCell2.Items.Add("mehrshad");
            //comboCell2.Value = "mehrshad";
            //row.Cells.Add(comboCell2);
        }

        private void LoadDataGrid()
        {
            //Newdg.DataSource = OriginColumns;


            foreach (Columnname col in TargetColumns)
            {
                //Target.Items.Add(new { col.Name });
                Targets.Items.Add(col.Name);
            }


            foreach(Columnname col in OriginColumns)
            {
                Origins.DataPropertyName = col.Name;
                Origins.ToolTipText = col.Name;
                
            }

            //foreach ( Columnname col in OriginColumns)
            //{
            //    Origin.Items.Add(new {col.Name });
            //} 

            //Newdg.DataSource = OriginColumns;

            //List<int> ListID = new List<int>();

            //foreach( Columnname col in OriginColumns)
            //{
            //    ListID.Add(col.ID);
            //}

            //dgNew.DataSource = ListID ;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FmWelcome fmWelcomev = new FmWelcome();
            this.Close();
            fmWelcomev.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach(DataGridViewRow Row in Newdg.Rows)
            {
                foreach(DataGridViewCell cell in Row.Cells)
                {
                    if(counter % 2 == 0)
                    {
                        target = cell.Value.ToString();

                    }
                    else
                    {
                        origin = cell.Value.ToString();
                    }
                    ++counter;
                    if(counter % 2 == 0 && counter > 1)
                    {
                        //WriteFile();
                    }
                }
            }
            //foreach (DataGridViewRow item in Newdg.Rows)
            //{
            //    foreach (var cell in item.Cells)
            //    {
            //        if (cell.GetType() == typeof(DataGridViewComboBoxCell) )
            //        {
            //            var mycell = (DataGridViewComboBoxCell)cell;
            //            mycell.Value = "ID";
                        
            //            //mycell.FormattedValue = "ID";
            //            //mycell.EditedFormattedValue = "ID";
            //        }
            //    }

            //    var items = item;
            //}
        }

        private void dgColumns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                var x = dgNew.Rows[e.RowIndex];
                int i = 0;
            }
        }

        private void ShowColumns_Load(object sender, EventArgs e)
        {

        }
    }
}

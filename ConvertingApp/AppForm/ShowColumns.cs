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
        public static string OriginPath;
        public static string TargetPath;
        public static Target t ;
        public static Origin o ;




        public List<Columnname> OriginColumns = new List<Columnname>();
        public List<Columnname> TargetColumns = new List<Columnname>();
        public ShowColumns( List<Columnname> originCol , List<Columnname> targetcOL , string Opath , string Tpath)
        {
            InitializeComponent();
            OriginColumns = originCol;
            TargetColumns = targetcOL;
            TargetPath = Tpath;
            OriginPath = Opath;

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
        }

        private void LoadDataGrid()
        {
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FmWelcome fmWelcomev = new FmWelcome();
            this.Close();
            fmWelcomev.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Servic service = new Servic();
            Dictionary<string,string> Mapp = new Dictionary<string,string>();
            List<MapClass> Maps = new List<MapClass>();

            foreach (DataGridViewRow Row in Newdg.Rows)
            {
                int b = 0;
                MapClass map = new MapClass();
                if(Row.Cells[0].Value == null)
                {
                    continue;
                }
                else
                {
                    map.Old = Row.Cells[0].Value.ToString();
                    map.New = Row.Cells[1].Value.ToString();

                    if(map.Old == "...")
                    {
                        continue;
                    }
                    else
                    {
                        Maps.Add(map);
                    }
                }
            }

            bool Result = service.Reader(Maps , OriginPath , TargetPath );
            int i = 0;
        }

        private void dgColumns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ShowColumns_Load(object sender, EventArgs e)
        {

        }
    }
}

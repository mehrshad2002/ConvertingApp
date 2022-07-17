using ConvertingApp.AppForm;
namespace ConvertingApp
{
    public partial class FmWelcome : Form
    {
        public FmWelcome()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataFormat dataFormat = new DataFormat();
            this.Hide();
            dataFormat.Show();
        }
    }
}
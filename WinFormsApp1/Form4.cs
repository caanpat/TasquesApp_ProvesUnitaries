using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // conn = new SQLiteConnection(connectString);
            // conn.Open();
            // string sql = "SELECT task FROM tasca WHERE user_id=@user_id,status_id='2'";
            // cmd = new SQLiteCommand(sql, conn);
            // cmd.ExecuteNonQuery();
        }
    }
}

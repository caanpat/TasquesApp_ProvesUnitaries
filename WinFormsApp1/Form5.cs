using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TasquesApp;
using System.Data.SQLite;
namespace TasquesApp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            // connectString = @"Data Source=" + Application.StartupPath + @"\Database\tasquesapp";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //conn = new SQLiteConnection(connectString);
            //cmd = new SQLiteCommand();
            //cmd.CommandText = @"INSERT INTO member (firstname, lastname, address) VALUES(@firstname, @lastname, @address)";
            //cmd.Connection = conn;
            DialogResult resultat= MessageBox.Show("Correu correcte", "Comprobació", MessageBoxButtons.OK);
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
    }


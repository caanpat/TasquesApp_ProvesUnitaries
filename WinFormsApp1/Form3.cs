using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {

        //static List<string> llistatasques = new List<string>();
       // BindingSource llistatasquesBindingSource = new BindingSource();

        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string connectString;
        string path = Application.StartupPath + @"tasquesappP";
        // string sqlFormattedDate = Fecha.ToString("yyyy-MM-dd HH:mm:ss");

        public Form3()
        {
            InitializeComponent();

          //  llistatasquesBindingSource.DataSource = 





        }

        private void label1_Click(object sender, EventArgs e)
        {
            // sustituir usuari per @user


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //carregar dades existents del dia actual

            //tab pendents
            //SELECT task FROM tasca WHERE (user_id=@user.id , status_id=1, data= fecha actual)

            //tab finalitzades
            //SELECT task FROM tasca WHERE (user_id=@user.id , status_id=2, data= fecha actual)
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //llegir text de text.box1
            //insertar a la base de dades amb els valors corresponents
            //refresh de les dades per mostrar-ho al tab
            //crear variable donde recoja user_id
            conn = new SQLiteConnection(connectString);
            cmd = new SQLiteCommand();
            cmd.CommandText = "SELECT id FROM usuaris";
            cmd.Connection = conn;

            var user_id = cmd.CommandText;
            var fecha = DateTime.Now.ToString();

            try
            {
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = "INSERT INTO tasca (user_id, task, status_id, data) VALUES (@user_id, @task, @status_id, @data)";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@user_id", user_id));
                cmd.Parameters.Add(new SQLiteParameter("@task", textBox1.Text));
                cmd.Parameters.Add(new SQLiteParameter("@status_id", '1'));
                //   cmd.Parameters.Add(new SQLiteParameter("@data",));
                //   string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                conn.Open();
            }

            catch (Exception ex)
            { }

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //anar a les dades del dia seleccionat 
            // a form4
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // conn = new SQLiteConnection(connectString);
            // conn.Open();
            // string sql = "";
            // cmd = new SQLiteCommand(sql, conn);
            // cmd.ExecuteNonQuery();

        }

        private void ReadData()
        {
            try
            {
                conn = new SQLiteConnection(connectString);
                conn.Open();
                cmd = new SQLiteCommand();
                String sql = "SELECT * FROM usuaris";
                adapter = new SQLiteDataAdapter(sql, conn);
                ds.Reset();
                adapter.Fill(ds);
                dt = ds.Tables[0];
               /* dataGridView1.DataSource = dt;
                conn.Close();
                dataGridView1.Columns[1].HeaderText = "Firstname";
                dataGridView1.Columns[2].HeaderText = "Lastname";
                dataGridView1.Columns[3].HeaderText = "Address";
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }









        }
    }



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
using BCrypt.Net;
using TasquesApp;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string connectString;
        string path = Application.StartupPath + @"tasquesappP";
        

        public Form2()
        {
            InitializeComponent();
            connectString = @"Data Source=" + path;
            var BaseDatos = new StartControls();
            BaseDatos.GenerateDatabase();

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Registre(object sender, EventArgs e)
        {
            string usuari = textBox1.Text;
            string password = textBox2.Text;

            conn = new SQLiteConnection(connectString);
            conn.Open();
            string sql = "SELECT user FROM usuari WHERE user='" + usuari + "'";

            cmd = new SQLiteCommand(sql, conn);
            object resultat = cmd.ExecuteScalar();
            conn.Close();

            if (resultat != null)
            {
                usuari = "";
                password = "";
                DialogResult missatge = MessageBox.Show("Aquest usuari no està disponible.", "Error", MessageBoxButtons.OK);

                button2.Enabled = false;
            }
            else
            {
                var nuevoUser = new StartControls();
                nuevoUser.CreaUsuari(usuari, password);

                if (button2.Enabled == true)
                {
                    usuari = "";
                    password = "";

                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();
                }

            }



               
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            
        }



        /*
        private void GenerateDatabase()
        {
            if (!File.Exists(path))
            {
                conn = new SQLiteConnection(connectString);
                conn.Open();

                string sql = "CREATE TABLE usuari (id INTEGER PRIMARY KEY AUTOINCREMENT, user TEXT UNIQUE, password TEXT)";
                cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();

                string sql2 = "CREATE TABLE status (id INTEGER PRIMARY KEY, state TEXT)";
                cmd = new SQLiteCommand(sql2, conn);
                cmd.ExecuteNonQuery();

                string sql3 = "INSERT INTO status (id, state) VALUES (1,'pendent'); INSERT INTO status (id, state) VALUES (2,'acabat'); INSERT INTO status (id, state) VALUES (3,'incomplet')";
                cmd = new SQLiteCommand(sql3, conn);
                cmd.ExecuteNonQuery();

                string sql4 = "CREATE TABLE tasca (id INTEGER, user_id INTEGER, task TEXT NOT NULL, status_id INTEGER, data TEXT NOT NULL, PRIMARY KEY(id AUTOINCREMENT),FOREIGN KEY(status_id) REFERENCES status(id) ON UPDATE cascade,FOREIGN KEY(user_id) REFERENCES usuaris (id) ON UPDATE cascade ON DELETE set null)";
                cmd = new SQLiteCommand(sql4, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }*/


        private void CreaUsuari()
        {
            conn = new SQLiteConnection(connectString);
            conn.Open();
            string sql = "SELECT user FROM usuari WHERE user='" + textBox1.Text + "'";

            cmd = new SQLiteCommand(sql, conn);
            object resultat = cmd.ExecuteScalar();
            conn.Close();

            if (resultat != null)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                DialogResult missatge = MessageBox.Show("Aquest usuari no està disponible.", "Error", MessageBoxButtons.OK);

                button2.Enabled = false;
            }
            else
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    try
                    {
                        
                        //conexió
                        conn = new SQLiteConnection(connectString);
                        cmd = new SQLiteCommand();

                        // password a hash
                        string myPassword = textBox2.Text;
                        string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword);


                        //insertar usuari
                        cmd.CommandText = @"INSERT INTO usuari (user, password) VALUES(@user, @password)";
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SQLiteParameter("@user", textBox1.Text));
                        cmd.Parameters.Add(new SQLiteParameter("@password", myHash));

                        conn.Open();
                        int i = cmd.ExecuteNonQuery();

                        if (i == 1)
                        {
                            MessageBox.Show("Creat amb èxit!");
                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    conn.Close();
                }






            }



        }

    }
}

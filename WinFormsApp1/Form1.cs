using TasquesApp;
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



    public partial class Form1 : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        string connectString;
        string path = Application.StartupPath + @"tasquesappP";



        public Form1()
        {
            InitializeComponent();
            connectString = @"Data Source=" + path;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Login(object sender, EventArgs e)
        {

            string usuari = TextBox1.Text;
            string password = textBox2.Text;
            button1.Enabled= false;

            conn = new SQLiteConnection(connectString);
            conn.Open();
            string sql = "SELECT user FROM usuari WHERE user='" + usuari + "'";

            cmd= new SQLiteCommand(sql,conn);
            Object resultat = cmd.ExecuteScalar();
            
            conn.Close();

            if (resultat != null)
            {
                button1.Enabled = true;
                

                if (usuari !="" && password !="")
                {
                    try
                    {
                        var inicio = new Conexion();
                        bool iniciar= inicio.Login(usuari, password);

                        if (iniciar == true)
                        {
                            MessageBox.Show("Inici sessió correcte.");
                            TextBox1.Text = "";
                            textBox2.Text = "";

                           
                            
                            Form3 f3 = new Form3();
                                  f3.Show();
                                  this.Hide();
                        }



                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dades incorrectes", "Error", MessageBoxButtons.RetryCancel);

                    }
                }
            }
            else
            {
                MessageBox.Show("L'usuari o contrasenya no són vàlides. Torna a intentar-ho.");
                TextBox1.Text = "";
                textBox2.Text = "";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}





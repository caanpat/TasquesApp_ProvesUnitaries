using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1;

namespace TasquesApp
{
    public class Conexion
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string connectString;
        string path = Application.StartupPath + @"tasquesappP";

        public bool Login(string usuari, string password)
        {
            try
            {
                conn = new SQLiteConnection(connectString);
                cmd = new SQLiteCommand();
                cmd.CommandText = "SELECT password FROM usuari WHERE user=@user";
                cmd.Connection = conn;
                cmd.Parameters.Add(new SQLiteParameter("@user", usuari));
                conn.Open();


                //quitar hash
                string myPassword = password;
                object hash = cmd.ExecuteScalar();
                string myHash = hash.ToString();

                if (hash != null)
                {
                    bool verificat;
                    verificat = BCrypt.Net.BCrypt.Verify(myPassword, myHash);

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Dades incorrectes", "Error", MessageBoxButtons.RetryCancel);
                return false;
            }
        }


        public static class CacheID
        {
            public static string? id_user;
        }


        public string IdentificarID(string usuari)
        {
            conn = new SQLiteConnection(connectString);
            cmd = new SQLiteCommand();
            cmd.CommandText = "SELECT id FROM usuari WHERE user='" + usuari + "'";
            cmd.Connection = conn;
            cmd.Parameters.Add(new SQLiteParameter("@user", usuari));
            conn.Open();
            object myID = cmd.ExecuteScalar();
            string id = myID.ToString();
            //CacheID.id_user=id;


            return id;

            //Conexion.IdentificarID(usuari);
        }

        public void ReadData()
        {
            try
            {
                conn=new SQLiteConnection(connectString);
                conn.Open();
                cmd= new SQLiteCommand();
                string sql = "SELECT task FROM tasca";
                adapter = new SQLiteDataAdapter(sql, conn);
                ds.Reset();
                adapter.Fill(ds);
                dt= ds.Tables[0];
                checkedListBox1.DataSource = dt;

            }

        }

    }

}





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
    internal class StartControls 
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter adapter;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string connectString;
        string path = Application.StartupPath + @"tasquesappP";


        public void GenerateDatabase()
        {
            connectString = @"Data Source=" + path;

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
        }
        public int CreaUsuari(string usuari, string password)
        {
            connectString = @"Data Source=" + path;
            conn = new SQLiteConnection(connectString);
            conn.Open();
            string sql = "SELECT user FROM usuari WHERE user='" + usuari + "'";

            cmd = new SQLiteCommand(sql, conn);
            object resultat = cmd.ExecuteScalar();
            conn.Close();

            if (usuari != "" && password != "")
            {
                try
                {

                    //conexió
                    conn = new SQLiteConnection(connectString);
                    cmd = new SQLiteCommand();

                    // password a hash
                    string myPassword = password;
                    string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword);


                    //insertar usuari
                    cmd.CommandText = @"INSERT INTO usuari (user, password) VALUES(@user, @password)";
                    cmd.Connection = conn;
                    cmd.Parameters.Add(new SQLiteParameter("@user", usuari));
                    cmd.Parameters.Add(new SQLiteParameter("@password", myHash));

                    conn.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("Creat amb èxit!");

                        //hacer que haga return del id de usuario
                        cmd.CommandText = @"SELECT id FROM usuari";
                        cmd.Connection = conn;

                        //guardar id a una variable
                        conn.Open();
                        cmd = new SQLiteCommand(sql, conn);
                        object lastId = cmd.ExecuteScalar();
                        conn.Close();
                        int ultimoId = Convert.ToInt32(lastId);

                        return ultimoId;

                    }
                    else
                    {
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }

                conn.Close();
            }
            else
            {
                return 0;
            }
        }


    }
}






        



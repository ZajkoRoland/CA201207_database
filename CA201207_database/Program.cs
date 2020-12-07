using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace CA201207_database
{
    class Program
    {
        SqlConnection conn;
        public void Main(string[] args)
        {
            conn = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB;" +
                @"AttachDbFileName=|DataDirectory|\Resources\music.mdf;");
            conn.Open();
            Beolvasas();
            conn.Close();
            Console.ReadKey();
        }
        public void Beolvasas()
        {
            StreamReader sr = new StreamReader("pendulum.txt");
            bool albumok = false;
            SqlCommand command = new SqlCommand();
            command.CommandText = null;
            command.Connection = conn;
            command.CommandType = System.Data.CommandType.Text;
            while (!sr.EndOfStream)
            {
                string db = sr.ReadLine();
                if (db.Contains("[albums]"))
                {
                    albumok = true;
                }
                else if (db.Contains("[tracks]"))
                {
                    albumok = false;
                }
                string[] darabolas = db.Split(';');
                if (albumok) //albumok
                {
                    string id = darabolas[0];
                    string artist = darabolas[1];
                    string title = darabolas[2];
                    DateTime release = DateTime.Parse(darabolas[3]);
                    command.CommandText = $"INSERT INTO albums (id,aritst,title,realse) VALUES ('{id}','{artist}','{title}','{release.ToString("yyyy-MM-dd")}');";
                }
                else //trackek
                {
                    string cim = darabolas[0];
                    TimeSpan hossza = TimeSpan.Parse(darabolas[1]);
                    string albumm = darabolas[2];
                    string linkek = darabolas[3];
                    command.CommandText = $"INSERT INTO tracks (title,lenght,album,link) VAlUES  ('{cim}','{hossza}','{albumm}','{linkek}');";
                }
            }
        }
    }
}

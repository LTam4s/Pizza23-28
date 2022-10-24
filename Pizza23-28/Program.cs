using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAdatbazis
{
    class Program
    {

        static void Main(string[] args)
        {
            

            feladat23();
            feladat24();
            feladat25();
            feladat26();
            feladat27();
            feladat28();
        }
        private static void feladat23() {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT fnev, COUNT(rendeles.fazon) FROM futar, rendeles WHERE rendeles.fazon = futar.fazon GROUP BY fnev;";
                //-- Adatok lekérése ---
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    Console.WriteLine("23.Feladat");
                    Console.WriteLine("Hány házhoz szállítása volt az egyes futároknak?\n");
                    while (dr.Read())
                    {
                        string pazon = dr.GetString("fnev");
                        string pnev = dr.GetString(1);
                        Console.WriteLine($"{pazon} - {pnev}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.ReadKey();
            Console.Clear();
        }
        private static void feladat24()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT pnev, SUM(db) FROM pizza, tetel WHERE tetel.pazon = pizza.pazon GROUP BY pnev ORDER BY SUM(db) DESC;";
                //-- Adatok lekérése ---
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    Console.WriteLine("24.Feladat");
                    Console.WriteLine("A fogyasztás alapján mi a pizzák népszerűségi sorrendje?\n");
                    while (dr.Read())
                    {
                        string db = dr.GetString(1);
                        string pnev = dr.GetString("pnev");
                        Console.WriteLine($"{pnev} - {db}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.ReadKey();
            Console.Clear();
        }
        private static void feladat25()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT vnev, SUM(par * db) FROM vevo, rendeles, pizza, tetel WHERE rendeles.vazon = vevo.vazon AND rendeles.razon = tetel.razon AND tetel.pazon = pizza.pazon GROUP BY vnev ORDER BY SUM(par*db) DESC;";
                //-- Adatok lekérése ---
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    Console.WriteLine("25.Feladat");
                    Console.WriteLine("A rendelések összértéke alapján mi a vevők sorrendje?\n");

                    while (dr.Read())
                    {
                        string vnev = dr.GetString("vnev");
                        string pardb = dr.GetString(1);
                        Console.WriteLine($"{vnev} - {pardb}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.ReadKey();
            Console.Clear();
        }
        private static void feladat26()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT par, pnev FROM pizza ORDER BY par DESC LIMIT 1;";
                //-- Adatok lekérése ---
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    Console.WriteLine("26.Feladat");
                    Console.WriteLine("Melyik a legdrágább pizza?\n");

                    while (dr.Read())
                    {
                        string par = dr.GetString("par");
                        string pnev = dr.GetString("pnev");
                        Console.WriteLine($"{pnev} - {par}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.ReadKey();
            Console.Clear();
        }
        private static void feladat27()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT fnev, SUM(db) FROM futar, rendeles, tetel WHERE rendeles.razon = tetel.razon AND rendeles.fazon = futar.fazon GROUP BY fnev ORDER BY SUM(db) DESC LIMIT 1;;";
                //-- Adatok lekérése ---
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    Console.WriteLine("27.Feladat");
                    Console.WriteLine("Ki szállította házhoz a legtöbb pizzát?\n");
                    while (dr.Read())
                    {
                        string fnev = dr.GetString("fnev");
                        string db = dr.GetString(1);
                        Console.WriteLine($"{fnev} - {db}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.ReadKey();
            Console.Clear();
        }
        private static void feladat28()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT vnev, SUM(db) FROM vevo, rendeles, tetel WHERE rendeles.razon = tetel.razon AND rendeles.vazon = vevo.vazon GROUP BY vnev ORDER BY SUM(db) DESC LIMIT 1;";
                //-- Adatok lekérése ---
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    Console.WriteLine("28.Feladat");
                    Console.WriteLine("Ki ette a legtöbb pizzát?\n");
                    while (dr.Read())
                    {
                        string vnev = dr.GetString("vnev");
                        string db = dr.GetString(1);
                        Console.WriteLine($"{vnev} - {db}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
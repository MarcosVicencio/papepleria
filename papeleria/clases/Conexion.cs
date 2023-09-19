using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace papeleria.clases
{
    class Conexion
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "papeleria_dulce";
            string user = "root";
            string password = "";
            string puerto = "3306";

            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + user + ";" + "password=" + password + ";" + "database=" + bd + ";";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;
            }

            catch (MySqlException e)
            {
                Console.WriteLine("ERROR:" + e.Message);
                return null;
            }

        }
    }
}

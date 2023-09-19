using MySql.Data.MySqlClient;
using papeleria.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace papeleria
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String codigo = txtUser.Text;
            String password = txtPassword.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT codigo, contrasena FROM tadministradores WHERE codigo = '"+codigo+"' AND contrasena = '"+password+"' LIMIT 1";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Has Accedido!");
                }
                else
                {
                    MessageBox.Show("Error al acceder! Las Credenciales no son correctas!");
                    
                }
                txtPassword.Clear();
                txtUser.Clear();
            } catch(MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }
    }
}

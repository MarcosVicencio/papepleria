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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            double telVendedor = double.Parse(txtTelVendedor.Text);
            double telProveedor = double.Parse(txtTelProveedor.Text);
            double telEmpresa = double.Parse(txtTelEmpresa.Text);
            string rfc = txtRFC.Text;

            MySqlDataReader reader = null;
            string query = "INSERT INTO tproveedores (nombre, apellido, numeroTelProveedor, RFC, numeroVendedor, numeroTelEmpresa) VALUES ('" + nombre + "','" + apellido + "','" + telProveedor + "', '" + rfc + "', '" + telVendedor + "', '" + telEmpresa + "')";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                reader = comando.ExecuteReader();
                reader.Read();
                MessageBox.Show("Se han insertado los valores!");
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelVendedor.Clear();
                txtTelProveedor.Clear();
                txtTelEmpresa.Clear();
                txtRFC.Clear();
            }
            catch (MySqlException ex)
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

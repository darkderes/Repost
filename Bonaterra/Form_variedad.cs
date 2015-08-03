using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Bonaterra
{
    public partial class Form_variedad : Form
    {
        coneccion cn = new coneccion();
        public Form_variedad()
        {
            InitializeComponent();
        }

        private void Form_variedad_Load(object sender, EventArgs e)
        {
            especies_carga();
        }
        private void especies_carga()
        {
            cn.crearConeccion();
            MySqlCommand command = new MySqlCommand("especies_seleccionar", cn.getConexion());
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            DataSet myds = new DataSet();
            myAdapter.Fill(myds, "especies");
            cmb_especies.Refresh();
            cmb_especies.DataSource = myds.Tables["especies"].DefaultView;
            cmb_especies.DisplayMember = "especies_especie";
            cmb_especies.ValueMember = "especies_id";
            cmb_especies.SelectedIndex = 0;
            cn.cerrarConexion();
        }

        public void ingresar_variedad()
        {
            if (txt_cuadro.Text == "")
            {
                MessageBox.Show("El cuadro de texto no puede ser vacio", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_cuadro.Focus();
            }
            else
            {
                try
                {
                    cn.crearConeccion();
                    MySqlCommand command = new MySqlCommand("variedad_ingresar", cn.getConexion())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("especies", cmb_especies.SelectedValue.ToString());
                    command.Parameters.AddWithValue("variedad", txt_cuadro.Text.ToUpper());
                    command.ExecuteNonQuery();
                    cn.cerrarConexion();
                    MessageBox.Show("Dato ingresado correctamente", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.cerrarConexion();
                    this.Close();
                }
                catch { MessageBox.Show("Error con base de datos", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }


        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            ingresar_variedad();
        }
    }
}

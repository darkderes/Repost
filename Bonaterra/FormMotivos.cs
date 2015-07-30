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
    public partial class FormMotivos : Form
    {
        coneccion cn = new coneccion();
        public FormMotivos()
        {
            InitializeComponent();
        }

        private void FormMotivos_Load(object sender, EventArgs e)
        {
           
           
        }
       
        public void motivos_ingresar()
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
                    MySqlCommand command = new MySqlCommand("motivos_ingresar", cn.getConexion())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("motivo", txt_cuadro.Text.ToUpper());
                    command.ExecuteNonQuery();
                    cn.cerrarConexion();
                    MessageBox.Show("Dato ingresado correctamente", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.cerrarConexion();
                    this.Close();
                }
                catch { MessageBox.Show("Error con base de datos", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
         }
        public void especies_ingresar()
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
                    MySqlCommand command = new MySqlCommand("especies_ingresar", cn.getConexion())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("especie", txt_cuadro.Text.ToUpper());
                    command.ExecuteNonQuery();
                    cn.cerrarConexion();
                    MessageBox.Show("Dato ingresado correctamente", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.cerrarConexion();
                    this.Close();
                }
                catch { MessageBox.Show("Error con base de datos", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
        public void productor_ingresar()
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
                    MySqlCommand command = new MySqlCommand("productor_ingresar", cn.getConexion())
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("productor", txt_cuadro.Text.ToUpper());
                    command.ExecuteNonQuery();
                    cn.cerrarConexion();
                    MessageBox.Show("Dato ingresado correctamente", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.cerrarConexion();
                    this.Close();
                }
                catch { MessageBox.Show("Error con base de datos", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
        private void btn_ingreso_Click(object sender, EventArgs e)
        {
            if (Lbl_titulo.Text.Equals("Motivos"))
            {
                motivos_ingresar();
            }
            else
            if (Lbl_titulo.Text.Equals("Especies"))
            {
                especies_ingresar();
            }
            else
            if (Lbl_titulo.Text.Equals("Productor"))
            {
                productor_ingresar();
            }
        }
    }
}

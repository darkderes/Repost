using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Bonaterra
{
    public partial class Form_Principal : Form
    {
        FormMotivos m = new FormMotivos();
        coneccion cn = new coneccion();
        public Form_Principal()
        {
            InitializeComponent();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void Form_Principal_Load(object sender, EventArgs e)
        {
            try
            {
                motivos_carga();
                especies_carga();
                productor_carga();            }
            catch
            { }
        }
        public bool esvalida_la_hora(string thetime)
        {
            Regex checktime = new Regex("^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");
            if (!checktime.IsMatch(thetime))
                return false;

            if (thetime.Trim().Length < 5)
                thetime = thetime = "0" + thetime;

            string hh = thetime.Substring(0, 2);
            string mm = thetime.Substring(3, 2);

            int hh_i, mm_i;
            if ((int.TryParse(hh, out hh_i)) && (int.TryParse(mm, out mm_i)))
            {
                if ((hh_i >= 0 && hh_i <= 23) && (mm_i >= 0 && mm_i <= 59))
                {
                    return true;
                }
            }
            return false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (esvalida_la_hora(ms_turno_inicio.Text) == true)
            {
                lbl_error_1.Visible = false;
            }
            else
            {
                lbl_error_1.Visible = true;
                     
            }
            if (esvalida_la_hora(ms_turno_termino.Text) == true)
            {
                lbl_error_2.Visible = false;
            }
            else
            {
                lbl_error_2.Visible = true;

            }
            if (esvalida_la_hora(ms_colacion_inicio.Text) == true)
            {
                lbl_error_3.Visible = false;
            }
            else
            {
                lbl_error_3.Visible = true;

            }
            if (esvalida_la_hora(ms_colacion_termino.Text) == true)
            {
                lbl_error_4.Visible = false;
            }
            else
            {
                lbl_error_4.Visible = true;

            }
        }

        private void btn_motivo_Click(object sender, EventArgs e)
        {
            m = new FormMotivos();
            m.Lbl_titulo.Text = "Motivos";
            m.ShowDialog();
            motivos_carga();
        }

        private void btn_productor_Click(object sender, EventArgs e)
        {
            
            m.Lbl_titulo.Text = "Productor";
            m.ShowDialog();
            productor_carga();
        }

        private void btn_especies_Click(object sender, EventArgs e)
        {
            m.Lbl_titulo.Text = "Especies";
            m.ShowDialog();
            especies_carga();
        }

        private void motivos_carga()
        {      
            cn.crearConeccion();
            MySqlCommand command = new MySqlCommand("motivos_seleccionar", cn.getConexion());
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            DataSet myds = new DataSet();
            myAdapter.Fill(myds, "motivos");
            cmb_motivos.Refresh();
            cmb_motivos.DataSource = myds.Tables["motivos"].DefaultView;
            cmb_motivos.DisplayMember = "motivos_motivo";
            cmb_motivos.ValueMember = "motivo_Id";
            cmb_motivos.SelectedIndex = 0;
            cn.cerrarConexion();
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
        private void productor_carga()
        {
            cn.crearConeccion();
            MySqlCommand command = new MySqlCommand("productor_seleccionar", cn.getConexion());
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            DataSet myds = new DataSet();
            myAdapter.Fill(myds, "productor");
            cmb_productor.Refresh();
            cmb_productor.DataSource = myds.Tables["productor"].DefaultView;
            cmb_productor.DisplayMember = "productor_productor";
            cmb_productor.ValueMember = "productor_id";
            cmb_productor.SelectedIndex = 0;
            cn.cerrarConexion();
        }
    }
}

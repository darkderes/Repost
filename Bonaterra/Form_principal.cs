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
        public string rut = " ";
        int NumeroValor = 0;
        public Form_Principal()
        {
            InitializeComponent();
        }

     
        private void Form_Principal_Load(object sender, EventArgs e)
        {

            cmb_variedad.Enabled = false;
            radioButton1.Checked = true;
            radioButton3.Checked = true;
           
            try
            {
                especies_carga();        
            }
            catch
            { }
            extraerUltimo();
          
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
        public int extraerNumeroPedido()
        {
            cn.crearConeccion();
            MySqlCommand command = new MySqlCommand("contadorInforme", cn.getConexion());
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            DataSet myds = new DataSet();
            myAdapter.Fill(myds, "informe");
            using (MySqlDataReader rsd = command.ExecuteReader())
            {
                while (rsd.Read())
                {
                    NumeroValor = Convert.ToInt16(rsd[0].ToString());
                }

            }
            return NumeroValor;
            cn.cerrarConexion();

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormLogin s = new FormLogin();
            s.ShowDialog();

            /*   if (esvalida_la_hora(ms_turno_inicio.Text) == true)
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

               }*/
        }

        private void btn_motivo_Click(object sender, EventArgs e)
        {
            m = new FormMotivos();
            m.Lbl_titulo.Text = "Motivos";
            m.ShowDialog();
            //motivos_carga();
        }

   

        private void btn_especies_Click(object sender, EventArgs e)
        {
            m.Lbl_titulo.Text = "Especies";
            m.ShowDialog();
            especies_carga();
        }

   /*     private void motivos_carga()
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
        }*/
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
     /*   private void productor_carga()
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
        }*/
        private void variedad_carga()
        {
            cn.crearConeccion();
            MySqlCommand command = new MySqlCommand("variedad_seleccionar", cn.getConexion());
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("especie",cmb_especies.SelectedValue.ToString());
            DataSet myds = new DataSet();
            myAdapter.Fill(myds, "variedad");
            cmb_variedad.Refresh();
            cmb_variedad.DataSource = myds.Tables["variedad"].DefaultView;
            cmb_variedad.DisplayMember = "variedad_variedad";
            cmb_variedad.ValueMember = "variedad_id";
            cmb_variedad.SelectedIndex = 0;
            cn.cerrarConexion();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form_variedad v = new Form_variedad();
            v.ShowDialog();
            variedad_carga();
        }

        private void cmb_especies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_especies.SelectedIndex != 0)
            {
                variedad_carga();
                cmb_variedad.Enabled = true;
            }
            else
            {
                cmb_variedad.Enabled = false;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow filaNueva = new DataGridViewRow();
            DataGridViewCell celProductor = new DataGridViewTextBoxCell();
            DataGridViewCell celEspecie = new DataGridViewTextBoxCell();
            DataGridViewCell celEspecieId = new DataGridViewTextBoxCell();
            DataGridViewCell celVariedad = new DataGridViewTextBoxCell();
            DataGridViewCell celVariedadId = new DataGridViewTextBoxCell();
            DataGridViewCell celInicio = new DataGridViewTextBoxCell();
            DataGridViewCell celTermino = new DataGridViewTextBoxCell();
            DataGridViewCell celLote = new DataGridViewTextBoxCell();
            DataGridViewCell celBins = new DataGridViewTextBoxCell();

            celProductor.Value = txt_productor.Text;
            celEspecie.Value = cmb_especies.Text;
            celEspecieId.Value = cmb_especies.SelectedValue;
            celVariedad.Value = cmb_variedad.Text;
            celVariedadId.Value = cmb_variedad.SelectedValue;
            celInicio.Value = ms_inicio.Text;
            celTermino.Value = ms_termino.Text;
            celLote.Value = txt_lote.Text;
            celBins.Value = txt_bins.Text;
            filaNueva.Cells.Add(celProductor);
            filaNueva.Cells.Add(celEspecie);
            filaNueva.Cells.Add(celEspecieId);
            filaNueva.Cells.Add(celVariedad);
            filaNueva.Cells.Add(celVariedadId);
            filaNueva.Cells.Add(celInicio);
            filaNueva.Cells.Add(celTermino);
            filaNueva.Cells.Add(celLote);
            filaNueva.Cells.Add(celBins);
            dataGridView1.Rows.Add(filaNueva);

           // ingresar_procesado(txt_lote.Text,txt_productor.Text,ms_inicio.Text,ms_termino.Text,Convert.ToInt16(txt_bins.Text),Convert.ToInt16(lbl_numero.Text),Convert.ToInt16 (cmb_especies.SelectedValue.ToString()),Convert.ToInt16(cmb_variedad.SelectedValue.ToString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("boton 3 presionado");
        }
        public void ingresar_procesado(string lote,string productor,string proceso_inicio,string proceso_termino,int bins,int informe_id,int especies,int variedad)
        {
            cn.crearConeccion();
            MySqlCommand command = new MySqlCommand("insertar_procesado", cn.getConexion());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("lote",lote);
            command.Parameters.AddWithValue("productor",productor);
            command.Parameters.AddWithValue("proceso_inicio",proceso_inicio);
            command.Parameters.AddWithValue("proceso_termino",proceso_termino);
            command.Parameters.AddWithValue("bins",bins);
            command.Parameters.AddWithValue("informe_id",informe_id);
            command.Parameters.AddWithValue("especies",especies);
            command.Parameters.AddWithValue("variedad",variedad);
            command.ExecuteNonQuery();
            cn.cerrarConexion();
        }

        public void ingresar_inactivo(string lote, string motivo, string proceso_inicio, string proceso_termino,string observaciones, int informe_id)
        {
            cn.crearConeccion();
            MySqlCommand command = new MySqlCommand("insertar_inactivo", cn.getConexion());
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("lote", lote);
            command.Parameters.AddWithValue("motivo", motivo);
            command.Parameters.AddWithValue("inicio", proceso_inicio);
            command.Parameters.AddWithValue("termino", proceso_termino);
            command.Parameters.AddWithValue("observaciones",observaciones);
            command.Parameters.AddWithValue("informe", informe_id);
            command.ExecuteNonQuery();
            cn.cerrarConexion();


        }
        public void extraerUltimo()
        {
            int codigo = 0;
            extraerNumeroPedido();
            if (NumeroValor == 0)
            {
                NumeroValor = 10000;
                lbl_numero.Text = NumeroValor.ToString() ;
            }
            else
            {
              
                cn.crearConeccion();
                MySqlCommand command = new MySqlCommand("ultimoinforme", cn.getConexion());
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(command);
                command.CommandType = CommandType.StoredProcedure;
                DataSet myds = new DataSet();
                myAdapter.Fill(myds, "informe");
                using (MySqlDataReader rsd = command.ExecuteReader())
                {
                    while (rsd.Read())
                    {
                        codigo = Convert.ToInt32(rsd[0].ToString());
                    }
                    lbl_numero.Text = Convert.ToString(codigo + 1);
                }
            }
            cn.cerrarConexion();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaNueva = new DataGridViewRow();
            DataGridViewCell celLote = new DataGridViewTextBoxCell();
            DataGridViewCell celMotivo = new DataGridViewTextBoxCell();
            DataGridViewCell celInicio = new DataGridViewTextBoxCell();
            DataGridViewCell celTermino = new DataGridViewTextBoxCell();
            DataGridViewCell celObjetivo = new DataGridViewTextBoxCell();

            celLote.Value = txt_lote2.Text;
            celMotivo.Value = txt_motivo.Text;
            celInicio.Value = mk_inactivo_inicio.Text;
            celTermino.Value = mk_inactivo_termino.Text;
            celObjetivo.Value = rc_observacion.Text;
            filaNueva.Cells.Add(celLote);
            filaNueva.Cells.Add(celMotivo);
            filaNueva.Cells.Add(celInicio);
            filaNueva.Cells.Add(celTermino);
            filaNueva.Cells.Add(celObjetivo);
            dataGridView2.Rows.Add(filaNueva);

        }
        public void ingreso_informe()
        {
        string linea = "";
        string turno = "";
        cn.crearConeccion();
        MySqlCommand command = new MySqlCommand("insertar_informe", cn.getConexion());
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("id",Convert.ToInt16(lbl_numero.Text));
        command.Parameters.AddWithValue("fecha", dt_fecha.Text);
            if(radioButton1.Checked == true)
            {
                linea = "MAF";
            }
            else
            if(radioButton2.Checked == true)
            {
                linea = "UNITEC";
            }

            if (radioButton3.Checked == true)
            {
                turno = "Vespertino";
            }
            else
            if(radioButton4.Checked == true)
            {
                turno = "Diurno";
            }
        command.Parameters.AddWithValue("linea",linea);
        command.Parameters.AddWithValue("turno",turno);
        command.Parameters.AddWithValue("inicio",ms_turno_inicio.Text);
        command.Parameters.AddWithValue("termino",ms_turno_termino.Text);
        command.Parameters.AddWithValue("extras",ms_extras.Text);
        command.Parameters.AddWithValue("colacionInicio",ms_colacion_inicio.Text);
        command.Parameters.AddWithValue("colacionTermino",ms_colacion_termino.Text);
        command.Parameters.AddWithValue("rut", rut);
        command.ExecuteNonQuery();
        cn.cerrarConexion();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                ingreso_informe();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ingresar_procesado(dataGridView1.Rows[i].Cells[7].Value.ToString(), dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), dataGridView1.Rows[i].Cells[6].Value.ToString(), Convert.ToInt16(dataGridView1.Rows[i].Cells[8].Value.ToString()),Convert.ToInt16(lbl_numero.Text), Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value.ToString()), Convert.ToInt16(dataGridView1.Rows[i].Cells[4].Value.ToString()));

                }

                for (int x = 0; x < dataGridView2.RowCount; x++)
                {
                    ingresar_inactivo(dataGridView2.Rows[x].Cells[0].Value.ToString(), dataGridView2.Rows[x].Cells[1].Value.ToString(), dataGridView2.Rows[x].Cells[2].Value.ToString(), dataGridView2.Rows[x].Cells[3].Value.ToString(), dataGridView2.Rows[x].Cells[4].Value.ToString(),Convert.ToInt16(lbl_numero.Text));
                }

            }
            catch { MessageBox.Show("error al ingresar informacion", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            finally { extraerUltimo();
                MessageBox.Show("Datos ingresados correctamente", "Bonaterra", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
        }
    }
   

}

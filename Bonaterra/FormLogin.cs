using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

using System.IO;

namespace Bonaterra
{
    public partial class FormLogin : Form
    {
        coneccion cn = new coneccion();
        string nombre = "";
        public Image foto;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
        public static Image Bytes2Image(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                Bitmap bitmap = null;
                try
                {
                    bitmap = new Bitmap(stream);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                return bitmap;
            }
        }


        public Boolean buscar()
        {
            cn.crearConeccion();  
            MySqlCommand command = new MySqlCommand("login", cn.getConexion());
            MySqlDataAdapter myAdapter = new MySqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("rut1", txt_usuario.Text);
            command.Parameters.AddWithValue("pass1",txt_pass.Text);
                  
            using (MySqlDataReader rsd = command.ExecuteReader())
            {
                while (rsd.Read())
                {
                    nombre = rsd[0].ToString();
                    foto = Bytes2Image((byte[])rsd[1]);
                }
                
            }
               if(nombre.Equals(""))
               {
                return false;
               }
               else
               {
                return true;
               }
            cn.cerrarConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(buscar()==true)
            {
                this.Hide();
                Form_Principal s = new Form_Principal();
                s.txt_user.Text = nombre;
                s.pictureBox2.Image = foto;
                s.rut = txt_usuario.Text;
                s.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta","Bonaterra",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txt_usuario.Text = "";
                txt_pass.Text = "";
                txt_usuario.Focus();
            }
        }
    }
    }

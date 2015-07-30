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

namespace Bonaterra
{
    public partial class Form_Principal : Form
    {
        public Form_Principal()
        {
            InitializeComponent();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void Form_Principal_Load(object sender, EventArgs e)
        {

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

     
    }
}

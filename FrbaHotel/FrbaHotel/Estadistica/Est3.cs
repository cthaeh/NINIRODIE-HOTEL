using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Estadistica
{
    public partial class Est3 : Form
    {
        int dia_inicio, dia_fin, mes_inicio, mes_fin;
        String año;

        public Est3(int d_i, int d_f, int m_i, int m_f, String añ)
        {
            año = añ;
            dia_inicio = d_i;
            dia_fin = d_f;
            mes_fin = m_f;
            mes_inicio = m_i;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

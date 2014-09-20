using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Panel : Form
    {
        String tipo_usuario;

        public Panel(String tipo)
        {
            tipo_usuario = tipo;
            InitializeComponent();
            if (tipo == "admin")
            {
                abm_recep.Visible = true;
                abm_hot.Visible = true;
                abm_guest.Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

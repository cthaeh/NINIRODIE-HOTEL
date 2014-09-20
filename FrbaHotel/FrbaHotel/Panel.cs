using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Login;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.ABM_de_Cliente;

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
                abm_emp.Visible = true;
                abm_hot.Visible = true;
                abm_guest.Visible = false;
                abm_rol.Visible = true;
                abm_hab.Visible = true;
                cambiar_clave.Visible = true;
            }
            else if (tipo == "recep")
            {
                abm_emp.Visible = false;
                abm_hot.Visible = false;
                abm_guest.Visible = true;
                abm_rol.Visible = false;
                abm_hab.Visible = false;
                cambiar_clave.Visible = true;
            }
            else
            {
                abm_emp.Visible = false;
                abm_hot.Visible = false;
                abm_guest.Visible = false;
                abm_rol.Visible = false;
                abm_hab.Visible = false;
                cambiar_clave.Visible = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void cambiar_clave_Click(object sender, EventArgs e)
        {
            //ha CambiarClave se le debe enviar minimamente el codigo de usuario.
            new CambiarClave().ShowDialog(this);
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AltaEmp().ShowDialog(this);
        }

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new AltaCli().ShowDialog(this);
        }
    }
}

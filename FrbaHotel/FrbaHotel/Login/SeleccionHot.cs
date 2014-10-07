using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.Login
{
    public partial class SeleccionHot : Form
    {
        public string tipo;
        public Usuario usuario;
        public SeleccionHot(String tipousuario, Usuario usu)
        {
            tipo = tipousuario;
            usuario = usu;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se debe tomar el hotel selecionado y guardarlo como hotel asignado al 
            //usuario que se logeo.
            new Panel(tipo, usuario).ShowDialog(this);
            this.Close();
        }
    }
}

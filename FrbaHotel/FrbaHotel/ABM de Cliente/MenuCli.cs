using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Login;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class MenuCli : Form
    {
        Usuario usuario;
        public MenuCli()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CambiarClave(usuario).ShowDialog(this);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ModificarCli().ShowDialog(this);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DesbloquearCli().ShowDialog(this);
        }
    }
}

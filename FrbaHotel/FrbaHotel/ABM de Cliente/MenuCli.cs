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
        Cliente cliente_seleccionado;
        public MenuCli(Cliente cli)
        {
            cliente_seleccionado = cli;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CambiarClave(cliente_seleccionado.codigo_usuario).ShowDialog(this);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ModificarCli(cliente_seleccionado).ShowDialog(this);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DesbloquearCli(cliente_seleccionado).ShowDialog(this);
            this.Close();
        }
    }
}

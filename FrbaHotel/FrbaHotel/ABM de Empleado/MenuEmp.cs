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

namespace FrbaHotel.ABM_de_Empleado
{
    public partial class MenuEmp : Form
    {
        Usuario usuario;
        public MenuEmp(Usuario usu)
        {
            usuario = usu;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CambiarClave(usuario).ShowDialog(this);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new BusquedaModEmp().ShowDialog(this);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DesbloquearEmp().ShowDialog(this);
        }
    }
}

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
        Personal empleado_seleccionado;
        public MenuEmp(Personal per)
        {
            empleado_seleccionado = per;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CambiarClave(empleado_seleccionado.codigo_usuario).ShowDialog(this);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ModificarEmp(empleado_seleccionado).ShowDialog(this);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new DesbloquearEmp(empleado_seleccionado).ShowDialog(this);
            this.Close();
        }
    }
}

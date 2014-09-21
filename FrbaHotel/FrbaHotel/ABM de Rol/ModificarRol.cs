using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ModificarRol : Form
    {
        public ModificarRol()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            //Se deben setear los checkbox con la informacion que se trae de la base
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se debe ver que checkbox estan seleccionados y hardcodear los codigos
            //de funcionalidades para golpear a la base (Ver si lo hace un trigger)
        }
    }
}

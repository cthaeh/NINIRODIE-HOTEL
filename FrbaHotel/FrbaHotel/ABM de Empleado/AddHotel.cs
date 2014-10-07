using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.NINIRODIE.Repositorios;

namespace FrbaHotel.ABM_de_Empleado
{
    public partial class AddHotel : Form
    {
        Personal personal_seleccionado;

        public AddHotel(Personal per)
        {
            personal_seleccionado = per;
            InitializeComponent();
        }

        private void AddHotel_Load(object sender, EventArgs e)
        {
            List<Hotel> hoteles = RepositorioHotel.Instance.BuscarHoteles();

            //se deben traer los hoteles que tenga el empleado seleccionado en
            //hotel_usuario

            //armar una nueva lista para mandar a la grilla.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

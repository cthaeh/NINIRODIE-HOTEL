using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.LA_REVANCHA.Clases;

namespace FrbaHotel.ABM_Hotel
{
    public partial class MenuHot : Form
    {
        Hotel hotel_seleccionado;

        public MenuHot(Hotel hot)
        {
            hotel_seleccionado = hot;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ModificarHot(hotel_seleccionado).ShowDialog(this);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CerrarHot(hotel_seleccionado).ShowDialog(this);
            this.Close();
        }
    }
}

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

namespace FrbaHotel.ABM_Hotel
{
    public partial class BajaHot : Form
    {
        bool hab = false;
        bool des = false;
        Hotel hotel_seleccionado;

        public BajaHot(Hotel hot)
        {
            hotel_seleccionado = hot;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxhab_CheckedChanged(object sender, EventArgs e)
        {
            if (hab == false)
            {
                hab = true;
                checkBoxhab.Enabled = true;
                checkBoxdes.Enabled = false;
            }
            else
            {
                hab = false;
                checkBoxdes.Enabled = true;
            }
        }

        private void checkBoxdes_CheckedChanged(object sender, EventArgs e)
        {
            if (des == false)
            {
                des = true;
                checkBoxdes.Enabled = true;
                checkBoxhab.Enabled = false;
            }
            else
            {
                checkBoxhab.Enabled = true;
            }

        }

        private void BajaHot_Load(object sender, EventArgs e)
        {
            var hotel = RepositorioHotel.Instance.BuscarHotel(hotel_seleccionado.nombre);

            if (hotel.habilitado == false)
            {
                checkBoxhab.Enabled = true;
                checkBoxdes.Enabled = false;
            }
            else
            {
                checkBoxdes.Enabled = true;
                checkBoxhab.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int habilitar = 0;

            if (checkBoxdes.Checked)
            {
                habilitar = 0;
                RepositorioHotel.Instance.BajarHotelEmp(hotel_seleccionado.identificador, habilitar);
            }
            if (checkBoxhab.Checked)
            {
                habilitar = 1;
            }

            RepositorioHotel.Instance.BajarHotel(hotel_seleccionado.identificador, habilitar);

            
            MessageBox.Show("Se ha dado modificado exitosamente", "Alerta", MessageBoxButtons.OK);

            this.Close();
        }
    }
}

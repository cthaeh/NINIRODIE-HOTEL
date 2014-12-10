using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.LA_REVANCHA.Clases;
using FrbaHotel.LA_REVANCHA.Repositorios;

namespace FrbaHotel.ABM_Hotel
{
    public partial class CerrarHot : Form
    {
        Hotel hotel_seleccionado;

        public CerrarHot(Hotel hot)
        {
            hotel_seleccionado = hot;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese Un Motivo", "Alerta", MessageBoxButtons.OK);
            }
            else
            {
                if (dateTimePickeri.Value <= DateTime.Today)
                {
                    MessageBox.Show("La fecha de inicio de cierre debe ser posterior al dia de ayer", "Alerta", MessageBoxButtons.OK);
                }
                else
                {
                    int dias = (dateTimePickerf.Value - dateTimePickeri.Value).Days;
                    if (dias < 0)
                    {
                        MessageBox.Show("La fecha de fin debe ser mayor a la fecha de inicio", "Alerta", MessageBoxButtons.OK);
                    }
                    else
                    {
                        RepositorioHotel.Instance.CerrarHotel(hotel_seleccionado.identificador, dias, dateTimePickeri.Value, dateTimePickerf.Value, textBox1.Text);
                        MessageBox.Show("Programacion para cierre realizada con exito", "Alerta", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
        }
    }
}

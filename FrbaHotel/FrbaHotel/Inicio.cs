using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Login;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.LA_REVANCHA.Clases;

namespace FrbaHotel
{
    public partial class Inicio : Form
    {
        login login = new login();
        

        public Inicio()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            login.ShowDialog(this);
            MessageBox.Show("ADIOS!", "Alerta", MessageBoxButtons.OK);
            this.Close();
        }

        private void reserva_Click(object sender, EventArgs e)
        {
            new MenuInicio().ShowDialog(this);
            MessageBox.Show("ADIOS!", "Alerta", MessageBoxButtons.OK);
            this.Close();
        }
    }
}

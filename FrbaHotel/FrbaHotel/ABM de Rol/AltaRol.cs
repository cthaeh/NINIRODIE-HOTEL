using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Repositorios;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxnomb.Text == "")
            {
                MessageBox.Show("No deje campos vacios", "Alerta", MessageBoxButtons.OK);
            }
            else
            {
                RepositorioRol.Instance.InsertarRol(textBoxnomb.Text);

                Rol rol_seleccionado = RepositorioRol.Instance.BuscarRol(textBoxnomb.Text);

                if (checkBoxabmcli.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 103);
                }
                if (checkBoxabmemp.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 102);
                }
                if (checkBoxabmhab.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 105);
                }
                if (checkBoxabmres.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 106);
                }
                if (checkBoxabmrol.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 101);
                }
                if (checkBoxcon.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 108);
                }
                if (checkBoxest.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 107);
                }
                if (checkBoxfac.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 109);
                }
                if (checkBoxhot.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 104);
                }
                if (checkBoxlis.Checked == true)
                {
                    RepositorioRol.Instance.ActivarRol(rol_seleccionado.identificador, 110);
                }

                MessageBox.Show("Se dio de alta correctamente", "Alerta", MessageBoxButtons.OK);

                this.Close();
            }
            //Se debe ver que checkbox estan seleccionados y hardcodear los 
            //codigos de las funcionalidades para golpear a la base (Ver si lo hace un trigger)
        }
    }
}

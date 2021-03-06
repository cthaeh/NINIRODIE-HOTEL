﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.LA_REVANCHA.Repositorios;
using FrbaHotel.LA_REVANCHA.Clases;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class AltaRol : Form
    {
        bool seguir = true;

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
                Decimal bandera = RepositorioRol.Instance.ExisteRol(textBoxnomb.Text);
                if (bandera == 2)
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
                else
                {
                    MessageBox.Show("El nombre ya existe", "Alerta", MessageBoxButtons.OK);
                }
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.LA_REVANCHA.Clases;
using FrbaHotel.LA_REVANCHA.Repositorios;

namespace FrbaHotel.ABM_de_Empleado
{
    public partial class DesbloquearEmp : Form
    {
        bool hab = false;
        bool des = false;
        Personal empleado_seleccionado;

        public DesbloquearEmp(Personal per)
        {
            empleado_seleccionado = per;
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

        private void button1_Click(object sender, EventArgs e)
        {
            int habilitar = 0;

            if (checkBoxdes.Checked)
            {
                habilitar = 1;
            }
            if (checkBoxhab.Checked)
            {
                habilitar = 0;
            }

            RepositorioUsuario.Instance.BloquearUsuario(habilitar, empleado_seleccionado.codigo_usuario);

            MessageBox.Show("El cambio se ha realizado con exito", "Alerta", MessageBoxButtons.OK);

            this.Close();
        }

        private void DesbloquearEmp_Load(object sender, EventArgs e)
        {
            var user = RepositorioUsuario.Instance.BuscarUsuarioXCod(empleado_seleccionado.codigo_usuario);

            if (user.bloque == false)
            {
                checkBoxhab.Enabled = false;
                checkBoxdes.Enabled = true;
            }
            else
            {
                checkBoxdes.Enabled = false;
                checkBoxhab.Enabled = true;
            }
        }
    }
}

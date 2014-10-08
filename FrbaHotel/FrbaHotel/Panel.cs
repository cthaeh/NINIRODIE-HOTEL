using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Login;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.ABM_Hotel;
using FrbaHotel.ABM_de_Habitacion;
using FrbaHotel.ABM_de_Empleado;
using FrbaHotel.ABM_de_Rol;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel
{
    public partial class Panel : Form
    {
        String tipo_usuario;
        Usuario usuario;
        Hotel hotel_seleccionado;
        public Panel(String tipo, Usuario usu, Hotel hot)
        {
            hotel_seleccionado = hot;
            usuario = usu;
            tipo_usuario = tipo;
            InitializeComponent();

            if (tipo == "admin")
            {
                abm_emp.Visible = true;
                abm_hot.Visible = true;
                abm_guest.Visible = false;
                abm_rol.Visible = true;
                abm_hab.Visible = true;
                abm_reserva.Visible = false;
                estadia.Visible = false;
                consumible.Visible = false;
                estadistica.Visible = true;
                facturar.Visible = false;
            }
            else if (tipo == "recep")
            {
                abm_emp.Visible = false;
                abm_hot.Visible = false;
                abm_guest.Visible = true;
                abm_rol.Visible = false;
                abm_hab.Visible = false;
                abm_reserva.Visible = true;
                estadia.Visible = true;
                consumible.Visible = true;
                estadistica.Visible = false;
                facturar.Visible = true;
            }
            else if (tipo == "pulenta")
            {
                abm_emp.Visible = true;
                abm_hot.Visible = true;
                abm_guest.Visible = true;
                abm_rol.Visible = true;
                abm_hab.Visible = true;
                abm_reserva.Visible = true;
                estadia.Visible = true;
                consumible.Visible = true;
                estadistica.Visible = true;
                facturar.Visible = true;
            }else
            {
                abm_emp.Visible = false;
                abm_hot.Visible = false;
                abm_guest.Visible = false;
                abm_rol.Visible = false;
                abm_hab.Visible = false;
                abm_reserva.Visible = true;
                estadia.Visible = false;
                consumible.Visible = false;
                estadistica.Visible = false;
                facturar.Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AltaEmp().ShowDialog(this);
        }

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new AltaCli().ShowDialog(this);
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AltaHot().ShowDialog(this);
        }

        private void altqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AltaHab().ShowDialog(this);
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BusquedaBajaEmp().ShowDialog(this);
        }

        private void bajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BusquedaBajaCli().ShowDialog(this);
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BusquedaBajaHot().ShowDialog(this);
        }

        private void bajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BusquedaBajaHab().ShowDialog(this);
        }

        private void modificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BusquedaModCli().ShowDialog(this);
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BusquedaModEmp().ShowDialog(this);
        }

        private void modificarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new BusquedaModHab().ShowDialog(this);
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BusquedaModHot().ShowDialog(this);
        }

        private void abm_rol_ButtonClick(object sender, EventArgs e)
        {

        }

        private void bajaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new BusquedaBajaRol().ShowDialog(this);
        }

        private void modificarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new BusquedaModRol().ShowDialog(this);
        }

        private void altaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new AltaRol().ShowDialog(this);
        }

        private void Panel_Load(object sender, EventArgs e)
        {
        }
    }
}

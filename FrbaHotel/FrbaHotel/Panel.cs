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
using FrbaHotel.NINIRODIE.Repositorios;
using FrbaHotel.Estadistica;
using FrbaHotel.Registrar_Consumible;
using FrbaHotel.Facturar;

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

            if (tipo == "pulenta")
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
            }
            else
            {
                Rol rol = RepositorioRol.Instance.BuscarRol(tipo);
                List<FunRol> funrol = RepositorioRol.Instance.BuscarFunRol(rol.identificador);

                abm_emp.Visible = false;
                abm_hot.Visible = false;
                abm_guest.Visible = false;
                abm_rol.Visible = false;
                abm_hab.Visible = false;
                abm_reserva.Visible = false;
                estadia.Visible = false;
                consumible.Visible = false;
                estadistica.Visible = false;
                facturar.Visible = false;

                int n = 0;

                while (n < funrol.Count)
                {
                    if (funrol.ElementAt(n).cod_fun == 101)
                    {
                        abm_rol.Visible = true;
                    }
                    if (funrol.ElementAt(n).cod_fun == 102)
                    {
                        abm_emp.Visible = true;
                    }
                    if (funrol.ElementAt(n).cod_fun == 103)
                    {
                        abm_guest.Visible = true;
                    }
                    if (funrol.ElementAt(n).cod_fun == 104)
                    {
                        abm_hot.Visible = true;
                    }
                    if (funrol.ElementAt(n).cod_fun == 105)
                    {
                        abm_hab.Visible = true;
                    }
                    if (funrol.ElementAt(n).cod_fun == 106)
                    {
                        abm_reserva.Visible = true;
                    }
                    if (funrol.ElementAt(n).cod_fun == 107)
                    {
                        estadia.Visible = true;
                    }
                    if (funrol.ElementAt(n).cod_fun == 108)
                    {
                        consumible.Visible = true;
                    }
                    if (funrol.ElementAt(n).cod_fun == 109)
                    {
                        facturar.Visible = true;
                    }
                    if (funrol.ElementAt(n).cod_fun == 110)
                    {
                        estadistica.Visible = true;
                    }

                    n = n + 1;
                }
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
            new AltaHab(hotel_seleccionado).ShowDialog(this);
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
            new BusquedaBajaHab(hotel_seleccionado).ShowDialog(this);
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
            new BusquedaModHab(hotel_seleccionado).ShowDialog(this);
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

        private void estadistica_Click(object sender, EventArgs e)
        {
            new EstFecha().ShowDialog(this);
        }

        private void consumible_Click(object sender, EventArgs e)
        {
            new IngresarReserva().ShowDialog(this);
        }

        private void facturar_Click(object sender, EventArgs e)
        {
            new IngresarReserv().ShowDialog(this);
        }
    }
}

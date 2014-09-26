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
using FrbaHotel.ABM_Rol;

namespace FrbaHotel.ABM_Rol
{
    public partial class BajaModificacionRolWindow : Form
    {
        private List<Rol> Roles { get; set; }
        private Rol RolSeleccionado { get; set; }
        private RepositorioRol RepositoryRol { get; set; }
        private ModoApertura modoApertura { get; set; }

        public BajaModificacionRolWindow(ModoApertura modoApertura)
        {
            InitializeComponent();
            this.RepositoryRol = RepositorioRol.Instance;
            this.CrearGrilla();

            this.modoApertura = modoApertura;
            
            if (this.Roles != null)
            {
                this.RolSeleccionado = this.Roles.First();
            }
            this.CrearGrilla();
            this.PopularGrilla();

            this.grillaRoles.Columns[1].Visible = false;
            CrearBoton();
        }

        private void CrearBoton()
        {
            if (modoApertura == ModoApertura.BAJA)
            {
                this.Text = "Baja Rol";
                this.botonEditar.Text = "Baja";
                this.botonEditar.Click += new EventHandler(botonBaja_Click);
            }
            else
            {
                if (modoApertura == ModoApertura.ALTA)
                {
                    this.Text = "Alta Rol";
                    this.botonEditar.Text = "Alta";
                    this.botonEditar.Click += new EventHandler(botonAlta_Click);
                }
                else
                {
                    this.Text = "Modificación Rol";
                    this.botonEditar.Text = "Editar";
                    this.botonEditar.Click += new EventHandler(botonEditar_Click);
                }
            }
        }

        private void FiltrarRoles()
        {
            if (ModoApertura.BAJA == modoApertura)
                this.FiltrarGrillaHabilitadosParaLaBaja();
            else
                if (ModoApertura.ALTA == modoApertura)
                    this.FiltrarGrillaDeshabilitadosParaElAlta();
        }

        private void FiltrarGrillaHabilitadosParaLaBaja()
        {
            this.Roles = Roles.FindAll(rol => rol.Habilitado);
        }

        private void FiltrarGrillaDeshabilitadosParaElAlta()
        {
            this.Roles = Roles.FindAll(rol => !rol.Habilitado);
        }

        void botonAlta_Click(object sender, EventArgs e)
        {
            this.RolSeleccionado = (Rol)this.grillaRoles.CurrentRow.DataBoundItem;
            new RolWindow(this.RolSeleccionado, modoApertura).ShowDialog(this);
            this.PopularGrilla();
        }

        void botonEditar_Click(object sender, EventArgs e)
        {
            this.RolSeleccionado = (Rol)this.grillaRoles.CurrentRow.DataBoundItem;
            new RolWindow(this.RolSeleccionado, ModoApertura.MODIFICACION).ShowDialog(this);
            this.PopularGrilla();
        }

        private void botonBaja_Click(object sender, EventArgs e)
        {
            this.RolSeleccionado = (Rol)this.grillaRoles.CurrentRow.DataBoundItem;
            new RolWindow(this.RolSeleccionado, ModoApertura.BAJA).ShowDialog(this);
            this.PopularGrilla();
        }


        private void CrearGrilla()
        {
            this.Roles = this.RepositoryRol.All();
        }

        private void PopularGrilla()
        {
            this.FiltrarRoles();
            this.grillaRoles.DataSource = this.Roles;
            this.grillaRoles.Refresh();
        }

        public virtual void textNombre_TextChanged(object sender, EventArgs e)
        {
            String nombre = textNombre.Text;
            List<Rol> resultado = this.Roles.FindAll(rol => rol.NombreRol.Contains(nombre));
            this.Roles = resultado;

            if (nombre == "")
            {
                this.CrearGrilla();
                this.FiltrarRoles();
            }
                this.PopularGrilla();
        }

        private void botonLimpiar_Click(object sender, MouseEventArgs e)
        {
            this.textNombre.Text = "";
            //this.CrearGrilla();
        }

        private void salirBoton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

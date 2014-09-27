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

namespace FrbaHotel.ABM_Rol
{
    public partial class RolWindow : Form
    {  
        private List<Funcionalidad> FuncionalidadesUtilizadas { get; set; }
        private List<Funcionalidad> FuncionalidadesDisponibles { get; set; }
        private RepositorioFuncionalidad RepositoryFuncionalidad { get; set; }
        private RepositorioRol RepositoryRol { get; set; }
        private RepositorioUsuario RepositoryUsuario { get; set; }
        private ModoApertura ModoApertura { get; set; }
        private Boolean Estado { get; set; }
       
        private Rol Rol { get; set; }

        public RolWindow()
        {
            InitializeComponent();
            this.RepositoryFuncionalidad = RepositorioFuncionalidad.Instance;
            this.RepositoryRol = RepositorioRol.Instance;
            this.RepositoryUsuario = RepositorioUsuario.Instance;
        }

        public RolWindow(Rol rol, ModoApertura modo)
            : this()
        {
            this.Rol = rol;
            this.ObtenerFuncionalidadesDelRol();
            this.PopularListas();
            this.textNombre.Text = this.Rol.NombreRol;
            this.checkHabilitar.Checked = this.Rol.Habilitado;
            this.ModoApertura = modo;
            ControlarControlesAHabilitar();
        }

        private void ControlarControlesAHabilitar()
        {
            if (this.ModoApertura == ModoApertura.GENERACION)
            {
                this.botonAceptar.Click += new EventHandler(botonGeneracion_Click);
            }
            else
            {
                if (this.Rol.NombreRol == Rol.ADMIN ||
                    this.Rol.NombreRol == Rol.RECEP ||
                    this.Rol.NombreRol == Rol.GUEST)
                {
                    this.checkHabilitar.Enabled = false;
                    if (this.ModoApertura == ModoApertura.BAJA)
                    {
                        DeshabilitarControlesBajaCliUsuEmp();
                    }
                }
                if (this.ModoApertura == ModoApertura.BAJA)
                {
                    DeshabilitarControlesBaja();
                    this.Text = "Baja Rol";
                    this.botonAceptar.Click += new EventHandler(botonBaja_Click);
                }
                if (this.ModoApertura == ModoApertura.MODIFICACION)
                {
                    this.checkHabilitar.Enabled = false;
                    this.Text = "Modificación Rol";
                    this.botonAceptar.Click += new EventHandler(botonModificar_Click);
                }
                if (this.ModoApertura == ModoApertura.ALTA)
                {
                    this.DeshabilitarControlesBaja();
                    this.botonAceptar.Text = "Habilitar";
                    this.botonAceptar.Click += new EventHandler(botonHabilitar_Click);
                }
            }
        }

        void botonGeneracion_Click(object sender, EventArgs e)
        {
            this.AgregarRolConFuncionalidades();
            MessageBox.Show("Se ha agregado el Rol exitosamente", "Reporte",
               MessageBoxButtons.OK);

            this.Close();
        }

        void botonModificar_Click(object sender, EventArgs e)
        {
            this.ModificarAlRolConSusFuncionalidades();
            MessageBox.Show("Se ha modificado el Rol exitosamente", "Reporte",
                MessageBoxButtons.OK);

            this.Close();
        }

        void botonBaja_Click(object sender, EventArgs e)
        {
            this.DarDeBajaAUnRol();
        }

        void botonHabilitar_Click(object sender, EventArgs e)
        {
            if (this.checkHabilitar.Checked)
            {
                this.Rol.Habilitado = this.checkHabilitar.Checked;
                RepositorioRol.Instance.CambiarHabilitacionRol(Rol);
                MessageBox.Show("Se ha dado de alta al Rol", "Reporte", MessageBoxButtons.OK);
                this.Close();
            }
            else
                MessageBox.Show("Para dar de alta al rol debe marcar la opción correspondiente.",
                    "Atención", MessageBoxButtons.OK);
        }

        private void DeshabilitarControlesBajaCliUsuEmp()
        {
            MessageBox.Show("No puede dar de baja a este Rol.\n" +
                "Oprima Cancelar para salir.", "Atención", MessageBoxButtons.OK);
        }

        private void DeshabilitarControlesBaja()
        {
            this.botonAgregar.Enabled = false;
            this.botonQuitar.Enabled = false;
            this.listFuncionesDisponibles.Enabled = false;
            this.listFuncionesUtilizadas.Enabled = false;
            this.textNombre.ReadOnly = true;
        }

        public void ObtenerFuncionalidadesDelRol()
        {
            this.Rol.Funcionalidades = this.RepositoryFuncionalidad.FuncionalidadesDeRol(this.Rol);
        }

        
        private void PopularListas()
        {
            this.FuncionalidadesDisponibles = this.RepositoryFuncionalidad.FuncionalidadesDisponiblesPara(this.Rol);
            this.FuncionalidadesUtilizadas = Rol.Funcionalidades;
            this.PopularListasDeSeleccion();
        }

        
        private void botonAgregar_Click(object sender, EventArgs e)
        {
            var funcionalidadesAAgregar = this.listFuncionesDisponibles.SelectedItems;

            foreach (Funcionalidad funcionalidad in funcionalidadesAAgregar)
            {
                this.FuncionalidadesUtilizadas.Add(funcionalidad);
                this.FuncionalidadesDisponibles.Remove(funcionalidad);
            }

            PopularListasDeSeleccion();
            this.Estado = true;
        }

        private void PopularListasDeSeleccion()
        {
            this.listFuncionesUtilizadas.DataSource = new List<Funcionalidad>();
            this.listFuncionesDisponibles.DataSource = new List<Funcionalidad>();
            this.listFuncionesUtilizadas.Refresh();
            this.listFuncionesDisponibles.Refresh();

            this.listFuncionesUtilizadas.DataSource = this.FuncionalidadesUtilizadas;
            this.listFuncionesDisponibles.DataSource = this.FuncionalidadesDisponibles;
            this.listFuncionesUtilizadas.Refresh();
            this.listFuncionesDisponibles.Refresh();
        }

        private void botonQuitar_Click(object sender, EventArgs e) 
        {
            var funcionalidadesAQuitar = this.listFuncionesUtilizadas.SelectedItems;

            foreach (Funcionalidad funcionalidad in funcionalidadesAQuitar)
            {
                this.FuncionalidadesDisponibles.Add(funcionalidad);
                this.FuncionalidadesUtilizadas.Remove(funcionalidad);
            }

            this.PopularListasDeSeleccion();

            this.Estado = true;
                                   
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            this.Rol.cambiarNombre(this.textNombre.Text);
            this.Rol.Funcionalidades = this.FuncionalidadesUtilizadas;
        }

        private void DarDeBajaAUnRol()
        {
            if (this.Rol.Habilitado)
                MessageBox.Show("Debe deshabilitar el Rol si quiere continuar.\n" +
                    "Si no desea deshabilitarlo, oprima Cancelar.", "Atención",
                    MessageBoxButtons.OK);
            else
            {
                RepositorioRol.Instance.CambiarHabilitacionRol(Rol);

                MessageBox.Show("Se ha dado de baja al Rol exitosamente", "Reporte",
                    MessageBoxButtons.OK);

                this.Close();
            }
        }

        private void AgregarRolConFuncionalidades()
        {
            this.RepositoryRol.AgregarRol(this.Rol);
            this.Rol.identificador = (int) this.RepositoryRol.NuevoId();
            if (this.Estado){
                this.RepositoryFuncionalidad.AgregarFuncionalidades(this.Rol);
            }
        }

        private void ModificarAlRolConSusFuncionalidades()
        {
            this.RepositoryRol.ModificarRol(this.Rol);
            if(this.Estado)
            {
                this.RepositoryFuncionalidad.ModificarFuncionalidades(this.Rol, this.FuncionalidadesDisponibles);
            }
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkHabilitar_CheckedChanged(object sender, EventArgs e)
        {
            this.Rol.Habilitado = this.checkHabilitar.Checked;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

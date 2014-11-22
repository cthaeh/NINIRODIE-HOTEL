﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Repositorios;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.Login
{
    public partial class login : Form
    {
        public string id = null, pass = null, usuario = null;
        public bool logeo = false, cerrar = false, pasar = false;
        public int intentos_fallidos = 0;
        public string tipo;
        public decimal intentos = 0;
        public decimal error_admin = 0;

        public login()
        {
            InitializeComponent();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ID_Usuario_TextChanged(object sender, EventArgs e)
        {
            id = this.ID_Usuario.Text;
        }

        private void Pass_usuario_TextChanged(object sender, EventArgs e)
        {
            pass = this.Pass_usuario.Text;
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            Usuario usu_aux = new Usuario();
            bool salio = false;
            if (ID_Usuario.Text == "admin")
            {
                if (Pass_usuario.Text == "w23e")
                {
                    usu_aux = RepositorioUsuario.Instance.BuscarUsuario(ID_Usuario.Text);
                    MessageBox.Show("Ud. se esta logueando con un usuario de altos privilegios, por favor sea cuidadoso con su uso", "Alerta", MessageBoxButtons.OK);
                    cerrar = true;
                    new SeleccionHot("pulenta", usu_aux).ShowDialog(this);
                    salio = true;
                    this.Close();
                }
                else
                {
                    error_admin = error_admin + 1;
                    if (error_admin == 3)
                    {
                        MessageBox.Show("Esta bien que el admin no se bloque, pero intenta no equivocarte tanto", "Alerta", MessageBoxButtons.OK);
                    }
                    cerrar = true;
                }
            }
            if (cerrar == false)
            {
                Usuario usu = RepositorioUsuario.Instance.BuscarUsuario(ID_Usuario.Text);
                if (usu.codigo == -1)
                {
                    MessageBox.Show("Usuario o Contraseña incorrectos", "Alerta", MessageBoxButtons.OK);
                    pasar = true;
                }
                if (pasar == false)
                {
                    if (EstaTipoBloqueado(usu.tipo) == false)
                    {
                        if (usu.habilitado == true)
                        {
                            if (usu.bloque == false)
                            {
                                if (usu.pass == this.Pass_usuario.Text)
                                {
                                    new SeleccionHot(usu.tipo, usu).ShowDialog(this);
                                    salio = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Usuario o Contraseña incorrectos", "Alerta", MessageBoxButtons.OK);
                               
                                    intentos = intentos + 1;
                                    if (intentos == 3)
                                    {
                                        RepositorioUsuario.Instance.BloquearUsuario(usu.codigo);
                                        MessageBox.Show("El usuario ha sido bloqueado", "Alerta", MessageBoxButtons.OK);
                                        this.Close();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Este usuario esta deshabilitado o bloqueado", "Alerta", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este usuario esta deshabilitado o bloqueado", "Alerta", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tipo de usuario des-habilitado", "Alerta", MessageBoxButtons.OK);
                    }
                }
            }

            if (salio == true)
            {
                this.Close();
            }
            
        }

        private bool EstaTipoBloqueado(String tipo)
        {
            List<Rol> roles = RepositorioRol.Instance.BuscarRoles();

            int n = 0;
            bool bloqueado = false;

            while (n < roles.Count)
            {
                if (roles.ElementAt(n).descripcion == tipo)
                {
                    if (roles.ElementAt(n).habilitado == false)
                    {
                        bloqueado = true;
                    }

                }
                n = n + 1;
            }

            return bloqueado;
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}


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

namespace FrbaHotel.Login
{
    public partial class login : Form
    {
        public string id = null, pass = null, usuario = null;
        public bool logeo = false, cerrar = false, pasar = false;
        public int intentos_fallidos = 0;
        public string tipo;
        public decimal intentos = 0;

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
            Usuario usu = RepositorioUsuario.Instance.BuscarUsuario(ID_Usuario.Text);
            if (usu.codigo == -1)
            {
                MessageBox.Show("Usuario o Contraseña incorrectos", "Alerta", MessageBoxButtons.OK);
                pasar = true;
            }
            if (pasar == false)
            {
                if (usu.pass == this.Pass_usuario.Text)
                {
                    if (usu.habilitado == true)
                    {
                        if (usu.bloque == false)
                        {
                            if (usu.tipo == "CLIENTE")
                            {
                                tipo = "guest";
                                new SeleccionHot(tipo, usu).ShowDialog(this);
                                this.Close();
                            }
                            else if (usu.tipo == "ADMIN")
                            {
                                tipo = "admin";
                                new SeleccionHot(tipo, usu).ShowDialog(this);
                                this.Close();
                            }
                            else
                            {
                                tipo = "recep";
                                new SeleccionHot(tipo, usu).ShowDialog(this);
                                this.Close();
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
                    intentos = intentos + 1;
                    if (intentos == 3)
                    {
                        RepositorioUsuario.Instance.BloquearUsuario(usu.codigo);
                        MessageBox.Show("El usuario ha sido bloqueado", "Alerta", MessageBoxButtons.OK);
                        this.Close();
                    }
                    MessageBox.Show("Usuario o Contraseña incorrectos", "Alerta", MessageBoxButtons.OK);
                
                }
            }
            
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}


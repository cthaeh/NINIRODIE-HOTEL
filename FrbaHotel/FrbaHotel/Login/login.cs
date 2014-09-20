using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class login : Form
    {
        public string id = null, pass = null, usuario = null;
        public bool logeo = false, cerrar = false;
        public int intentos_fallidos = 0;
        public string tipo;

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
            if (this.ID_Usuario.Text == "diego" && this.Pass_usuario.Text == "w23e")
            {
                tipo = "admin";

                new Panel(tipo).ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Error", "Alerta", MessageBoxButtons.OK);
            }
            //EsCorrecto(id) --> Se debe consultar a la base por el ID y traer un
            //objeto usuario con todos los datos que le corresponden al dueño de esa ID
            /*
            if ( user.id == id){
                if (user.pass == pass){
                    if (user.habilitado == true)
                    {
                        if (user.bloque == false)
                        {
                            if (user.prim == false)
                            {
                                intentos_fallidos = 0;
                                logeo = true;
                                this.Close();
                            }
                            else
                            {
                                //Se debe exigir el cambio de la contraseña
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario ha sido bloqueado.",
                        "Atención", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario esta deshabilitado.",
                        "Atención", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    intentos_fallidos = intentos_fallidos + 1;
              
                    if (intentos_fallidos == 3)
                    {
                        //Se debe bloquear el usuario
             
                   MessageBox.Show("El usuario ha sido bloqueado.",
                        "Atención", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Id o Password Incorrectos.",
                    "Atención", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Id o Password Incorrectos.",
                    "Atención", MessageBoxButtons.OK);
            }
                  
        */
        }
    }
}

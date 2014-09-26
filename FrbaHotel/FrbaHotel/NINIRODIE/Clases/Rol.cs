using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    public class Rol
    {
        public static String ADMIN = "ADMINISTRADOR";
        public static String RECEP = "RECEPCIONISTA";
        public static String GUEST = "GUEST";

        public Decimal identificador { get; set; }
        public String descripcion { get; set; }
        public bool Habilitado { get; set; }
        public String NombreRol { get; set; }
        public List<Funcionalidad> Funcionalidades { get; set; }

        public Rol(Decimal id, String desc, bool hab)
        {
            identificador = id;
            descripcion = desc;
            Habilitado = hab;
        }

        public Rol()
        {
            this.Funcionalidades = new List<Funcionalidad>();
        }

        public Rol(string Rol)
            : this()
        {
            this.NombreRol = Rol;
        }

        public Rol(int id, string nombre, Boolean habilitado)
            : this(nombre)
        {
            this.identificador = id;
            this.Habilitado = habilitado;
        }

        public void cambiarNombre(String nombre)
        {
            this.NombreRol = nombre;
        }

        public void AgregarFuncionalidades(List<Funcionalidad> funcionalidades)
        {
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                Funcionalidades.Add(funcionalidad);
            }
        }
    }
}

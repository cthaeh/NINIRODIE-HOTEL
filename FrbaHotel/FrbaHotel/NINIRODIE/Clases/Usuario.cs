using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Clases
{
    class Usuario
    {
        public Decimal codigo { get; set; }
        public String username { get; set; }
        public String pass { get; set; }
        public bool habilitado { get; set; }
        public String tipo { get; set; }
        public bool bloque { get; set; }

        public Usuario()
        {
            codigo = -1;
        }

        public Usuario(Decimal cod, String iD, String password, bool habili,
            String type, bool bloqueado)
        {
            codigo = cod;
            username = iD;
            pass = password;
            habilitado = habili;
            tipo = type;
            bloque = bloqueado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioUsuario
    {
        private static RepositorioUsuario _instance;

        public static RepositorioUsuario Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioUsuario();
                }
                return _instance;
            }
        }
    }
}

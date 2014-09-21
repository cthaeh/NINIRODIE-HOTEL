using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioCliente
    {
        private static RepositorioCliente _instance;

        public static RepositorioCliente Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioCliente();
                }
                return _instance;
            }
        }
    }
}

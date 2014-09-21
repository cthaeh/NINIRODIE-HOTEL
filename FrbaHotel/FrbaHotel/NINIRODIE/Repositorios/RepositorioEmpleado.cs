using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioEmpleado
    {
        private static RepositorioEmpleado _instance;

        public static RepositorioEmpleado Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioEmpleado();
                }
                return _instance;
            }
        }
    }
}

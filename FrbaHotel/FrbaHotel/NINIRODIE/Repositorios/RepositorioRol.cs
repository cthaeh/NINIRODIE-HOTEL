using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioRol
    {
        private static RepositorioRol _instance;

        public static RepositorioRol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioRol();
                }
                return _instance;
            }
        }
    }
}

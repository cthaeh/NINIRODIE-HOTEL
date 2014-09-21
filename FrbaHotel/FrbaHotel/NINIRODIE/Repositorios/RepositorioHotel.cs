using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioHotel
    {
        private static RepositorioHotel _instance;

        public static RepositorioHotel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioHotel();
                }
                return _instance;
            }
        }
    }
}

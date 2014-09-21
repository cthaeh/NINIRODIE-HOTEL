using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaHotel.NINIRODIE.Repositorios
{
    class RepositorioHabitacion
    {
        private static RepositorioHabitacion _instance;

        public static RepositorioHabitacion Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositorioHabitacion();
                }
                return _instance;
            }
        }
    }
}

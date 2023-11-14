using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO201_ejMuseo01
{
    class Galeria
    {
        private int id;
        private String nombre;
        private List<Exposicion> listadoExposiciones;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Exposicion> ListadoExposiciones
        {
            get { return listadoExposiciones; }
            set { listadoExposiciones = value; }

        }
        public Galeria(int id, String nombre, List<Exposicion> listadoExposiciones)
        {
            Id = id;
            Nombre = nombre;
            ListadoExposiciones = listadoExposiciones;
        }


    }
}

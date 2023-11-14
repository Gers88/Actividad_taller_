using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO201_ejMuseo01
{
    class Exposicion
    {
        private int id;
        private String nombre;
        private String fechaInicio;
        private String fechaTermino;
        private List<ObraArte> listadoObras;

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

        public String FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        public String FechaTermino
        {
            get { return fechaTermino; }
            set { fechaTermino = value; }
        }
        public List<ObraArte> ListadoObras
        {
            get { return listadoObras; }
            set { listadoObras = value; }

        }
        public Exposicion(int id, string nombre, string fechaInicio, string fechaTermino, List<ObraArte> listadoObras)
        {
            Id = id;
            Nombre = nombre;
            FechaInicio = fechaInicio;
            FechaTermino = fechaTermino;
            ListadoObras = listadoObras;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO201_ejMuseo01
{
    public abstract class Empleado
    {
        private int id;
        private String usuario;
        private String nombre;
        private String apellido;
        private String password;

        public int Id
        { get { return id; } 
        set {  id = value; } 
        }

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }









    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO201_ejMuseo01
{
    class Administrador : Empleado
    {


        //CONSTRUCTOR
        //Visibilidad NOMBRE_CLASE(PARÁMETROS -> tipo y el nombre)
        public Administrador(int id, String usuario, String nombre, String apellido, String password)
        {
            Id = id;
            Usuario = usuario;
            Nombre = nombre;
            Apellido = apellido;
            Password = password;
        }


    }
}

using PRO201_ejMuseo01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Listado con 2 Administradores
            //Paso1: Crear lista vacía
            //List<NOMBRE_CLASE> nombrelista = new List<NOMBRE_CLASE>();
            List<Administrador> listadoAdministradores = new List<Administrador>();
            //Paso2: Agregar objetos directamente al listado (utilizamos el constructor)
            listadoAdministradores.Add(new Administrador(1, "jperez", "Juan", "´Pérez", "12345"));
            listadoAdministradores.Add(new Administrador(1, "adiaz", "Andrea", "´Díaz", "54321"));

            //Listado con 2 Guías
            List<Guia> listadoGuias = new List<Guia>();
            listadoGuias.Add(new Guia(1, "mgonzalez", "Marcela", "´Gonzalez", "12345"));
            listadoGuias.Add(new Guia(1, "opereira", "Octavio", "´Pereira", "54321"));

            //Listado con todas las obras del museo: con 4 Obras de arte
            //LISTADO = [0] , [1] , [2] , [3]
            List<ObraArte> listadoObraArte = new List<ObraArte>();
            listadoObraArte.Add(new ObraArte(1, "La Mona Lisa", "Leonardo da Vinci", "1503 - 1506", "XX"));
            listadoObraArte.Add(new ObraArte(2, "La noche estrellada", "Vincent van Gogh", "1889", "YY"));
            listadoObraArte.Add(new ObraArte(3, "La persistencia de la memoria", "Salvador Dalí", "1503 - 1506", "JJ"));
            listadoObraArte.Add(new ObraArte(4, "La creación de Adán", "Miguel Ángel", "1512", "UU"));

            //Listado con 2 Exposiciones
            //Crear lista de obras que van en exposición 1 //Listado de obras a agregar a exposición
            List<ObraArte> obrasExposicion1 = new List<ObraArte>();
            //1 exposición con 3 obras de arte
            //Utilizando 3 obras del listado principal en listado de exposición
            obrasExposicion1.Add(listadoObraArte[0]);
            obrasExposicion1.Add(listadoObraArte[1]);
            obrasExposicion1.Add(listadoObraArte[2]);
            Exposicion exposicion1 = new Exposicion(1, "Exposición de Obras Famosas", "2023-11-01", "2023-12-01", obrasExposicion1);
            //1 exposicion con 2 obras de arte
            List<ObraArte> obrasExposicion2 = new List<ObraArte>();
            obrasExposicion1.Add(listadoObraArte[3]);
            obrasExposicion1.Add(listadoObraArte[2]);
            Exposicion exposicion2 = new Exposicion(2, "Exposición de Arte Renacentista", "2023-12-15", "2023-01-15", obrasExposicion2);

            //CREAR LISTADO DE EXPOSICIONES
            List<Exposicion> listadoExposiciones = new List<Exposicion>();
            listadoExposiciones.Add(exposicion1);
            listadoExposiciones.Add(exposicion2);

            //Listado con 1 Galería (con 1 exposición)
            List<Exposicion> listadoExposicionesGaleria = new List<Exposicion>();
            listadoExposicionesGaleria.Add(exposicion1);

            Galeria galeria = new Galeria(1, "Mi Galeria", listadoExposicionesGaleria);
            List<Galeria> listadoGalerias = new List<Galeria>();
            listadoGalerias.Add(galeria);

            //VALIDAR QUE EXISTE USUARIO ** PENDIENTE
            bool continuar = true;
            while (continuar)
            {
                string tipoUser = LoginUsuario(listadoAdministradores, listadoGuias);
                if (tipoUser == "admin")
                {
                    int opcion;
                    do
                    {
                        opcion = MenuAdministrador();
                        switch (opcion)
                        {
                            case 1:
                                VerListadoGuias(listadoGuias);
                                break;
                            case 2:
                                VerListadoObrasArte(listadoObraArte);
                                break;
                            case 3:
                                VerListadoExposiciones(listadoExposiciones);
                                break;
                            case 4:
                                VerListadoGalerias(listadoGalerias);
                                break;
                            case 5:
                                Console.WriteLine("------AGREGAR GALERIA ----------");
                                //Solicitar datos
                                Console.WriteLine("Ingrese Id:");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese Nombre:");
                                string nombre = Console.ReadLine();
                                Console.WriteLine("Seleccione Exposicion para Agregar");
                                VerListadoExposiciones(listadoExposiciones);
                                Console.WriteLine("Ingrese Id de Exposicion ");
                                int idExpo = int.Parse(Console.ReadLine());
                                List<Exposicion> listaAgregar = new List<Exposicion>();
                                foreach (Exposicion itemExpo in listadoExposiciones)
                                {
                                    if (itemExpo.Id == idExpo)
                                    {
                                        listaAgregar.Add(itemExpo);
                                    }
                                }
                                Galeria gal = new Galeria(id, nombre, listaAgregar);
                                listadoGalerias.Add(gal);
                                Console.WriteLine("Galeria Agregada Correctamente");
                                break;
                            case 6:
                                Console.WriteLine("----EDITAR GALERIA -----");
                                foreach (var gale in listadoGalerias)
                                {
                                    Console.WriteLine($"ID: {gale.Id} | Nombre: {gale.Nombre}");
                                }
                                Console.WriteLine("Seleccione Galeria");
                                int galeria_seleccionada = int.Parse(Console.ReadLine());
                                foreach (var gale in listadoGalerias)
                                {
                                    if (gale.Id == galeria_seleccionada)
                                    {
                                        Console.WriteLine("EXPOSICIONES ACTUALES EN LA GALERIA");
                                        foreach (var expo in gale.ListadoExposiciones)
                                        {
                                            Console.WriteLine($"Id: {expo.Id} | Nombre: {expo.Nombre}");
                                        }
                                        Console.WriteLine("Motrar todas las exposiciones");
                                        foreach (var expo in listadoExposiciones)
                                        {
                                            Console.WriteLine($"Id: {expo.Id} | Nombre: {expo.Nombre}");
                                        }
                                        Console.WriteLine("Selecciona exposicion a agregar");
                                        int expo_IdSeleccionada = int.Parse(Console.ReadLine());
                                        Exposicion expoBuscada = BuscarExposicion(expo_IdSeleccionada, listadoExposiciones);
                                        if (expoBuscada != null)
                                        {
                                            bool existeExpo = false;
                                            foreach (var expo in gale.ListadoExposiciones)
                                            {
                                                if (expo.Id == expoBuscada.Id)
                                                {
                                                    Console.WriteLine("Ya existe la exposicion");
                                                    existeExpo = true;
                                                    break;
                                                }
                                            }
                                            if (!existeExpo)
                                            {
                                                gale.ListadoExposiciones.Add(expoBuscada);
                                                Console.WriteLine("Exposicion Agregada");
                                            }
                                        }
                                    }
                                }
                                break;
                            case 0:
                                continuar = false;
                                break;
                            default:
                                Console.WriteLine("Opción Inválida");
                                break;
                        }
                    } while (opcion != 0);
                }
                else if (tipoUser == "guia")
                {
                    int opcion;
                    do
                    {
                        opcion = MenuGuia();
                        switch (opcion)
                        {
                            case 1:
                                VerListadoGalerias(listadoGalerias);
                                break;
                            case 0:
                                continuar = false;
                                break;
                            default:
                                Console.WriteLine("Opción Inválida");
                                break;
                        }
                    } while (opcion != 0);
                }
                else
                {
                    Console.WriteLine("No Existe");
                    continuar = false;
                }
            }
            Console.WriteLine("Programa finalizado.");
            Console.ReadLine();
        }
        //int opcionG = MenuGuia();

        //Console.WriteLine(opcion);
        //Console.WriteLine(opcionG);
        //MENU PARA ADMINISTRADOR
        //INICIO DE SESIÓN -> exisitrá un retorno: admin, guia, incorrecto
        static String LoginUsuario(List<Administrador> listaAdmin, List<Guia> listaGuia)
        {
            Console.WriteLine("Ingrese Usuario");
            String User = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña");
            String Pass = Console.ReadLine();
            foreach (Administrador admin in listaAdmin)
            {
                if (admin.Usuario == User && admin.Password == Pass)
                {
                    return "admin";
                }

            }
            foreach (Guia guia in listaGuia)
            {
                if (guia.Usuario == User && guia.Password == Pass)
                {
                    return "guia";
                }

            }
            return "Invalido";
        }
        static int MenuAdministrador()
        {
            Console.WriteLine("-- Menú Administrador --:");
            Console.WriteLine("[1] Ver listado de Guías");
            Console.WriteLine("[2] Ver listado de Obras de arte");
            Console.WriteLine("[3] Ver listado de Exposiciones");
            Console.WriteLine("[4] Ver listado de Galerías");
            Console.WriteLine("[5] Agregar Galerías");
            Console.WriteLine("[6] Editar Galería (Agregar exposición, verificar primero que no existe ya en la galería actual");
            Console.WriteLine("[0] Salir");
            Console.WriteLine("Selecciona una opción: ");
            int opcion = int.Parse(Console.ReadLine()); //Falta validar el int para que no explote. Se ocupa int.Parse para pasar el int base que es string a entero.
            //Console.ReadLine();
            return opcion;
        }
        //MENU PARA GUIA

        static int MenuGuia()
        {
            Console.WriteLine("-- Menú Guía --:");
            Console.WriteLine("[1] Ver listado de Galerías");
            Console.WriteLine("[0] Salir");
            Console.WriteLine("Selecciona una opción: ");
            int opcion = int.Parse(Console.ReadLine()); //Falta validar el int para que no explo
            Console.ReadLine();
            return opcion;

        }

        static void VerListadoGuias(List<Guia> listadoGuias)
        {
            //static sinRetorno NombreFuncion(tipoParametroRecibe nombreParametro)
            //Se debe llamar listadoTGuias el parámetro que se recibe o puede ser otro?
            //no es necesario que sea el único nombre

            foreach (var guia in listadoGuias)
            {
                Console.WriteLine($"Usuario: {guia.Usuario}");
                Console.WriteLine($"Nombre: {guia.Nombre} {guia.Apellido}");
            }
        }
        //Recorrer listado de administradores
        static void VerListadoAdmin(List<Administrador> listadoAdministrador)
        {
            //foreach (tipo objeto in listado)
            foreach (var item in listadoAdministrador)
            //foreach (var item in listadoAdministrador)
            {
                Console.WriteLine($"Usuario: {item.Usuario} ");
                Console.WriteLine($"Nombre: {item.Nombre} {item.Apellido}");


            }
        }

        static void VerListadoObrasArte(List<ObraArte> listadoDeObrasDeArte)
        {
            foreach (var item in listadoDeObrasDeArte)

            {
                Console.WriteLine($"ID: {item.Id} | Nombre: {item.Nombre}");
                Console.WriteLine($"Auto: {item.Autor} | Fecha: {item.Fecha}");
                Console.WriteLine($"Descripción: {item.Descripcion} | Fecha: {item.Fecha}");
            }
        }

        static void VerListadoExposiciones(List<Exposicion> listadoExposiciones)
        {
            foreach (Exposicion expo in listadoExposiciones)
            {
                Console.WriteLine($"---------- EXPOSICION N°{expo.Id} ------------");
                Console.WriteLine($"{expo.Nombre}");
                Console.WriteLine($"Fechas: {expo.FechaInicio} - {expo.FechaTermino}");
                //IMPRIMIR LISTADO DE OBRAS
                VerListadoObrasArte(expo.ListadoObras);
                Console.WriteLine("FIN DE EXPOSICIÓN");
                Console.WriteLine();
            }
        }

        static void VerListadoGalerias(List<Galeria> listadoGalerias)
        {
            foreach (Galeria gal in listadoGalerias)
            {
                Console.WriteLine($"-----------GALERIA N° {gal.Id} --------------------------");
                Console.WriteLine(gal.Nombre);
                VerListadoExposiciones(gal.ListadoExposiciones);
                Console.WriteLine("FIN DE GALERIA");
                Console.WriteLine();
            }
        }
        //Buscar exposición

        static Exposicion BuscarExposicion(int idBuscar, List<Exposicion> listadoExposiciones)
        {
            foreach (var expo in listadoExposiciones)
            {
                if (expo.Id == idBuscar)
                {
                    return expo;
                }
            }
            return null;
        }



    }
}
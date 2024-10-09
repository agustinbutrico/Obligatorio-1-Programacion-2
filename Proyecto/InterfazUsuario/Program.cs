using LogicaNegocio;
using System;

namespace InterfazUsuario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuTipoUsuario();
        }

        // Crear una instancia de la clase Sistema
        private static Sistema miSistema = new Sistema();

        /// <summary>
        /// La estructura modular de los menus permite navegarlos de distinta
        /// forma dependiendo del rol que tengas asignado (el primer menu lo determina).
        /// Cada vez que se selecciona una opción se ejecuta una funcion o se redirige a otro menu.
        /// Cada vez que se ejecuta un menu se borra el contenido en pantalla.
        /// La función MostrarOpcionesMenu(string[] opciones) permite imprimir las opciones de los menus en pantalla.
        /// </summary>
        #region Menu
        #region Utilidades
        static void MostrarOpcionesMenu(string[] opciones)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(opciones[0]);
            Console.WriteLine("0. ...");
            for (int i = 1; i < opciones.Length; i++)
            {
                Console.WriteLine(opciones[i]);
            }
            Console.WriteLine("-------------------------------------");
        }
        static void MostrarOpcionesMenuPorTipoUsuario(string tipoUsuario, string[] opcionesCliente, string[] opcionesAdministrador, string[] opcionesTester)
        {
            switch (tipoUsuario)
            {
                case "CLIENTE":
                    MostrarOpcionesMenu(opcionesCliente);
                    break;
                case "ADMINISTRADOR":
                    MostrarOpcionesMenu(opcionesAdministrador);
                    break;
                case "TESTER":
                    MostrarOpcionesMenu(opcionesTester);
                    break;
            }
        }
        static void VolverAlMenu()
        {
            Console.WriteLine("Precione Intro para volver al menu");
            Console.ReadLine();
        }
        /// <summary>
        /// Implementa el bloque try catch a los menus
        /// idMenu = 0 == MenuArticulo
        /// idMenu = 1 == MenuBuscarArticulo
        /// idMenu = 2 == MenuPublicacion
        /// idMenu = 3 == MenuMostrarPublicacion
        /// idMenu = 4 == MenuBuscarPublicacion
        /// idMenu = 5 == MenuOfetaSubasta
        /// idMenu = 6 == MenuAltaPublicacion
        /// idMenu = 7 == MenuUsuario
        /// idMenu = 8 == MenuMostrarUsuario
        /// idMenu = 9 == MenuBuscarUsuario
        /// idMenu = 10 == MenuAltaUsuario
        /// </summary>
        static void ValidacionMenu(int idMenu, string tipoUsuario)
        {
            try
            {
                switch (idMenu)
                {
                    case 0:
                        MenuArticulo(tipoUsuario);
                        break;
                    case 1:
                        MenuBuscarArticulo(tipoUsuario);
                        break;
                    case 2:
                        MenuPublicacion(tipoUsuario);
                        break;
                    case 3:
                        MenuMostrarPublicacion(tipoUsuario);
                        break;
                    case 4:
                        MenuBuscarPublicacion(tipoUsuario);
                        break;
                    case 5:
                        MenuOfetaSubasta(tipoUsuario);
                        break;
                    case 6:
                        MenuAltaPublicacion(tipoUsuario);
                        break;
                    case 7:
                        MenuUsuario(tipoUsuario);
                        break;
                    case 8:
                        MenuMostrarUsuario(tipoUsuario);
                        break;
                    case 9:
                        MenuBuscarUsuario(tipoUsuario);
                        break;
                    case 10:
                        MenuAltaUsuario(tipoUsuario);
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error de operación: {ex.Message}");
        	    VolverAlMenu();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Falta un argumento obligatorio: {ex.Message}");
        	    VolverAlMenu();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argumento inválido: {ex.Message}");
        	    VolverAlMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
        	    VolverAlMenu();
            }
        }
        #endregion
        #region Principal
        static void MenuTipoUsuario()
        {
            bool valido = false;
            string tipoUsuario;

            while (!valido)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Menu selección tipo de usuario");
                Console.WriteLine("1. Usuario");
                Console.WriteLine("2. Administrador");
                Console.WriteLine("3. Tester");
                Console.WriteLine("-------------------------------------");
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                switch (opcionSeleccionada)
                {
                    case 1:
                        valido = true;
                        tipoUsuario = "CLIENTE";
                        Menu(tipoUsuario);
                        break;
                    case 2:
                        valido = true;
                        tipoUsuario = "ADMINISTRADOR";
                        Menu(tipoUsuario);
                        break;
                    case 3:
                        valido = true;
                        tipoUsuario = "TESTER";
                        Menu(tipoUsuario);
                        break;
                }
            }
        }
        static void Menu(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu", "1. Artículos", "2. Publicaciones", "3. Usuarios" };

            while (!valido)
            {
                if (tipoUsuario == "CLIENTE" || tipoUsuario == "ADMINISTRADOR" || tipoUsuario == "TESTER")
                {
                    Console.Clear();
                    MostrarOpcionesMenu(opciones); // Imprime las opciones del array opciones
                    int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                    switch (opcionSeleccionada)
                    {
                        case 0:
                            MenuTipoUsuario();
                            break;
                        case 1:
                            ValidacionMenu(0, tipoUsuario);
                            break;
                        case 2:
                            ValidacionMenu(2, tipoUsuario);
                            break;
                        case 3:
                            ValidacionMenu(7, tipoUsuario);
                            break;
                    }
                }
            }
        }
        #endregion
        #region Articulo
        static void MenuArticulo(string tipoUsuario)
        {
            bool valido = false;
            string[] opcionesCliente = new string[] { "Menu Articulo", "1. Mostrar catálogo", "2. Buscar" };
            string[] opcionesAdministrador = new string[] { "Menu Articulo", "1. Mostrar catálogo", "2. Buscar", "3. Dar de alta articulo" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenuPorTipoUsuario(tipoUsuario, opcionesCliente, opcionesAdministrador, opcionesAdministrador); // Imprime las opciones del menu por tipo de usuario
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                ProcesamientoOpcionArticulo(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuBuscarArticulo(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu Buscar", "1. Buscar artículo por ID", "2. Buscar artículo por Nombre" };

            while (!valido)
            {
                Console.Clear();                
                MostrarOpcionesMenu(opciones); // Imprime las opciones del menu
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionBuscarArticulo(tipoUsuario, opcionSeleccionada);
            }
        }
        #endregion
        #region Publicacion
        static void MenuPublicacion(string tipoUsuario)
        {
            bool valido = false;
            string[] opcionesCliente = new string[] { "Menu Publicacion", "1. Mostrar", "2. Buscar", "3. Ofertar en una subasta" };
            string[] opcionesAdministrador = new string[] { "Menu Publicacion", "1. Mostrar", "2. Buscar", "3. Ofertar en una subasta", "4. Dar de alta" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenuPorTipoUsuario(tipoUsuario, opcionesCliente, opcionesAdministrador, opcionesAdministrador); // Imprime las opciones del menu por tipo de usuario
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                ProcesamientoOpcionPublicacion(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuMostrarPublicacion(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu Mostrar", "1. Mostrar todas las publicaciones", "2. Mostrar todas las ventas", "3. Mostrar todas las subastas" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenu(opciones); // Imprime las opciones del menu
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionMostrarPublicacion(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuBuscarPublicacion(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu Busqueda", "1. Buscar publicaciones por ID", "2. Buscar publicaciones por Nombre" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenu(opciones); // Imprime las opciones del menu
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionBuscarPublicacion(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuOfetaSubasta(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu Ofertar", "1. Ofertar con tú ID", "2. Ofertar con tú Nombre" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenu(opciones); // Imprime las opciones del menu
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionOfertaSubasta(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuAltaPublicacion(string tipoUsuario)
        {
            bool valido = false;
            string[] opcionesCliente = new string[] { "" };
            string[] opcionesAdministrador = new string[] { "Menu Alta", "1. Dar de alta venta", "2. Dar de alta subasta" };
            string[] opcionesTester = new string[] { "Menu Alta", "1. Dar de alta publicacion", "2. Dar de alta venta", "3. Dar de alta subasta" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenuPorTipoUsuario(tipoUsuario, opcionesCliente, opcionesAdministrador, opcionesTester); // Imprime las opciones del menu por tipo de usuario
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionAltaPublicacion(tipoUsuario, opcionSeleccionada);
            }
        }
        #endregion
        #region Usuario
        static void MenuUsuario(string tipoUsuario)
        {
            bool valido = false;
            string[] opcionesCliente = new string[] { "Menu Usuarios", "1. Mostrar todos los usuarios", "2. Buscar" };
            string[] opcionesAdministrador = new string[] { "Menu Usuarios", "1. Mostrar", "2. Buscar", "3. Dar de alta" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenuPorTipoUsuario(tipoUsuario, opcionesCliente, opcionesAdministrador, opcionesAdministrador); // Imprime las opciones del menu por tipo de usuario
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                ProcesamientoOpcionUsuario(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuMostrarUsuario(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu Mostrar", "1. Mostrar todos los usuarios", "2. Mostrar todos los clientes", "3. Mostrar todos los administradores" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenu(opciones); // Imprime las opciones del menu
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionMostrarUsuario(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuBuscarUsuario(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu Busqueda", "1. Buscar usuario por ID", "2. Buscar usuario por Nombre" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenu(opciones); // Imprime las opciones del menu
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionBuscarUsuario(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuAltaUsuario(string tipoUsuario)
        {
            bool valido = false;
            string[] opcionesCliente = new string[] { "" };
            string[] opcionesAdministrador = new string[] { "Menu Alta", "1. Dar de alta cliente", "2. Dar de alta administrador" };
            string[] opcionesTester = new string[] { "Menu Alta", "1. Dar de alta usuario", "2. Dar de alta cliente", "3. Dar de alta administrador" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenuPorTipoUsuario(tipoUsuario, opcionesCliente, opcionesAdministrador, opcionesTester); // Imprime las opciones del menu por tipo de usuario
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionAltaUsuario(tipoUsuario, opcionSeleccionada);
            }
        }
        #endregion
        #endregion

        /// <summary>
        /// Las opciones del menu trabajan con la variable opcionSeleccionada,
        /// esta variable es modificada si el menu es diferente para algún tipo de usuario
        /// ya que el indice que se muestra para cada opción en el menu cambia.
        /// Por ejemplo, si cliente tiene 2 opciones disponibles en el menu y administrador
        /// tiene 3 opciones disponibles, con una función intermedia se modifica el input del cliente
        /// si este es == 3 y se remplaza con 99.
        /// Esto permite evitar que el usuario acceda a una opción que no tiene disponible.
        /// </summary>
        #region Opciones del menu
        #region Articulo
        static void ProcesamientoOpcionArticulo(string tipoUsuario, int opcionSelecionada)
        {
            if (tipoUsuario == "CLIENTE")
            {
                if (opcionSelecionada > 2)
                {
                    opcionSelecionada = 99;
                }
            }

            OpcionArticulo(tipoUsuario, opcionSelecionada);
        }
        static void OpcionArticulo(string tipoUsuario, int opcionSeleccionada)
        {

            switch (opcionSeleccionada)
            {
                case 0:
                    Menu(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    ImprimirArticulo(miSistema.ObtenerArticulos(), true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(0, tipoUsuario);
                    break;
                case 2:
                    ValidacionMenu(1, tipoUsuario);
                    break;
                case 3:
                    AltaArticulo();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(0, tipoUsuario);
                    break;
            }
        }
        static void OpcionBuscarArticulo(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    ValidacionMenu(0, tipoUsuario);
                    break;
                case 1:
                    ObtenerArticuloPorId();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(1, tipoUsuario);
                    break;
                case 2:
                    ObtenerArticuloPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(1, tipoUsuario);
                    break;
            }
        }
        #endregion
        #region Publicacion
        static void ProcesamientoOpcionPublicacion(string tipoUsuario, int opcionSelecionada)
        {
            if (tipoUsuario == "CLIENTE")
            {
                if (opcionSelecionada > 3)
                {
                    opcionSelecionada = 99;
                }
            }

            OpcionPublicacion(tipoUsuario, opcionSelecionada);
        }
        static void OpcionPublicacion(string tipoUsuario, int opcionSelecionada)
        {
            // Ejecución de las opciones del menu por tipo de usuario
            switch (opcionSelecionada)
            {
                case 0:
                    Menu(tipoUsuario);
                    break;
                case 1:
                    ValidacionMenu(3, tipoUsuario);
                    break;
                case 2:
                    ValidacionMenu(4, tipoUsuario);
                    break;
                case 3:
                    ValidacionMenu(5, tipoUsuario);
                    break;
                case 4:
                    ValidacionMenu(6, tipoUsuario);
                    break;
            }
        }
        static void OpcionMostrarPublicacion(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    ValidacionMenu(2, tipoUsuario);
                    break;
                case 1:
                    Console.WriteLine(new string('\n', 40));
                    Console.Clear();
                    ImprimirPublicacion(miSistema.ObtenerPublicaciones(false, false), true, true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(3, tipoUsuario);
                    break;
                case 2:
                    Console.WriteLine(new string('\n', 40));
                    Console.Clear();
                    ImprimirPublicacion(miSistema.ObtenerPublicaciones(true, false), true, true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(3, tipoUsuario);
                    break;
                case 3:
                    Console.WriteLine(new string('\n', 40));
                    Console.Clear();
                    ImprimirPublicacion(miSistema.ObtenerPublicaciones(false, true), true, true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(3, tipoUsuario);
                    break;
            }
        }
        static void OpcionBuscarPublicacion(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    ValidacionMenu(2, tipoUsuario);
                    break;
                case 1:
                    ObtenerPublicacionPorId();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(4, tipoUsuario);
                    break;
                case 2:
                    ObtenerPublicacionPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(4, tipoUsuario);
                    break;
            }
        }
        static void OpcionOfertaSubasta(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    ValidacionMenu(2, tipoUsuario);
                    break;
                case 1:
                    AltaOfertaPorId();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(5, tipoUsuario);
                    break;
                case 2:
                    AltaOfertaPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(5, tipoUsuario);
                    break;
            }
        }
        static void ProcesamientoOpcionAltaPublicacion(string tipoUsuario, int opcionSelecionada)
        {
            if (tipoUsuario == "ADMINISTRADOR")
            {
                if (opcionSelecionada > 2)
                {
                    opcionSelecionada = 99;
                }
                else if (opcionSelecionada <= 2)
                {
                    opcionSelecionada++;
                }
            }

            OpcionAltaPublicacion(tipoUsuario, opcionSelecionada);
        }
        static void OpcionAltaPublicacion(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    ValidacionMenu(2, tipoUsuario);
                    break;
                case 1:
                    AltaPublicacion();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(6, tipoUsuario);
                    break;
                case 2:
                    AltaVenta();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(6, tipoUsuario);
                    break;
                case 3:
                    AltaSubasta();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(6, tipoUsuario);
                    break;
            }
        }
        #endregion
        #region Usuario
        static void ProcesamientoOpcionUsuario(string tipoUsuario, int opcionSelecionada)
        {
            if (tipoUsuario == "CLIENTE")
            {
                if (opcionSelecionada > 2)
                {
                    opcionSelecionada = 99;
                }
                if (opcionSelecionada == 1)
                {
                    opcionSelecionada = 4;
                }
            }
            else 
            {
                if (opcionSelecionada == 4)
                {
                    opcionSelecionada = 99;
                }
            }

            OpcionUsuario(tipoUsuario, opcionSelecionada);
        }
        static void OpcionUsuario(string tipoUsuario, int opcionSelecionada)
        {
            switch (opcionSelecionada)
            {
                case 0:
                    Menu(tipoUsuario);
                    break;
                case 1:
                    ValidacionMenu(8, tipoUsuario);
                    break;
                case 2:
                    ValidacionMenu(9, tipoUsuario);
                    break;
                case 3:
                    ValidacionMenu(10, tipoUsuario);
                    break;
                case 4:
                    Console.WriteLine(new string('\n', 40));
                    Console.Clear();
                    ImprimirUsuario(miSistema.ObtenerUsuarios(true, false), false);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(7, tipoUsuario);
                    break;
            }
        }
        static void OpcionMostrarUsuario(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    ValidacionMenu(7, tipoUsuario);
                    break;
                case 1:
                    Console.WriteLine(new string('\n', 40));
                    Console.Clear();
                    ImprimirUsuario(miSistema.ObtenerUsuarios(false, false), false);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(8, tipoUsuario);
                    break;
                case 2:
                    Console.WriteLine(new string('\n', 40));
                    Console.Clear();
                    ImprimirUsuario(miSistema.ObtenerUsuarios(true, false), false);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(8, tipoUsuario);
                    break;
                case 3:
                    Console.WriteLine(new string('\n', 40));
                    Console.Clear();
                    ImprimirUsuario(miSistema.ObtenerUsuarios(false, true), false);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(8, tipoUsuario);
                    break;
            }
        }
        static void OpcionBuscarUsuario(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    MenuUsuario(tipoUsuario);
                    break;
                case 1:
                    ObtenerUsuarioPorId();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(9, tipoUsuario);
                    break;
                case 2:
                    ObtenerUsuarioPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(9, tipoUsuario);
                    break;
            }
        }
        static void ProcesamientoOpcionAltaUsuario(string tipoUsuario, int opcionSelecionada)
        {
            if (tipoUsuario == "ADMINISTRADOR")
            {
                if (opcionSelecionada > 2)
                {
                    opcionSelecionada = 99;
                }
                else if (opcionSelecionada <= 2)
                {
                    opcionSelecionada++;
                }
            }

            OpcionAltaUsuario(tipoUsuario, opcionSelecionada);
        }
        static void OpcionAltaUsuario(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    MenuUsuario(tipoUsuario);
                    break;
                case 1:
                    AltaUsuario();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(10, tipoUsuario);
                    break;
                case 2:
                    AltaCliente();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(10, tipoUsuario);
                    break;
                case 3:
                    AltaAdministrador();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    ValidacionMenu(10, tipoUsuario);
                    break;
            }
        }
        #endregion
        #endregion

        /// <summary>
        /// Las funciones de impresión son las menores posibles para evitar diferencias en la impresion.
        /// Estas imprimen los datos basandose en listas de datos.
        /// Tambien tienen booleanos como margenesGrandes o vistaResumida que sirven para facilitar
        /// la lectura de los datos por parte del usuario al utilizar el programa
        /// </summary>
        #region Impresion de listas
        #region Articulo
        static void ImprimirArticulo(List<Articulo> articulos, bool margenesGrandes)
        {
            int margenes = 20;

            if (margenesGrandes)
            {
                margenes = 40;
            }
            
            for (int i = 0; i < articulos.Count; i++)
            {
                Console.WriteLine(new string('-', margenes));
                // Mostramos los detalles del Artículo
                Console.WriteLine($"ID: {articulos[i].Id}");
                Console.WriteLine($"Nombre: {articulos[i].Nombre}");
                Console.WriteLine($"Precio: {articulos[i].Precio}");
            }
            Console.WriteLine(new string('-', margenes));
        }
        #endregion
        #region Publicacion
        static void ImprimirPublicacion(List<Publicacion> publicaciones, bool margenesGrandes, bool vistaResumida)
        {
            int margenes = 20;

            if (margenesGrandes)
            {
                margenes = 40;
            }

            for (int i = 0; i < publicaciones.Count; i++)
            {
                Console.WriteLine(new string('-', margenes));
                // Mostramos los detalles de las publicaciones
                Console.WriteLine($"ID: {publicaciones[i].Id}");
                Console.WriteLine($"Nombre: {publicaciones[i].Nombre}");
                Console.WriteLine($"Estado: {publicaciones[i].Estado}");
                Console.WriteLine($"Fecha: {publicaciones[i].Fecha}");
                Console.WriteLine($"Articulos: {publicaciones[i].Articulos.Count}");
                if (publicaciones[i].Articulos.Count > 0) // Si hay articulos imprimimos sus ids
                {
                    Console.WriteLine($"Id de los articulos asociados: {miSistema.ParseoArticulo(publicaciones[i].Articulos)}");
                    if (!vistaResumida) // Si no es vista resumida mostramos los datos de los articulos
                    {
                        ImprimirArticulo(publicaciones[i].Articulos, false); // Imprime los datos de los articulos asociados
                    }
                }
                if (publicaciones[i] is Venta venta)
                {
                    if (venta.OfertaRelampago)
                    {
                        Console.WriteLine($"Oferta relampago: Si");
                    }
                    else
                    {
                        Console.WriteLine($"Oferta relampago: No");
                    }
                    Console.WriteLine($"Precio venta {miSistema.ConsultarPrecioVenta(publicaciones[i], publicaciones[i].Articulos)}");

                }
                if (publicaciones[i] is Subasta subasta)
                {
                    Console.WriteLine($"Ofertas: {subasta.Ofertas.Count}");
                    if (subasta.Ofertas.Count > 0) // Si hay ofertas imprimimos sus ids
                    {
                        Console.WriteLine($"Id de las ofertas asociadas: {miSistema.ParseoOferta(subasta.Ofertas)}");
                        if (!vistaResumida) // Si no es vista resumida mostramos los datos de las ofertas
                        {
                            ImprimirOferta(subasta.Ofertas, false); // Imprime los datos de las ofertas asociadas
                        }
                    }
                }
                if (publicaciones[i].FechaFin != DateTime.MinValue)
                {
                    Console.WriteLine($"Cliente: {publicaciones[i].Cliente}");
                    Console.WriteLine($"Administrador: {publicaciones[i].Administrador}");
                    Console.WriteLine($"Fecha Fin: {publicaciones[i].FechaFin}");
                }
            }
            Console.WriteLine(new string('-', margenes));
        }
        #endregion
        #region Usuario
        static void ImprimirUsuario(List<Usuario> usuarios, bool margenesGrandes)
        {
            int margenes = 20;

            if (margenesGrandes)
            {
                margenes = 40;
            }

            for (int i = 0; i < usuarios.Count; i++)
            {
                if (margenesGrandes)
                Console.WriteLine(new string('-', margenes));
                // Mostramos los detalles del Usuario
                Console.WriteLine($"ID: {usuarios[i].Id}");
                Console.WriteLine($"Nombre: {usuarios[i].Nombre}");
                Console.WriteLine($"Apellido: {usuarios[i].Apellido}");
                Console.WriteLine($"Email: {usuarios[i].Email}");
                if (usuarios[i] is Cliente cliente)
                {
                    Console.WriteLine($"Saldo: {cliente.Saldo}");
                }
            }
            Console.WriteLine(new string('-', margenes));
        }
        #endregion
        #region Oferta
        static void ImprimirOferta(List<Oferta> ofertas, bool margenesGrandes)
        {
            int margenes = 20;

            if (margenesGrandes)
            {
                margenes = 40;
            }

            for (int i = 0; i < ofertas.Count; i++)
            {
                Console.WriteLine(new string('-', margenes));
                // Mostramos los detalles de las ofertas
                Console.WriteLine($"ID: {ofertas[i].Id}");
                Console.WriteLine($"Usuario: {ofertas[i].Usuario}");
                Console.WriteLine($"Monto: {ofertas[i].Monto}");
                Console.WriteLine($"Fecha: {ofertas[i].Fecha}");
            }
            Console.WriteLine(new string('-', margenes));
        }
        #endregion
        #endregion

        /// <summary>
        /// En las funciones de busqueda se solicitan datos simples como id o nombre
        /// pero tambien se habilita la posibilidad de buscar varios ids o nombres al mismo tiempo.
        /// Luego se imprimen en pantalla las busquedas realizadas utilizando estos datos con las 
        /// funciones de Obtener que se encuentran en Sistema
        /// </summary>
        #region Busqueda
        #region Articulo
        static void ObtenerArticuloPorId()
        {
            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(ids_crudos))
            {
                Console.WriteLine("El id no puede ser vacío");
                return;
            }
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            if (ids == null || ids.Count == 0)
            {
                Console.WriteLine("No se encontraron ids correspondientes a los ids proporcionados");
                return;
            }
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids);
            if (articulos == null || articulos.Count == 0)
            {
                Console.WriteLine("No se encontraron usuarios correspondientes a los ids proporcionados");
                return;
            }

            Console.WriteLine(new string('\n', 40));
            Console.Clear();
            ImprimirArticulo(articulos, true);
        }
        static void ObtenerArticuloPorNombre()
        {
            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Nombre de los articulos separados por ,:");
            string nombres_crudos = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombres_crudos))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            List<string> nombres = miSistema.ParseoNombre(nombres_crudos); // Convierte el input del usuario en una lista de nombres
            if (nombres == null || nombres.Count == 0)
            {
                Console.WriteLine("No se encontraron nombres correspondientes a los nombres proporcionados");
                return;
            }
            List<Articulo> articulos = miSistema.ObtenerArticuloPorNombre(nombres);
            if (articulos == null || articulos.Count == 0)
            {
                Console.WriteLine("No se encontraron publicaciones correspondientes a los nombres proporcionados");
                return;
            }

            Console.WriteLine(new string('\n', 40));
            Console.Clear();
            ImprimirArticulo(articulos, true);
        }
        #endregion
        #region Publicacion
        static void ObtenerPublicacionPorId()
        {
            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Id de las publicaciones separadas por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(ids_crudos))
            {
                Console.WriteLine("El id no puede ser vacío");
                return;
            }
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            if (ids == null || ids.Count == 0)
            {
                Console.WriteLine("No se encontraron ids correspondientes a los ids proporcionados");
                return;
            }
            List<Publicacion> publicaciones = miSistema.ObtenerPublicacionPorId(ids, false, false);
            if (publicaciones == null || publicaciones.Count == 0)
            {
                Console.WriteLine("No se encontraron usuarios correspondientes a los ids proporcionados");
                return;
            }

            Console.WriteLine(new string('\n', 40));
            Console.Clear();
            ImprimirPublicacion(publicaciones, true, false);
        }
        static void ObtenerPublicacionPorNombre()
        {
            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Nombre de las publicaciones separadas por ,:");
            string nombres_crudos = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombres_crudos))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            List<string> nombres = miSistema.ParseoNombre(nombres_crudos); // Convierte el input del usuario en una lista de nombres
            if (nombres == null || nombres.Count == 0)
            {
                Console.WriteLine("No se encontraron nombres correspondientes a los nombres proporcionados");
                return;
            }
            List<Publicacion> publicaciones = miSistema.ObtenerPublicacionPorNombre(nombres, false, false);
            if (publicaciones == null || publicaciones.Count == 0)
            {
                Console.WriteLine("No se encontraron publicaciones correspondientes a los nombres proporcionados");
                return;
            }

            Console.WriteLine(new string('\n', 40));
            Console.Clear();
            ImprimirPublicacion(publicaciones, true, false);
        }
        #endregion
        #region Usuario
        static void ObtenerUsuarioPorId()
        {
            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Id de los usuarios separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(ids_crudos))
            {
                Console.WriteLine("El id no puede ser vacío");
                return;
            }
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            if (ids == null || ids.Count == 0)
            {
                Console.WriteLine("No se encontraron ids correspondientes a los ids proporcionados");
                return;
            }
            List<Usuario> usuarios = miSistema.ObtenerUsuarioPorId(ids, false, false);
            if (usuarios == null || usuarios.Count == 0)
            {
                Console.WriteLine("No se encontraron usuarios correspondientes a los ids proporcionados");
                return;
            }

            Console.WriteLine(new string('\n', 40));
            Console.Clear();
            ImprimirUsuario(usuarios, true);
        }
        static void ObtenerUsuarioPorNombre()
        {
            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Nombre de los usuarios separados por ,:");
            string nombres_crudos = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombres_crudos))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            List<string> nombres = miSistema.ParseoNombre(nombres_crudos); // Convierte el input del usuario en una lista de nombres
            if (nombres == null || nombres.Count == 0)
            {
                Console.WriteLine("No se encontraron nombres correspondientes a los nombres proporcionados");
                return;
            }
            List<Usuario> usuarios = miSistema.ObtenerUsuarioPorNombre(nombres, false, false);
            if (usuarios == null || usuarios.Count == 0)
            {
                Console.WriteLine("No se encontraron usuarios correspondientes a los nombres proporcionados");
                return;
            }

            Console.WriteLine(new string('\n', 40));
            Console.Clear();
            ImprimirUsuario(usuarios, true);
        }
        #endregion
        #endregion

        /// <summary>
        /// En las funciones de alta se solicitan datos minimos para poder dar de alta lo solicitado.
        /// Algunos de los datos como la fecha de creación se asignan automaticamente (fecha.Now)
        /// </summary>
        #region Altas
        #region Articulo
        static void AltaArticulo()
        {
            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Ingrese los datos del artículo");
            Console.WriteLine("Nombre:");
            // ?? operador de coalescencia nula
            // Si es null devuelve el valor de la derecha
            // Si no es null devuelve el valor de la izquierda
            string nombre = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            Console.WriteLine("Precio:");
            decimal precio;
            if (!decimal.TryParse(Console.ReadLine(), out precio) || precio < 0)
            {
                Console.WriteLine("El peecio debe ser un número entero positivo");
                return;
            }

            miSistema.AltaArticulo(nombre, precio);
        }
        #endregion
        #region Publicacion
        static void AltaPublicacion()
        {
            // Valores por defecto
            string estado = "ABIERTA";
            DateTime fecha = DateTime.Now;
            Cliente? cliente = null;
            Administrador? administrador = null;
            DateTime fechaFin = DateTime.MinValue;

            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar a la publicacion");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(ids_crudos))
            {
                Console.WriteLine("El id no puede ser vacío");
                return;
            }
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            if (ids == null || ids.Count == 0)
            {
                Console.WriteLine("No se proporcionaron IDs válidos");
                return;
            }
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de publicaciones con los ids
            if (articulos == null || articulos.Count == 0)
            {
                Console.WriteLine("No se encontraron artículos correspondientes a los IDs proporcionados");
                return;
            }

            miSistema.AltaPublicacion(nombre, estado, fecha, articulos, cliente, administrador, fechaFin);
            Console.WriteLine("La publicación se ha creado exitosamente");
        }
        static void AltaVenta()
        {
            // Valores por defecto
            string estado = "ABIERTA";
            DateTime fecha = DateTime.Now;
            Cliente? cliente = null;
            Administrador? administrador = null;
            DateTime fechaFin = DateTime.MinValue;

            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar a la venta");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(ids_crudos))
            {
                Console.WriteLine("El id no puede ser vacío");
                return;
            }
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            if (ids == null || ids.Count == 0)
            {
                Console.WriteLine("No se proporcionaron IDs válidos");
                return;
            }
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de publicaciones con los ids
            if (articulos == null || articulos.Count == 0)
            {
                Console.WriteLine("No se encontraron artículos correspondientes a los IDs proporcionados");
                return;
            }
            Console.WriteLine("Es oferta relampago?\n1. Si\n2. No");
            int esOferta;
            if (!int.TryParse(Console.ReadLine(), out esOferta) || esOferta != 1 || esOferta != 2)
            {
                Console.WriteLine("Su respuesta debe ser 1 o 2");
                return;
            }
            bool ofertaRelampago = false;

            if ( esOferta == 1 )
            {
                ofertaRelampago = true;
            }

            miSistema.AltaVenta(nombre, estado, fecha, articulos, cliente, administrador, fechaFin, ofertaRelampago);
            Console.WriteLine("La venta se ha creado exitosamente");
        }
        static void AltaSubasta()
        {
            // Valores por defecto
            string estado = "ABIERTA";
            DateTime fecha = DateTime.Now;
            Cliente? cliente = null;
            Administrador? administrador = null;
            DateTime fechaFin = DateTime.MinValue;
            List<Oferta> ofertas = new List<Oferta>();

            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar a la subasta");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(ids_crudos))
            {
                Console.WriteLine("El id no puede ser vacío");
                return;
            }
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            if (ids == null || ids.Count == 0)
            {
                Console.WriteLine("No se proporcionaron IDs válidos");
                return;
            }
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de publicaciones con los ids
            if (articulos == null || articulos.Count == 0)
            {
                Console.WriteLine("No se encontraron artículos correspondientes a los IDs proporcionados");
                return;
            }

            miSistema.AltaSubasta(nombre, estado, fecha, articulos, cliente, administrador, fechaFin, ofertas);
            Console.WriteLine("La subasta se ha creado exitosamente");
        }
        #endregion
        #region Usuario
        static void AltaUsuario()
        {
            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar al usuario");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(apellido))
            {
                Console.WriteLine("El apellido no puede ser vacío");
                return;
            }
            Console.WriteLine("Email:");
            string email = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("El email no puede ser vacío");
                return;
            }
            Console.WriteLine("Contraseña:");
            string contrasenia = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(contrasenia))
            {
                Console.WriteLine("La contraseña no puede ser vacía");
                return;
            }

            miSistema.AltaUsuario(nombre, apellido, email, contrasenia);
        }
        static void AltaCliente()
        {
            // Valores por defecto
            int saldo = 0;

            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar al cliente");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(apellido))
            {
                Console.WriteLine("El apellido no puede ser vacío");
                return;
            }
            Console.WriteLine("Email:");
            string email = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("El email no puede ser vacío");
                return;
            }
            Console.WriteLine("Contraseña:");
            string contrasenia = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(contrasenia))
            {
                Console.WriteLine("La contraseña no puede ser vacía");
                return;
            }

            miSistema.AltaCliente(nombre, apellido, email, contrasenia, saldo);
        }
        static void AltaAdministrador()
        {
            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar al administrador");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(apellido))
            {
                Console.WriteLine("El apellido no puede ser vacío");
                return;
            }
            Console.WriteLine("Email:");
            string email = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("El email no puede ser vacío");
                return;
            }
            Console.WriteLine("Contraseña:");
            string contrasenia = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(contrasenia))
            {
                Console.WriteLine("La contraseña no puede ser vacía");
                return;
            }

            miSistema.AltaAdministrador(nombre, apellido, email, contrasenia);
        }
        #endregion
        #region Oferta
        static void AltaOfertaPorId()
        {
            // Valores por defecto
            DateTime fecha = DateTime.Now;

            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar a la oferta");
            Console.WriteLine("Id del comprador:");
            int idUsuario;
            if (!int.TryParse(Console.ReadLine(), out idUsuario) || idUsuario < 0)
            {
                Console.WriteLine("El ID del usuario debe ser un número entero positivo");
                return;
            }
            Usuario? usuario = miSistema.ObtenerUsuarioPorId(idUsuario, true, false);
            if (usuario == null)
            {
                Console.WriteLine("No se encontró un usuario con ese nombre");
                return;
            }
            Console.WriteLine("Id de la subasta:");
            int idPublicacion;
            if (!int.TryParse(Console.ReadLine(), out idPublicacion) || idPublicacion < 0)
            {
                Console.WriteLine("El ID de la subasta debe ser un número entero positivo");
                return;
            }
            Publicacion? publicacion = miSistema.ObtenerPublicacionPorId(idPublicacion, false, true);
            if (publicacion == null)
            {
                Console.WriteLine("No se encontró una subasta con ese ID");
                return;
            }
            Console.WriteLine("Monto a ofertar:");
            decimal monto;
            if (!decimal.TryParse(Console.ReadLine(), out monto) || monto <= 0)
            {
                Console.WriteLine("El monto debe ser un número decimal positivo");
                return;
            }

            miSistema.AltaOferta(usuario, publicacion, monto, fecha);
            Console.WriteLine("La oferta se ha realizado con éxito");
        }
        static void AltaOfertaPorNombre()
        {
            // Valores por defecto
            DateTime fecha = DateTime.Now;

            Console.Clear();
            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar a la oferta");
            Console.WriteLine("Nombre del comprador:");
            string nombre = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombre)) 
            {
                Console.WriteLine("El nombre no puede ser vacío");
                return;
            }
            Usuario? usuario = miSistema.ObtenerUsuarioPorNombre(nombre, true, false);
            if (usuario == null)
            {
                Console.WriteLine("No se encontró un usuario con ese nombre");
                return;
            }
            Console.WriteLine("Id de la subasta:");
            int idPublicacion;
            if (!int.TryParse(Console.ReadLine(), out idPublicacion) || idPublicacion < 0) 
            {
                Console.WriteLine("El ID de la subasta debe ser un número entero positivo");
                return;
            }
            Publicacion? publicacion = miSistema.ObtenerPublicacionPorId(idPublicacion, false, true);
            if (publicacion == null)
            {
                Console.WriteLine("No se encontró una subasta con ese ID");
                return;
            }
            Console.WriteLine("Monto a ofertar:");
            decimal monto;
            if (!decimal.TryParse(Console.ReadLine(), out monto) || monto <= 0)
            {
                Console.WriteLine("El monto debe ser un número decimal positivo");
                return;
            }

            miSistema.AltaOferta(usuario, publicacion, monto, fecha);
            Console.WriteLine("La oferta se ha realizado con éxito");
        }
        #endregion
        #endregion
    }
}

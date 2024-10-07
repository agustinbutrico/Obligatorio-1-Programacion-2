using LogicaNegocio;

namespace InterfazUsuario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            miSistema.PrecargaArticulo();
            miSistema.PrecargarPublicacion();
            miSistema.PrecargaUsuario();
            MenuTipoUsuario();
        }

        // Crear una instancia de la clase Sistema
        private static Sistema miSistema = new Sistema();

        #region Menu
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
        static void VolverAlMenu()
        {
            Console.WriteLine("Precione Intro para volver al menu");
            Console.ReadLine();
            Console.Clear();
        }
        #region Principal
        static void MenuTipoUsuario()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Menu selección tipo de usuario");
            Console.WriteLine("1. Usuario");
            Console.WriteLine("2. Administrador");
            Console.WriteLine("3. Testeo");
            Console.WriteLine("-------------------------------------");
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);
            string tipoUsuario;

            switch (opcionSeleccionada)
            {
                case 1:
                    Console.Clear();
                    tipoUsuario = "CLIENTE";
                    Menu(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    tipoUsuario = "ADMINISTRADOR";
                    Menu(tipoUsuario);
                    break;
                case 3:
                    Console.Clear();
                    tipoUsuario = "TESTEO";
                    Menu(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuTipoUsuario();
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void Menu(string tipoUsuario)
        {
            string[] opciones = new string[] { "Menu", "1. Artículos", "2. Publicaciones", "3. Usuarios" };
            if (tipoUsuario == "CLIENTE" || tipoUsuario == "ADMINISTRADOR" || tipoUsuario == "TESTEO")
            {
                MostrarOpcionesMenu(opciones); // Imprime las opciones del array opciones
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                switch (opcionSeleccionada)
                {
                    case 0:
                        Console.Clear();
                        MenuTipoUsuario();
                        break;
                    case 1:
                        Console.Clear();
                        MenuArticulo(tipoUsuario);
                        break;
                    case 2:
                        Console.Clear();
                        MenuPublicacion(tipoUsuario);
                        break;
                    case 3:
                        Console.Clear();
                        MenuUsuario(tipoUsuario);
                        break;
                    default:
                        Console.Clear();
                        Menu(tipoUsuario);
                        Console.WriteLine("Seleccione una opcion valida");
                        break;
                }
            }
        }
        #endregion
        #region Articulo
        static void MenuArticulo(string tipoUsuario)
        {
            string[] opcionesCliente = new string[] { "Menu Articulo", "1. Mostrar catálogo", "2. Buscar" };
            string[] opcionesAdministrador = new string[] { "Menu Articulo", "1. Mostrar catálogo", "2. Buscar", "3. Dar de alta articulo" };
            // Menu
            if (tipoUsuario == "CLIENTE")
            {
                MostrarOpcionesMenu(opcionesCliente);
            }
            if (tipoUsuario == "ADMINISTRADOR" || tipoUsuario == "TESTEO")
            {
                MostrarOpcionesMenu(opcionesAdministrador);
            }
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

            ProcesamientoOpcionArticulo(tipoUsuario, opcionSeleccionada);
        }
        static void MenuBuscarArticulo(string tipoUsuario)
        {
            string[] opciones = new string[] { "Menu Buscar", "1. Buscar artículo por ID", "2. Buscar artículo por Nombre" };
            MostrarOpcionesMenu(opciones);
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

            OpcionBuscarArticulo(tipoUsuario, opcionSeleccionada);
        }
        #endregion
        #region Publicacion
        static void MenuPublicacion(string tipoUsuario)
        {
            string[] opcionesCliente = new string[] { "Menu Publicacion", "1. Mostrar", "2. Buscar" };
            string[] opcionesAdministrador = new string[] { "Menu Publicacion", "1. Mostrar", "2. Buscar", "3. Dar de alta" };
            if (tipoUsuario == "CLIENTE")
            {
                MostrarOpcionesMenu(opcionesCliente);
            }
            if (tipoUsuario == "ADMINISTRADOR" || tipoUsuario == "TESTEO")
            {
                MostrarOpcionesMenu(opcionesAdministrador);
            }
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

            ProcesamientoOpcionPublicacion(tipoUsuario, opcionSeleccionada);
        }
        static void MenuMostrarPublicacion(string tipoUsuario)
        {
            string[] opciones = new string[] { "Menu Mostrar", "1. Mostrar todas las publicaciones", "2. Mostrar todas las ventas", "3. Mostrar todas las subastas" };
            MostrarOpcionesMenu(opciones);
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

            OpcionMostrarPublicacion(tipoUsuario, opcionSeleccionada);
        }
        static void MenuBuscarPublicacion(string tipoUsuario)
        {
            string[] opciones = new string[] { "Menu Busqueda", "1. Buscar publicaciones por ID", "2. Buscar publicaciones por Nombre" };
            MostrarOpcionesMenu(opciones);
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

            OpcionBuscarPublicacion(tipoUsuario, opcionSeleccionada);
        }
        static void MenuAltaPublicacion(string tipoUsuario)
        {
            string[] opcionesAdministrador  = new string[] { "Menu Alta", "1. Dar de alta venta", "2. Dar de alta subasta" };
            string[] opcionesTesteo = new string[] { "Menu Alta", "1. Dar de alta publicacion", "2. Dar de alta venta", "3. Dar de alta subasta" };
            if (tipoUsuario == "ADMINISTRADOR")
            {
                MostrarOpcionesMenu(opcionesAdministrador);
            }
            if (tipoUsuario == "TESTEO")
            {
                MostrarOpcionesMenu(opcionesTesteo);
            }
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

            OpcionAltaPublicacion(tipoUsuario, opcionSeleccionada);
        }
        #endregion
        #region Usuario
        static void MenuUsuario(string tipoUsuario)
        {
            string[] opcionesCliente = new string[] { "Menu Usuarios", "1. Mostrar todos los usuarios", "2. Buscar" };
            string[] opcionesAdministrador = new string[] { "Menu Usuarios", "1. Mostrar", "2. Buscar", "3. Dar de alta" };
            if (tipoUsuario == "CLIENTE")
            {
                MostrarOpcionesMenu(opcionesCliente);
            }
            if (tipoUsuario == "ADMINISTRADOR" || tipoUsuario == "TESTEO")
            {
                MostrarOpcionesMenu(opcionesAdministrador);
            }
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);
            
            ProcesamientoOpcionUsuario(tipoUsuario, opcionSeleccionada);
        }
        static void MenuMostrarUsuario(string tipoUsuario)
        {
            string[] opciones = new string[] { "Menu Mostrar", "1. Mostrar todos los usuarios", "2. Mostrar todos los clientes", "3. Mostrar todos los administradores" };
            MostrarOpcionesMenu(opciones);
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

            OpcionMostrarUsuario(tipoUsuario, opcionSeleccionada);
        }
        static void MenuBuscarUsuario(string tipoUsuario)
        {
            string[] opciones = new string[] { "Menu Busqueda", "1. Buscar usuario por ID", "2. Buscar usuario por Nombre" };
            MostrarOpcionesMenu(opciones);
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

            OpcionBuscarUsuario(tipoUsuario, opcionSeleccionada);
        }
        static void MenuAltaUsuario(string tipoUsuario)
        {
            string[] opcionesAdministrador = new string[] { "Menu Alta", "1. Dar de alta cliente", "2. Dar de alta administrador" };
            string[] opcionesTesteo = new string[] { "Menu Alta", "1. Dar de alta usuario", "2. Dar de alta cliente", "3. Dar de alta administrador" };
            if (tipoUsuario == "ADMINISTRADOR")
            {
                MostrarOpcionesMenu(opcionesAdministrador);
            }
            if (tipoUsuario == "TESTEO")
            {
                MostrarOpcionesMenu(opcionesTesteo);
            }
            int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

            OpcionAltaUsuario(tipoUsuario, opcionSeleccionada);
        }
        #endregion
        #endregion

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
                    Console.Clear();
                    Menu(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    miSistema.ImprimirArticulo();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuArticulo(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    MenuBuscarArticulo(tipoUsuario);
                    break;
                case 3:
                    Console.Clear();
                    AltaArticulo();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuArticulo(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuArticulo(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void OpcionBuscarArticulo(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    Console.Clear();
                    MenuArticulo(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    ObtenerArticuloPorId();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarArticulo(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    ObtenerArticuloPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarArticulo(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuArticulo(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        #endregion
        #region Publicacion
        static void ProcesamientoOpcionPublicacion(string tipoUsuario, int opcionSelecionada)
        {
            if (tipoUsuario == "CLIENTE")
            {
                if (opcionSelecionada > 2)
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
                    Console.Clear();
                    Menu(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    MenuMostrarPublicacion(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    MenuBuscarPublicacion(tipoUsuario);
                    break;
                case 3:
                    Console.Clear();
                    MenuAltaPublicacion(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuPublicacion(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void OpcionMostrarPublicacion(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    Console.Clear();
                    MenuPublicacion(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    miSistema.ImprimirPublicacion();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarPublicacion(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    miSistema.ImprimirVenta();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarPublicacion(tipoUsuario);
                    break;
                case 3:
                    Console.Clear();
                    miSistema.ImprimirSubasta();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarPublicacion(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuPublicacion(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void OpcionBuscarPublicacion(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    Console.Clear();
                    MenuPublicacion(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    ObtenerPublicacionPorId();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarPublicacion(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    ObtenerPublicacionPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarPublicacion(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuPublicacion(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
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
                    Console.Clear();
                    MenuPublicacion(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    AltaPublicacion();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaPublicacion(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    AltaVenta();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaPublicacion(tipoUsuario);
                    break;
                case 3:
                    Console.Clear();
                    AltaSubasta();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaPublicacion(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuAltaPublicacion(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
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
            // Ejecución de las opciones del menu por tipo de usuario
            switch (opcionSelecionada)
            {
                case 0:
                    Console.Clear();
                    Menu(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    MenuMostrarUsuario(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    MenuBuscarUsuario(tipoUsuario);
                    break;
                case 3:
                    Console.Clear();
                    MenuAltaUsuario(tipoUsuario);
                    break;
                case 4:
                    Console.Clear();
                    miSistema.ImprimirCliente();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuUsuario(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuUsuario(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void OpcionMostrarUsuario(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    Console.Clear();
                    MenuUsuario(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    miSistema.ImprimirUsuario();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarUsuario(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    miSistema.ImprimirCliente();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarUsuario(tipoUsuario);
                    break;
                case 3:
                    Console.Clear();
                    miSistema.ImprimirAdministrador();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarUsuario(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuUsuario(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void OpcionBuscarUsuario(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    Console.Clear();
                    MenuUsuario(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    ObtenerUsuarioPorId();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarUsuario(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    ObtenerUsuarioPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarUsuario(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuUsuario(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
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
                    Console.Clear();
                    MenuUsuario(tipoUsuario);
                    break;
                case 1:
                    Console.Clear();
                    AltaUsuario();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaUsuario(tipoUsuario);
                    break;
                case 2:
                    Console.Clear();
                    AltaCliente();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaUsuario(tipoUsuario);
                    break;
                case 3:
                    Console.Clear();
                    AltaAdministrador();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaUsuario(tipoUsuario);
                    break;
                default:
                    Console.Clear();
                    MenuAltaUsuario(tipoUsuario);
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        #endregion
        #endregion

        #region Solicitud datos
        #region Articulo
        static void ObtenerArticuloPorId()
        {
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de articulos con los ids

            miSistema.ImprimirArticulo(articulos, true);
        }
        static void ObtenerArticuloPorNombre()
        {
            Console.WriteLine("Nombre de los articulos separados por ,:");
            string nombres_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<string> nombres = miSistema.ParseoNombre(nombres_crudos); // Convierte el input del usuario en una lista de nombres
            List<Articulo> articulos = miSistema.ObtenerArticuloPorNombre(nombres); // Obtiene la lista de articulos con los nombres

            miSistema.ImprimirArticulo(articulos, true);
        }
        #endregion
        #region Publicacion
        static void ObtenerPublicacionPorId()
        {
            Console.WriteLine("Id de las publicaciones separadas por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Publicacion> publicacion = miSistema.ObtenerPublicacionPorId(ids); // Obtiene la lista de publicaciones con los ids

            miSistema.ImprimirPublicacion(publicacion, true);
        }
        static void ObtenerPublicacionPorNombre()
        {
            Console.WriteLine("Nombre de las publicaciones separadas por ,:");
            string nombres_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<string> nombres = miSistema.ParseoNombre(nombres_crudos); // Convierte el input del usuario en una lista de nombres
            List<Publicacion> publicaciones = miSistema.ObtenerPublicacionPorNombre(nombres); // Obtiene la lista de publicaciones con los nombres

            miSistema.ImprimirPublicacion(publicaciones, true);
        }
        #endregion
        #region Usuario
        static void ObtenerUsuarioPorId()
        {
            Console.WriteLine("Id de los usuarios separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Usuario> usuario = miSistema.ObtenerUsuarioPorId(ids); // Obtiene la lista de usuarios con los ids

            miSistema.ImprimirUsuario(usuario, true);
        }
        static void ObtenerUsuarioPorNombre()
        {
            Console.WriteLine("Nombre de los usuarios separados por ,:");
            string nombres_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<string> nombres = miSistema.ParseoNombre(nombres_crudos); // Convierte el input del usuario en una lista de nombres
            List<Usuario> usuarios = miSistema.ObtenerUsuarioPorNombre(nombres); // Obtiene la lista de usuarios con los nombres

            miSistema.ImprimirUsuario(usuarios, true);
        }
        #endregion
        #endregion

        #region Altas
        #region Articulo
        static void AltaArticulo()
        {
            Console.WriteLine("Ingrese los datos del artículo");
            Console.WriteLine("Nombre:");
            // ?? operador de coalescencia nula
            // Si es null devuelve el valor de la derecha
            // Si no es null devuelve el valor de la izquierda
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Precio:");
            decimal.TryParse(Console.ReadLine(), out decimal precio);

            miSistema.AltaArticulo(nombre, precio, true);
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

            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar a la publicacion");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de publicaciones con los ids
            
            miSistema.AltaPublicacion(nombre, estado, fecha, articulos, cliente, administrador, fechaFin, true);
        }
        static void AltaVenta()
        {
            // Valores por defecto
            string estado = "ABIERTA";
            DateTime fecha = DateTime.Now;
            Cliente? cliente = null;
            Administrador? administrador = null;
            DateTime fechaFin = DateTime.MinValue;

            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar a la venta");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de publicaciones con los ids
            Console.WriteLine("Es oferta relampago?\n1. Si\n2. No");
            int.TryParse(Console.ReadLine(), out int esOferta);
            bool ofertaRelampago = false;

            if ( esOferta == 1 )
            {
                ofertaRelampago = true;
            }

            miSistema.AltaVenta(nombre, estado, fecha, articulos, cliente, administrador, fechaFin, ofertaRelampago, true);
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

            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar a la subasta");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de publicaciones con los ids

            miSistema.AltaSubasta(nombre, estado, fecha, articulos, cliente, administrador, fechaFin, ofertas, true);
        }
        #endregion
        #region Usuario
        static void AltaUsuario()
        {
            Console.WriteLine("Ingrese los datos que desea asociar al usuario");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Email:");
            string email = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Contraseña:");
            string contrasenia = Console.ReadLine() ?? string.Empty;

            miSistema.AltaUsuario(nombre, apellido, email, contrasenia, true);
        }
        static void AltaCliente()
        {
            // Valores por defecto
            int saldo = 0;

            // Solicitud datos
            Console.WriteLine("Ingrese los datos que desea asociar al cliente");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Email:");
            string email = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Contraseña:");
            string contrasenia = Console.ReadLine() ?? string.Empty;

            miSistema.AltaCliente(nombre, apellido, email, contrasenia, saldo, true);
        }
        static void AltaAdministrador()
        {
            Console.WriteLine("Ingrese los datos que desea asociar al administrador");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Apellido:");
            string apellido = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Email:");
            string email = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Contraseña:");
            string contrasenia = Console.ReadLine() ?? string.Empty;

            miSistema.AltaAdministrador(nombre, apellido, email, contrasenia, true);
        }
        #endregion
        #endregion
    }
}

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
        static void VolverAlMenu()
        {
            Console.WriteLine("Precione Intro para volver al menu");
            Console.ReadLine();
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
                Console.WriteLine("3. Testeo");
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
                        tipoUsuario = "TESTEO";
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
                if (tipoUsuario == "CLIENTE" || tipoUsuario == "ADMINISTRADOR" || tipoUsuario == "TESTEO")
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
                            MenuArticulo(tipoUsuario);
                            break;
                        case 2:
                            MenuPublicacion(tipoUsuario);
                            break;
                        case 3:
                            MenuUsuario(tipoUsuario);
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
        }
        static void MenuBuscarArticulo(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu Buscar", "1. Buscar artículo por ID", "2. Buscar artículo por Nombre" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenu(opciones);
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionBuscarArticulo(tipoUsuario, opcionSeleccionada);
            }
        }
        #endregion
        #region Publicacion
        static void MenuPublicacion(string tipoUsuario)
        {
            bool valido = false;
            string[] opcionesCliente = new string[] { "Menu Publicacion", "1. Mostrar", "2. Buscar" };
            string[] opcionesAdministrador = new string[] { "Menu Publicacion", "1. Mostrar", "2. Buscar", "3. Dar de alta" };

            while (!valido)
            {
                Console.Clear();
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
        }
        static void MenuMostrarPublicacion(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu Mostrar", "1. Mostrar todas las publicaciones", "2. Mostrar todas las ventas", "3. Mostrar todas las subastas" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenu(opciones);
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
                MostrarOpcionesMenu(opciones);
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionBuscarPublicacion(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuAltaPublicacion(string tipoUsuario)
        {
            bool valido = false;
            string[] opcionesAdministrador = new string[] { "Menu Alta", "1. Dar de alta venta", "2. Dar de alta subasta" };
            string[] opcionesTesteo = new string[] { "Menu Alta", "1. Dar de alta publicacion", "2. Dar de alta venta", "3. Dar de alta subasta" };

            while (!valido)
            {
                Console.Clear();
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
        }
        static void MenuMostrarUsuario(string tipoUsuario)
        {
            bool valido = false;
            string[] opciones = new string[] { "Menu Mostrar", "1. Mostrar todos los usuarios", "2. Mostrar todos los clientes", "3. Mostrar todos los administradores" };

            while (!valido)
            {
                Console.Clear();
                MostrarOpcionesMenu(opciones);
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
                MostrarOpcionesMenu(opciones);
                int.TryParse(Console.ReadLine(), out int opcionSeleccionada);

                OpcionBuscarUsuario(tipoUsuario, opcionSeleccionada);
            }
        }
        static void MenuAltaUsuario(string tipoUsuario)
        {
            bool valido = false;
            string[] opcionesAdministrador = new string[] { "Menu Alta", "1. Dar de alta cliente", "2. Dar de alta administrador" };
            string[] opcionesTesteo = new string[] { "Menu Alta", "1. Dar de alta usuario", "2. Dar de alta cliente", "3. Dar de alta administrador" };

            while (!valido)
            {
                Console.Clear();
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
                    miSistema.ImprimirArticulo(miSistema.ObtenerArticulos(), true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuArticulo(tipoUsuario);
                    break;
                case 2:
                    MenuBuscarArticulo(tipoUsuario);
                    break;
                case 3:
                    AltaArticulo();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuArticulo(tipoUsuario);
                    break;
            }
        }
        static void OpcionBuscarArticulo(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    MenuArticulo(tipoUsuario);
                    break;
                case 1:
                    ObtenerArticuloPorId();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarArticulo(tipoUsuario);
                    break;
                case 2:
                    ObtenerArticuloPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarArticulo(tipoUsuario);
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
                    Menu(tipoUsuario);
                    break;
                case 1:
                    MenuMostrarPublicacion(tipoUsuario);
                    break;
                case 2:
                    MenuBuscarPublicacion(tipoUsuario);
                    break;
                case 3:
                    MenuAltaPublicacion(tipoUsuario);
                    break;
            }
        }
        static void OpcionMostrarPublicacion(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    MenuPublicacion(tipoUsuario);
                    break;
                case 1:
                    miSistema.ImprimirPublicacion(miSistema.ObtenerPublicaciones(false, false), true, true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarPublicacion(tipoUsuario);
                    break;
                case 2:
                    miSistema.ImprimirPublicacion(miSistema.ObtenerPublicaciones(true, false), true, true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarPublicacion(tipoUsuario);
                    break;
                case 3:
                    miSistema.ImprimirPublicacion(miSistema.ObtenerPublicaciones(false, true), true, true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarPublicacion(tipoUsuario);
                    break;
            }
        }
        static void OpcionBuscarPublicacion(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    MenuPublicacion(tipoUsuario);
                    break;
                case 1:
                    ObtenerPublicacionPorId();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarPublicacion(tipoUsuario);
                    break;
                case 2:
                    ObtenerPublicacionPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarPublicacion(tipoUsuario);
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
                    MenuPublicacion(tipoUsuario);
                    break;
                case 1:
                    AltaPublicacion();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaPublicacion(tipoUsuario);
                    break;
                case 2:
                    AltaVenta();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaPublicacion(tipoUsuario);
                    break;
                case 3:
                    AltaSubasta();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaPublicacion(tipoUsuario);
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
                    MenuMostrarUsuario(tipoUsuario);
                    break;
                case 2:
                    MenuBuscarUsuario(tipoUsuario);
                    break;
                case 3:
                    MenuAltaUsuario(tipoUsuario);
                    break;
                case 4:
                    miSistema.ImprimirUsuario(miSistema.ObtenerUsuarios(true, false), true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuUsuario(tipoUsuario);
                    break;
            }
        }
        static void OpcionMostrarUsuario(string tipoUsuario, int opcionSeleccionada)
        {
            switch (opcionSeleccionada)
            {
                case 0:
                    MenuUsuario(tipoUsuario);
                    break;
                case 1:
                    miSistema.ImprimirUsuario(miSistema.ObtenerUsuarios(false, false), true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarUsuario(tipoUsuario);
                    break;
                case 2:
                    miSistema.ImprimirUsuario(miSistema.ObtenerUsuarios(true, false), true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarUsuario(tipoUsuario);
                    break;
                case 3:
                    miSistema.ImprimirUsuario(miSistema.ObtenerUsuarios(false, true), true);
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuMostrarUsuario(tipoUsuario);
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
                    MenuBuscarUsuario(tipoUsuario);
                    break;
                case 2:
                    ObtenerUsuarioPorNombre();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuBuscarUsuario(tipoUsuario);
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
                    MenuAltaUsuario(tipoUsuario);
                    break;
                case 2:
                    AltaCliente();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaUsuario(tipoUsuario);
                    break;
                case 3:
                    AltaAdministrador();
                    VolverAlMenu(); // Limpia la consola cuando el usuario preciona Intro
                    MenuAltaUsuario(tipoUsuario);
                    break;
            }
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
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids

            miSistema.ImprimirArticulo(miSistema.ObtenerArticuloPorId(ids), true);
        }
        static void ObtenerArticuloPorNombre()
        {
            Console.WriteLine("Nombre de los articulos separados por ,:");
            string nombres_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<string> nombres = miSistema.ParseoNombre(nombres_crudos); // Convierte el input del usuario en una lista de nombres

            miSistema.ImprimirArticulo(miSistema.ObtenerArticuloPorNombre(nombres), true);
        }
        #endregion
        #region Publicacion
        static void ObtenerPublicacionPorId()
        {
            Console.WriteLine("Id de las publicaciones separadas por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids

            miSistema.ImprimirPublicacion(miSistema.ObtenerPublicacionPorId(ids, false, false), true, false);
        }
        static void ObtenerPublicacionPorNombre()
        {
            Console.WriteLine("Nombre de las publicaciones separadas por ,:");
            string nombres_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<string> nombres = miSistema.ParseoNombre(nombres_crudos); // Convierte el input del usuario en una lista de nombres

            miSistema.ImprimirPublicacion(miSistema.ObtenerPublicacionPorNombre(nombres, false, false), true, false);
        }
        #endregion
        #region Usuario
        static void ObtenerUsuarioPorId()
        {
            Console.WriteLine("Id de los usuarios separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids

            miSistema.ImprimirUsuario(miSistema.ObtenerUsuarioPorId(ids, false, false), true);
        }
        static void ObtenerUsuarioPorNombre()
        {
            Console.WriteLine("Nombre de los usuarios separados por ,:");
            string nombres_crudos = Console.ReadLine() ?? string.Empty;
            Console.Clear();
            List<string> nombres = miSistema.ParseoNombre(nombres_crudos); // Convierte el input del usuario en una lista de nombres

            miSistema.ImprimirUsuario(miSistema.ObtenerUsuarioPorNombre(nombres, false, false), true);
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

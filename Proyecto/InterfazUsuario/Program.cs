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

        #region Menus
        static void MenuTipoUsuario()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Menu selección tipo de usuario");
            Console.WriteLine("1. Usuario");
            Console.WriteLine("2. Administrador");
            Console.WriteLine("3. Testeo");
            Console.WriteLine("-------------------------------------");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);
            string tipoUsuario;

            switch (opcionSelecionada)
            {
                case 1:
                    Console.Clear();
                    tipoUsuario = "USUARIO";
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
                    Console.WriteLine("Seleccione una opcion valida");
                    MenuTipoUsuario();
                    break;
            }
        }
        static void Menu(string tipoUsuario)
        {
            if (tipoUsuario == "USUARIO" || tipoUsuario == "ADMINISTRADOR" || tipoUsuario == "TESTEO")
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Menu");
                Console.WriteLine("1. Artículos");
                Console.WriteLine("2. Publicaciones");
                Console.WriteLine("3. Usuarios");
                Console.WriteLine("4. ...");
                Console.WriteLine("-------------------------------------");
                int.TryParse(Console.ReadLine(), out int opcionSelecionada);

                switch (opcionSelecionada)
                {
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
                    case 4:
                        Console.Clear();
                        MenuTipoUsuario();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Seleccione una opcion valida");
                        Menu(tipoUsuario);
                        break;
                }
            }
        }
        static void MenuArticulo(string tipoUsuario)
        {
            // Menu
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Menu Artículos");
            if (tipoUsuario == "USUARIO")
            {
            }
            else if (tipoUsuario == "ADMINISTRADOR")
            {
            }
            else 
            {
                Console.WriteLine("1. Mostrar catálogo");
                Console.WriteLine("2. Buscar artículos por ID");
                Console.WriteLine("3. Dar de alta artículo");
                Console.WriteLine("4. ...");
            }
            Console.WriteLine("-------------------------------------");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            OpcionSeleccionadaArticulo(tipoUsuario, opcionSelecionada);
        }
        static void MenuPublicacion(string tipoUsuario)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Menu Publicaciones");
            if (tipoUsuario == "USUARIO")
            {
            }
            else if (tipoUsuario == "ADMINISTRADOR")
            {
            }
            else
            {
                Console.WriteLine("1. Mostrar publicaciones");
                Console.WriteLine("2. Buscar publicaciones por ID");
                Console.WriteLine("3. Dar de alta publicacion");
                Console.WriteLine("4. ...");
            }
            Console.WriteLine("-------------------------------------");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            OpcionSeleccionadaPublicacion(tipoUsuario, opcionSelecionada);
        }
        static void MenuUsuario(string tipoUsuario)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Menu Usuarios");
            if (tipoUsuario == "USUARIO")
            {
            }
            else if (tipoUsuario == "ADMINISTRADOR")
            {
            }
            else
            {
                Console.WriteLine("1. Mostrar usuarios");
                Console.WriteLine("2. Buscar usuarios por ID");
                Console.WriteLine("3. Dar de alta usuario");
                Console.WriteLine("4. ...");
            }
            Console.WriteLine("-------------------------------------");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);
            
            OpcionSeleccionadaUsuario(tipoUsuario, opcionSelecionada);
        }
        static void OpcionSeleccionadaArticulo(string tipoUsuario, int opcionSelecionada)
        {
            // Ejecución de las opciones del menu por tipo de usuario
            if (tipoUsuario == "USUARIO")
            {
            }
            else if (tipoUsuario == "ADMINISTRADOR")
            {
            }
            else
            {
                switch (opcionSelecionada)
                {
                    case 1:
                        Console.Clear();
                        miSistema.ImprimirArticulo();
                        MenuArticulo(tipoUsuario);
                        break;
                    case 2:
                        Console.Clear();
                        ObtenerArticuloPorId();
                        MenuArticulo(tipoUsuario);
                        break;
                    case 3:
                        Console.Clear();
                        AltaArticulo();
                        MenuArticulo(tipoUsuario);
                        break;
                    case 4:
                        Console.Clear();
                        Menu(tipoUsuario);
                        break;
                    default:
                        Console.WriteLine("Seleccione una opcion valida");
                        break;
                }
            }
        }
        static void OpcionSeleccionadaPublicacion(string tipoUsuario, int opcionSelecionada)
        {
            // Ejecución de las opciones del menu por tipo de usuario
            if (tipoUsuario == "USUARIO")
            {
            }
            else if (tipoUsuario == "ADMINISTRADOR")
            {
            }
            else
            {
                switch (opcionSelecionada)
                {
                    case 1:
                        Console.Clear();
                        miSistema.ImprimirPublicacion();
                        MenuPublicacion(tipoUsuario);
                        break;
                    case 2:
                        Console.Clear();
                        ObtenerPublicacionPorId();
                        MenuPublicacion(tipoUsuario);
                        break;
                    case 3:
                        Console.Clear();
                        AltaPublicacion();
                        MenuPublicacion(tipoUsuario);
                        break;
                    case 4:
                        Console.Clear();
                        Menu(tipoUsuario);
                        break;
                    default:
                        Console.WriteLine("Seleccione una opcion valida");
                        break;
                }
            }
        }
        static void OpcionSeleccionadaUsuario(string tipoUsuario, int opcionSelecionada)
        {
            // Ejecución de las opciones del menu por tipo de usuario
            if (tipoUsuario == "USUARIO")
            {
            }
            else if (tipoUsuario == "ADMINISTRADOR")
            {
            }
            else
            {
                switch (opcionSelecionada)
                {
                    case 1:
                        Console.Clear();
                        miSistema.ImprimirUsuario();
                        MenuUsuario(tipoUsuario);
                        break;
                    case 2:
                        Console.Clear();
                        ObtenerUsuarioPorId();
                        MenuUsuario(tipoUsuario);
                        break;
                    case 3:
                        Console.Clear();
                        AltaUsuario();
                        MenuUsuario(tipoUsuario);
                        break;
                    case 4:
                        Console.Clear();
                        Menu(tipoUsuario);
                        break;
                    default:
                        Console.WriteLine("Seleccione una opcion valida");
                        break;
                }
            }
        }
        #endregion

        #region Solicitud datos
        static void ObtenerArticuloPorId()
        {
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de articulos con los ids

            miSistema.ImprimirArticulo(articulos);
        }
        static void ObtenerPublicacionPorId()
        {
            Console.WriteLine("Id de las publicaciones separadas por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Publicacion> publicacion = miSistema.ObtenerPublicacionPorId(ids); // Obtiene la lista de publicaciones con los ids

            miSistema.ImprimirPublicacion(publicacion);
        }
        static void ObtenerUsuarioPorId()
        {
            Console.WriteLine("Id de los usuarios separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            List<int> ids = miSistema.ParseoId(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Usuario> usuario = miSistema.ObtenerUsuarioPorId(ids); // Obtiene la lista de usuarios con los ids

            miSistema.ImprimirUsuario(usuario);
        }
        #endregion

        #region Altas
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
        static void AltaUsuario()
        {
            Console.WriteLine("Ingrese los datos que desea asociar a la publicacion");
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
        #endregion
    }
}

using LogicaNegocio;

namespace InterfazUsuario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuTesteo();
        }

        // Crear una instancia de la clase Sistema
        private static Sistema miSistema = new Sistema();

        // Menus Principales
        static void Menu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Artículos");
            Console.WriteLine("2. Publicaciones");
            Console.WriteLine("3. Usuarios");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    MenuArticulos();
                    break;
                case 2:
                    MenuPublicaciones();
                    break;
                case 3:
                    MenuUsuarios();
                    break;
                default:
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void MenuArticulos()
        {
            Console.WriteLine("Menu Artículos");
            Console.WriteLine("1. Mostrar catálogo");
            Console.WriteLine("2. Buscar artículo por ID");
            Console.WriteLine("3. Dar de alta artículo");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    miSistema.MostrarCatalogo();
                    break;
                case 2:
                    ObtenerArticuloPorId();
                    break;
                case 3:
                    AltaArticulo();
                    break;
                default:
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void MenuPublicaciones()
        {
            Console.WriteLine("Menu Publicaciones");
            Console.WriteLine("1. Mostrar publicaciones");
            Console.WriteLine("2. Buscar publicacion por ID");
            Console.WriteLine("3. Dar de alta publicacion");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    miSistema.MostrarPublicaciones();
                    break;
                case 2:
                    ObtenerPublicacionPorId();
                    break;
                case 3:
                    AltaPublicacion();
                    break;
                default:
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void MenuUsuarios()
        {
            Console.WriteLine("Menu Usuarios");
            Console.WriteLine("1. Mostrar usuarios");
            Console.WriteLine("2. Buscar usuario por ID");
            Console.WriteLine("3. Dar de alta usuario");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    miSistema.MostrarUsuarios();
                    break;
                case 2:
                    ObtenerUsuarioPorId();
                    break;
                case 3:
                    AltaUsuario();
                    break;
                default:
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }

        // Solicitudes de datos
        static void ObtenerArticuloPorId()
        {
            Console.WriteLine("Introduzca el ID");
            int.TryParse(Console.ReadLine(), out int id);

            miSistema.ObtenerArticuloPorId(id);
        }
        static void ObtenerPublicacionPorId()
        {
            Console.WriteLine("Introduzca el ID");
            int.TryParse(Console.ReadLine(), out int id);

            miSistema.ObtenerPublicacionPorId(id);
        }
        static void ObtenerUsuarioPorId()
        {
            Console.WriteLine("Introduzca el ID");
            int.TryParse(Console.ReadLine(), out int id);

            miSistema.ObtenerUsuarioPorId(id);
        }
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

            miSistema.AltaArticulo(nombre, precio);
        }
        static void AltaPublicacion()
        {
            Console.WriteLine("Ingrese los datos de la publicacion");
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Estado:");
            string estado = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;

            List<int> ids = miSistema.ParseoIds(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de publicaciones con los ids
            

            miSistema.AltaPublicacion(nombre, estado, DateTime.Now, articulos);
        }


        // Menu testeo
        static void MenuTesteo()
        {
            Console.WriteLine("Menu Testeo");
            Console.WriteLine("1. Consultar Usuario por id");
            Console.WriteLine("2. Consultar Articulos por id");
            Console.WriteLine("3. Consultar Publicaciones por id");
            Console.WriteLine("4. Agregar un Articulo");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            if (opcionSelecionada == 1)
            {
                // Solicitud datos
                Console.WriteLine("Ingrese el id que desea buscar");
                int.TryParse(Console.ReadLine(), out int id);

                miSistema.ObtenerUsuarioPorId(id);
            }
            else if ( opcionSelecionada == 4)
            {
                // Solicitud datos
                Console.WriteLine("Ingrese el nombre del Articulo");
                // ?? operador de coalescencia nula
                // Si es null devuelve el valor de la derecha
                // Si no es null devuelve el valor de la izquierda
                string nombre = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Ingrese el Precio");
                decimal.TryParse(Console.ReadLine(), out decimal precio);

                miSistema.AltaArticulo(nombre, precio);
            }
        }
    }
}

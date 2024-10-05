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
            miSistema.ObtenerArticuloPorId(new List<int> { 1, 2 });
            Menu();
        }

        // Crear una instancia de la clase Sistema
        private static Sistema miSistema = new Sistema();

        #region Menus
        static void Menu()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Menu");
            Console.WriteLine("1. Artículos");
            Console.WriteLine("2. Publicaciones");
            Console.WriteLine("3. Usuarios");
            Console.WriteLine("-------------------------------------");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    Console.Clear();
                    MenuArticulo();
                    break;
                case 2:
                    Console.Clear();
                    MenuPublicacion();
                    break;
                case 3:
                    Console.Clear();
                    MenuUsuario();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Seleccione una opcion valida");
                    Menu();
                    break;
            }
        }
        static void MenuArticulo()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Menu Artículos");
            Console.WriteLine("1. Mostrar catálogo");
            Console.WriteLine("2. Buscar artículos por ID");
            Console.WriteLine("3. Dar de alta artículo");
            Console.WriteLine("4. ...");
            Console.WriteLine("-------------------------------------");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    Console.Clear();
                    miSistema.ImprimirArticulo();
                    MenuArticulo();
                    break;
                case 2:
                    Console.Clear();
                    ObtenerArticuloPorId();
                    MenuArticulo();
                    break;
                case 3:
                    Console.Clear();
                    AltaArticulo();
                    MenuArticulo();
                    break;
                case 4:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void MenuPublicacion()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Menu Publicaciones");
            Console.WriteLine("1. Mostrar publicaciones");
            Console.WriteLine("2. Buscar publicaciones por ID");
            Console.WriteLine("3. Dar de alta publicacion");
            Console.WriteLine("4. ...");
            Console.WriteLine("-------------------------------------");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    Console.Clear();
                    miSistema.ImprimirPublicacion();
                    MenuPublicacion();
                    break;
                case 2:
                    Console.Clear();
                    ObtenerPublicacionPorId();
                    MenuPublicacion();
                    break;
                case 3:
                    Console.Clear();
                    AltaPublicacion();
                    MenuPublicacion();
                    break;
                case 4:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void MenuUsuario()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Menu Usuarios");
            Console.WriteLine("1. Mostrar usuarios");
            Console.WriteLine("2. Buscar usuarios por ID");
            Console.WriteLine("3. Dar de alta usuario");
            Console.WriteLine("4. ...");
            Console.WriteLine("-------------------------------------");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    Console.Clear();
                    miSistema.ImprimirUsuario();
                    MenuUsuario();
                    break;
                case 2:
                    Console.Clear();
                    ObtenerUsuarioPorId();
                    MenuUsuario();
                    break;
                case 3:
                    Console.Clear();
                    AltaUsuario();
                    MenuUsuario();
                    break;
                case 4:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
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

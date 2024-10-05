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
            Menu();
        }

        // Crear una instancia de la clase Sistema
        private static Sistema miSistema = new Sistema();

        #region Menus
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
                    MenuArticulo();
                    break;
                case 2:
                    MenuPublicacion();
                    break;
                case 3:
                    MenuUsuario();
                    break;
                default:
                    Console.WriteLine("Seleccione una opcion valida");
                    break;
            }
        }
        static void MenuArticulo()
        {
            Console.WriteLine("Menu Artículos");
            Console.WriteLine("1. Mostrar catálogo");
            Console.WriteLine("2. Buscar artículos por ID");
            Console.WriteLine("3. Dar de alta artículo");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    miSistema.ImprimirArticulo();
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
        static void MenuPublicacion()
        {
            Console.WriteLine("Menu Publicaciones");
            Console.WriteLine("1. Mostrar publicaciones");
            Console.WriteLine("2. Buscar publicaciones por ID");
            Console.WriteLine("3. Dar de alta publicacion");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    miSistema.ImprimirPublicacion();
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
        static void MenuUsuario()
        {
            Console.WriteLine("Menu Usuarios");
            Console.WriteLine("1. Mostrar usuarios");
            Console.WriteLine("2. Buscar usuarios por ID");
            Console.WriteLine("3. Dar de alta usuario");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            switch (opcionSelecionada)
            {
                case 1:
                    miSistema.ImprimirUsuario();
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
        #endregion

        #region Solicitud datos
        static void ObtenerArticuloPorId()
        {
            Console.WriteLine("Id de los articulos separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            List<int> ids = miSistema.ParseoIds(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de articulos con los ids

            miSistema.ImprimirArticulo(articulos);
        }
        static void ObtenerPublicacionPorId()
        {
            Console.WriteLine("Id de las publicaciones separadas por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            List<int> ids = miSistema.ParseoIds(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Publicacion> publicacion = miSistema.ObtenerPublicacionPorId(ids); // Obtiene la lista de publicaciones con los ids

            miSistema.ImprimirPublicacion(publicacion);
        }
        static void ObtenerUsuarioPorId()
        {
            Console.WriteLine("Id de los usuarios separados por ,:");
            string ids_crudos = Console.ReadLine() ?? string.Empty;
            List<int> ids = miSistema.ParseoIds(ids_crudos); // Convierte el input del usuario en una lista de ids
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

            miSistema.AltaArticulo(nombre, precio);
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
            List<int> ids = miSistema.ParseoIds(ids_crudos); // Convierte el input del usuario en una lista de ids
            List<Articulo> articulos = miSistema.ObtenerArticuloPorId(ids); // Obtiene la lista de publicaciones con los ids
            
            miSistema.AltaPublicacion(nombre, estado, fecha, articulos, cliente, administrador, fechaFin);
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

            miSistema.AltaUsuario(nombre, apellido, email, contrasenia);
        }
        #endregion
    }
}

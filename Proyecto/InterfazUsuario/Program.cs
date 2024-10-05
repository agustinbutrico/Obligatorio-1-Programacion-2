using LogicaNegocio;

namespace InterfazUsuario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        // Crear una instancia de la clase Sistema
        private static Sistema miSistema = new Sistema();

        // Menu principal
        static void Menu()
        {
            Console.WriteLine("Menu principal");
            Console.WriteLine("1. Consultar Usuario por id");
            Console.WriteLine("2. Consultar Articulos por id");
            Console.WriteLine("3. Consultar Publicaciones por id");
            Console.WriteLine("4. Agregar un Articulo");
            Console.WriteLine("5. Agregar un Usuario");
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            if (opcionSelecionada == 1)
            {
                // Solicitud datos
                Console.WriteLine("Ingrese el id del Usuario que desea consultar");
                int.TryParse(Console.ReadLine(), out int id);

                miSistema.ObtenerUsuarioPorId(id);
            }
            else if (opcionSelecionada == 2)
            {
                Console.WriteLine("Ingrese el Id del articulo que desea consultar");
                int.TryParse(Console.ReadLine(), out int id);

                miSistema.ObtenerArticuloPorId(id);
            }
            else if (opcionSelecionada == 3) 
            {
                Console.WriteLine("Ingrese el Id de la publicacion que desea consultar");
                int.TryParse(Console.ReadLine(), out int id);

                miSistema.ObtenerPublicacionPorId(id);
            }
            else if (opcionSelecionada == 4)
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
            else if (opcionSelecionada == 5)
            {
                Console.WriteLine("Ingrese el Nombre del Usuario");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el Apellido del Usuario");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el Email del Usuario");
                string email = Console.ReadLine();
                Console.WriteLine("Ingrese una contrasenia para el Usuario");
                string contrasenia = Console.ReadLine();

                miSistema.AltaUsuario(nombre, apellido, email, contrasenia);
            }
        }
    }
}

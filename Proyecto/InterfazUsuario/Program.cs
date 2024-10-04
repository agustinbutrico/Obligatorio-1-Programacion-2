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
            int.TryParse(Console.ReadLine(), out int opcionSelecionada);

            if (opcionSelecionada == 1)
            {
                Console.WriteLine("Ingrese el id que desea buscar");
                int.TryParse(Console.ReadLine(), out int id);

                miSistema.ObtenerUsuarioPorId(id);
            }
        }
    }
}

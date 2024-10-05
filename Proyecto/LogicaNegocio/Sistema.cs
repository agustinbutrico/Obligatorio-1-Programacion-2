using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Sistema
    {
        #region Constructor
        // Atributos de la clase con propiedades automaticas (shortHand)
        private List<Usuario> _usuarios {  get; set; }
        private List<Publicacion> _publicaciones { get; set; }
        private List<Articulo> _articulos { get; set; }

        // Ejecucion principal
        public Sistema()
        {
            _usuarios = new List<Usuario>();
            _publicaciones = new List<Publicacion>();
            _articulos = new List<Articulo>();
        }
        #endregion

        #region Parseo Datos
        public List<int> ParseoIds(string ids_crudos)
        {
            List<int> lista_ids = new List<int>(); // Crea una lista de los ids ingresados
            string[] ids = ids_crudos.Split(','); // Crea un array de los ids

            for (int i = 0; i < ids.Length; i++) // Recorre todos los elementos de ids
            {
                lista_ids.Add(int.Parse(ids[i].Trim())); // Remueve los espacios, transforma a int y añiade a la lista el id
            }
            return lista_ids;
        }
        #endregion

        #region Obtencion de listas
        public List<Articulo> ObtenerArticuloPorId(List<int> ids)
        {
            List<Articulo> articulos = new List<Articulo>();  // Inicializamos la lista que contendrá el o los artículos

            for (int i = 0; i < _articulos.Count; i++)
            {
                if (ids.Contains(_articulos[i].Id)) // Si la lista de ids contiene algún artículo
                {
                    articulos.Add(_articulos[i]); // Se añade el artículo a la lista artículos
                }
            }

            if (articulos.Count > 0)
            {
                // Mensaje si no encontramos de Artículo
                Console.WriteLine("Articulo no encontrada.");
            }
            return articulos;
        }
        public List<Publicacion> ObtenerPublicacionPorId(List<int> ids)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();  // Inicializamos la lista que contendrá el o las publicaciones

            for (int i = 0; i < _publicaciones.Count; i++)
            {
                if (ids.Contains(_publicaciones[i].Id)) // Si la lista de ids contiene algúna publicacion
                {
                    publicaciones.Add(_publicaciones[i]); // Se añade la publicacion a la lista publicaciones
                }
            }

            if (publicaciones.Count > 0)
            {
                // Mensaje si no encontramos la publicación
                Console.WriteLine("Publicación no encontrada.");
            }
            return publicaciones;
        }
        public List<Usuario> ObtenerUsuarioPorId(List<int> ids)
        {
            List<Usuario> usuarios = new List<Usuario>();  // Inicializamos la lista que contendrá el o los usuarios

            for (int i = 0; i < _usuarios.Count; i++)
            {
                if (ids.Contains(_usuarios[i].Id)) // Si la lista de ids contiene algún usuario
                {
                    usuarios.Add(_usuarios[i]); // Se añade el usuario a la lista usuarios
                }
            }

            if (usuarios.Count > 0)
            {
                // Mensaje si no encontramos ningun Usuario
                Console.WriteLine("Usuario no encontrado.");
            }
            return usuarios;
        }
        #endregion

        #region Impresion de listas
        public void ImprimirArticulo()
        {
            for (int i = 0; i < _articulos.Count; i++)
            {
                // Mostramos los detalles del Artículo
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"ID: {_articulos[i].Id}");
                Console.WriteLine($"Nombre: {_articulos[i].Nombre}");
                Console.WriteLine($"Estado: {_articulos[i].Precio}");
            }
            Console.WriteLine("-------------------------------------");
        }
        public void ImprimirPublicacion()
        {
            for (int i = 0; i < _publicaciones.Count; i++)
            {
                // Mostramos los detalles de las publicaciones
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"ID: {_publicaciones[i].Id}");
                Console.WriteLine($"Nombre: {_publicaciones[i].Nombre}");
                Console.WriteLine($"Estado: {_publicaciones[i].Estado}");
                Console.WriteLine($"Fecha: {_publicaciones[i].Fecha}");
                Console.WriteLine($"Articulos: {_publicaciones[i].Articulos}");
                Console.WriteLine($"Cliente: {_publicaciones[i].Cliente}");
                Console.WriteLine($"Administrador: {_publicaciones[i].Administrador}");
                Console.WriteLine($"Fecha Fin: {_publicaciones[i].FechaFin}");
            }
            Console.WriteLine("-------------------------------------");
        }
        public void ImprimirUsuario()
        {
            for (int i = 0; i < _usuarios.Count; i++)
            {
                // Mostramos los detalles del Usuario
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"ID: {_usuarios[i].Id}");
                Console.WriteLine($"Nombre: {_usuarios[i].Nombre}");
                Console.WriteLine($"Apellido: {_usuarios[i].Apellido}");
                Console.WriteLine($"Email: {_usuarios[i].Email}");
            }
            Console.WriteLine("-------------------------------------");
        }
        public void ImprimirArticulo(List<Articulo> articulos)
        {
            for (int i = 0; i < articulos.Count; i++)
            {
                // Mostramos los detalles del Artículo
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"ID: {articulos[i].Id}");
                Console.WriteLine($"Nombre: {articulos[i].Nombre}");
                Console.WriteLine($"Estado: {articulos[i].Precio}");
            }
            Console.WriteLine("-------------------------------------");
        }
        public void ImprimirPublicacion(List<Publicacion> publicaciones)
        {
            for (int i = 0; i < publicaciones.Count; i++)
            {
                // Mostramos los detalles de las publicaciones
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"ID: {publicaciones[i].Id}");
                Console.WriteLine($"Nombre: {publicaciones[i].Nombre}");
                Console.WriteLine($"Estado: {publicaciones[i].Estado}");
                Console.WriteLine($"Fecha: {publicaciones[i].Fecha}");
                Console.WriteLine($"Articulos: {publicaciones[i].Articulos}");
                Console.WriteLine($"Cliente: {publicaciones[i].Cliente}");
                Console.WriteLine($"Administrador: {publicaciones[i].Administrador}");
                Console.WriteLine($"Fecha Fin: {publicaciones[i].FechaFin}");
            }
            Console.WriteLine("-------------------------------------");
        }
        public void ImprimirUsuario(List<Usuario> usuarios)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                // Mostramos los detalles del Usuario
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"ID: {usuarios[i].Id}");
                Console.WriteLine($"Nombre: {usuarios[i].Nombre}");
                Console.WriteLine($"Apellido: {usuarios[i].Apellido}");
                Console.WriteLine($"Email: {usuarios[i].Email}");
            }
            Console.WriteLine("-------------------------------------");
        }
        #endregion

        #region Altas
        public void AltaArticulo(string nombre, decimal precio)
        {
            try
            {
                Articulo nuevoArticulo = new Articulo(nombre, precio);
                // Validación de la relacion entre los datos ingresados
                nuevoArticulo.Validar();
                // Si los datos son validos entonces se registra el Articulo
                if (!_articulos.Contains(nuevoArticulo))
                {
                    _articulos.Add(nuevoArticulo);
                    Console.WriteLine("El articulo fue registrado correctamente");
                }
                else
                {
                    throw new Exception("Ya existe un articulo con el mismo ID");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void AltaPublicacion(string nombre, string estado, DateTime fecha, List<Articulo> articulos, Cliente? cliente, Administrador? administrador, DateTime fechaFin)
        {
            try
            {
                Publicacion nuevaPublicacion = new Publicacion(nombre, estado, fecha, articulos, cliente, administrador, fechaFin);
                // Validación de la relacion entre los datos ingresados
                nuevaPublicacion.Validar();
                // Si los datos son validos entonces se registra la Publicación
                if (!_publicaciones.Contains(nuevaPublicacion))
                {
                    _publicaciones.Add(nuevaPublicacion);
                    Console.WriteLine("La publicación fue registrada correctamente");
                }
                else
                {
                    throw new Exception("Ya existe una publicación con el mismo ID");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void AltaUsuario(string nombre, string apellido, string email, string contrasenia)
        {
            try
            {
                Usuario nuevoUsuario = new Usuario(nombre, apellido, email, contrasenia);
                // Validación de la relacion entre los datos ingresados
                nuevoUsuario.Validar();
                // Si los datos son validos entonces se registra el Usuario
                if (!_usuarios.Contains(nuevoUsuario))
                {
                    _usuarios.Add(nuevoUsuario);
                    Console.WriteLine("El usuario fue registrado correctamente");
                }
                else
                {
                    throw new Exception("Ya existe un usuario con el mismo ID");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        #endregion

        #region Precargas
        public void PrecargaArticulo()
        {
            AltaArticulo("Pelota de fútbol", 450);
            AltaArticulo("Camiseta deportiva", 1200);
            AltaArticulo("Zapatillas running", 3500);
            AltaArticulo("Raqueta de tenis", 4200);
            AltaArticulo("Balón de baloncesto", 800);
            AltaArticulo("Guantes de boxeo", 2200);
            AltaArticulo("Casco de ciclismo", 1800);
            AltaArticulo("Saco de dormir", 2300);
            AltaArticulo("Bolsa de gimnasio", 950);
            AltaArticulo("Bicicleta de montaña", 15000);
            AltaArticulo("Mochila de trekking", 2100);
            AltaArticulo("Botella térmica", 750);
            AltaArticulo("Palo de hockey", 1700);
            AltaArticulo("Pesas ajustables", 3000);
            AltaArticulo("Cinta para correr", 25000);
            AltaArticulo("Guantes de arquero", 900);
            AltaArticulo("Tabla de surf", 12000);
            AltaArticulo("Canilleras", 600);
            AltaArticulo("Traje de neopreno", 5400);
            AltaArticulo("Gafas de natación", 650);
            AltaArticulo("Bola de bowling", 3500);
            AltaArticulo("Skateboard", 2400);
            AltaArticulo("Patines en línea", 2900);
            AltaArticulo("Set de pesas", 4200);
            AltaArticulo("Cuerda para saltar", 300);
            AltaArticulo("Tobilleras con peso", 850);
            AltaArticulo("Set de dardos", 400);
            AltaArticulo("Bate de béisbol", 1900);
            AltaArticulo("Bola de voleibol", 850);
            AltaArticulo("Aro de baloncesto", 2700);
            AltaArticulo("Silla de camping", 1100);
            AltaArticulo("Tienda de campaña", 8700);
            AltaArticulo("Colchoneta de yoga", 1200);
            AltaArticulo("Barra de dominadas", 1900);
            AltaArticulo("Reloj deportivo", 6500);
            AltaArticulo("Monopatín eléctrico", 18000);
            AltaArticulo("Kit de pesca", 3200);
            AltaArticulo("Bolsa de golf", 7600);
            AltaArticulo("Raqueta de bádminton", 1600);
            AltaArticulo("Patineta longboard", 3300);
            AltaArticulo("Bola de rugby", 1050);
            AltaArticulo("Kit de snorkel", 1800);
            AltaArticulo("Camiseta de compresión", 1300);
            AltaArticulo("Gorra deportiva", 400);
            AltaArticulo("Balón medicinal", 2000);
            AltaArticulo("Kit de arquería", 9800);
            AltaArticulo("Soga de escalada", 5600);
            AltaArticulo("Casco de esquí", 3700);
            AltaArticulo("Gafas de ciclismo", 900);

        }
        public void PrecargarPublicacion()
        {

        }
        public void PrecargaUsuario()
        {
            AltaUsuario("Valentin", "Latorre", "ValentinLatorre@Gmail.com", "Valentin1234");
            AltaUsuario("Agustin", "Butrico", "AgustinButrico@gmail.com", "Agustin1234");
            AltaUsuario("Juan", "Peres", "Juanperes@hmail.com", "Juan1234");
            AltaUsuario("Esteban", "Lopez", "EstebanLopez@hmail.com", "556643");
            AltaUsuario("Carlos", "Medina", "CarlosMedina@hmail.com", "Medina1234");
            AltaUsuario("Mariano", "Morales", "MarianoMorales@hmail.com", "Mariano2");
            AltaUsuario("Estela", "Rosales", "EstelaRosales@hmail.com", "Rosalia46");
            AltaUsuario("Marcos", "Sauce", "MarcosSauce@hmail.com", "Sauce31");
            AltaUsuario("Lucia", "Gomez", "LuciaGomezs@hmail.com", "Lucia1990");
            AltaUsuario("Rodrigo", "Barrios", "RodrigoBarrios@hmail.com", "RodrigoBarrios12");
        }
        #endregion
    }
}

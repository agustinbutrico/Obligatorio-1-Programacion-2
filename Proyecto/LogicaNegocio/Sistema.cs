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
        // Convierte en una lista de ids el string pasado por parametros
        public List<int> ParseoId(string ids_crudos)
        {
            List<int> lista_ids = new List<int>(); // Crea una lista de los ids ingresados
            try
            {
                string[] ids = ids_crudos.Split(','); // Crea un array de los ids

                for (int i = 0; i < ids.Length; i++) // Recorre todos los elementos de ids
                {
                    lista_ids.Add(int.Parse(ids[i].Trim())); // Remueve los espacios, transforma a int y añade a la lista el id
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return lista_ids;
        }
        // Convierte en una lista de nombres el string pasado por parametros
        public List<string> ParseoNombre(string nombres_crudos)
        {
            List<string> lista_nombres = new List<string>(); // Crea una lista de los nombres ingresados
            try
            {
                string[] nombres = nombres_crudos.Split(','); // Crea un array de los nombres

                for (int i = 0; i < nombres.Length; i++) // Recorre todos los elementos de nombres
                {
                    lista_nombres.Add(nombres[i].Trim()); // Remueve los espaciosy añade a la lista el nombre
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return lista_nombres;
        }
        // Convierte en string los ids de la lista de articulos pasada por parametros
        public string ParseoArticulo(List<Articulo> articulos)
        {
            string ids_articulos = string.Empty;
            try
            {
                for (int i = 0; i < articulos.Count; i++)
                {
                    ids_articulos += $"{articulos[i].Id}, ";
                }

                if (articulos.Count > 0)
                {
                    // Quitamos la , del final de los ids
                    ids_articulos = ids_articulos.Substring(0, ids_articulos.Length - 2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return ids_articulos;
        }
        #endregion

        #region Obtención de listas
        public List<Articulo> ObtenerArticuloPorId(List<int> ids)
        {
            List<Articulo> articulos = new List<Articulo>();  // Inicializamos la lista que contendrá el o los artículos
            try 
            {
                for (int i = 0; i < _articulos.Count; i++)
                {
                    if (ids.Contains(_articulos[i].Id)) // Si la lista de ids contiene algún artículo
                    {
                        articulos.Add(_articulos[i]); // Se añade el artículo a la lista artículos
                    }
                }

                if (articulos.Count == 0)
                {
                    // Mensaje si no encontramos ningún artículo
                    Console.WriteLine("Articulo no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return articulos;
        }
        public List<Publicacion> ObtenerPublicacionPorId(List<int> ids)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();  // Inicializamos la lista que contendrá el o las publicaciones
            try
            {
                for (int i = 0; i < _publicaciones.Count; i++)
                {
                    if (ids.Contains(_publicaciones[i].Id)) // Si la lista de ids contiene algúna publicacion
                    {
                        publicaciones.Add(_publicaciones[i]); // Se añade la publicacion a la lista publicaciones
                    }
                }

                if (publicaciones.Count == 0)
                {
                    // Mensaje si no encontramos ninguna publicación
                    Console.WriteLine("Publicación no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return publicaciones;
        }
        public List<Usuario> ObtenerUsuarioPorId(List<int> ids)
        {
            List<Usuario> usuarios = new List<Usuario>();  // Inicializamos la lista que contendrá el o los usuarios
            try
            {
                for (int i = 0; i < _usuarios.Count; i++)
                {
                    if (ids.Contains(_usuarios[i].Id)) // Si la lista de ids contiene algún usuario
                    {
                        usuarios.Add(_usuarios[i]); // Se añade el usuario a la lista usuarios
                    }
                }

                if (usuarios.Count == 0)
                {
                    // Mensaje si no encontramos ningún usuario
                    Console.WriteLine("Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return usuarios;
        }
        public List<Articulo> ObtenerArticuloPorNombre(List<string> nombres)
        {
            List<Articulo> articulos = new List<Articulo>();  // Inicializamos la lista que contendrá el o los artículos
            try
            {
                for (int i = 0; i < _articulos.Count; i++)
                {
                    if (nombres.Contains(_articulos[i].Nombre)) // Si la lista de nombres contiene algún artículo
                    {
                        articulos.Add(_articulos[i]); // Se añade el artículo a la lista artículos
                    }
                }

                if (articulos.Count == 0)
                {
                    // Mensaje si no encontramos ningún artículo
                    Console.WriteLine("Articulo no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return articulos;
        }
        public List<Publicacion> ObtenerPublicacionPorNombre(List<string> nombres)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();  // Inicializamos la lista que contendrá el o las publicaciones
            try
            {
                for (int i = 0; i < _publicaciones.Count; i++)
                {
                    if (nombres.Contains(_publicaciones[i].Nombre)) // Si la lista de nombres contiene algúna publicación
                    {
                        publicaciones.Add(_publicaciones[i]); // Se añade la publicación a la lista publicaciones
                    }
                }

                if (publicaciones.Count == 0)
                {
                    // Mensaje si no encontramos ningúna publicacion
                    Console.WriteLine("Publicacion no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return publicaciones;
        }
        public List<Usuario> ObtenerUsuarioPorNombre(List<string> nombres)
        {
            List<Usuario> usuarios = new List<Usuario>();  // Inicializamos la lista que contendrá el o los usuarios
            try
            {
                for (int i = 0; i < _usuarios.Count; i++)
                {
                    if (nombres.Contains(_usuarios[i].Nombre)) // Si la lista de nombres contiene algún usuario
                    {
                        usuarios.Add(_usuarios[i]); // Se añade el usuario a la lista usuarios
                    }
                }

                if (usuarios.Count == 0)
                {
                    // Mensaje si no encontramos ningún usuario
                    Console.WriteLine("Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
                Console.WriteLine($"Articulos: {ParseoArticulo(_publicaciones[i].Articulos)}");
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
                Console.WriteLine($"Precio: {articulos[i].Precio}");
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
                Console.WriteLine($"Articulos: {ParseoArticulo(publicaciones[i].Articulos)}");
                ImprimirArticulo(publicaciones[i].Articulos); // Imprime los datos de los articulos asociados
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
        public void AltaArticulo(string nombre, decimal precio, bool imprimir)
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
                    if (imprimir)
                    {
                        Console.WriteLine("El articulo fue registrado correctamente");
                    }
                }
                else
                {
                    throw new Exception("Ya existe un articulo con el mismo nombre");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void AltaPublicacion(string nombre, string estado, DateTime fecha, List<Articulo> articulos, Cliente? cliente, Administrador? administrador, DateTime fechaFin, bool imprimir)
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
                    if (imprimir)
                    {
                        Console.WriteLine("La publicación fue registrada correctamente");
                    }
                }
                else
                {
                    throw new Exception("Ya existe una publicación con el mismo nombre");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void AltaUsuario(string nombre, string apellido, string email, string contrasenia, bool imprimir)
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
                    if (imprimir)
                    {
                        Console.WriteLine("El usuario fue registrado correctamente");
                    }
                }
                else
                {
                    throw new Exception("Ya existe un usuario con el mismo nombre y apellido");
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
            AltaArticulo("Pelota de fútbol", 450, false);
            AltaArticulo("Camiseta deportiva", 1200, false);
            AltaArticulo("Zapatillas running", 3500, false);
            AltaArticulo("Raqueta de tenis", 4200, false);
            AltaArticulo("Balón de baloncesto", 800, false);
            AltaArticulo("Guantes de boxeo", 2200, false);
            AltaArticulo("Casco de ciclismo", 1800, false);
            AltaArticulo("Saco de dormir", 2300, false);
            AltaArticulo("Bolsa de gimnasio", 950, false);
            AltaArticulo("Bicicleta de montaña", 15000, false);
            AltaArticulo("Mochila de trekking", 2100, false);
            AltaArticulo("Protector solar", 320, false);
            AltaArticulo("Botella térmica", 750, false);
            AltaArticulo("Palo de hockey", 1700, false);
            AltaArticulo("Pesas ajustables", 3000, false);
            AltaArticulo("Cinta para correr", 25000, false);
            AltaArticulo("Guantes de arquero", 900, false);
            AltaArticulo("Tabla de surf", 12000, false);
            AltaArticulo("Canilleras", 600, false);
            AltaArticulo("Traje de neopreno", 5400, false);
            AltaArticulo("Gafas de natación", 650, false);
            AltaArticulo("Bola de bowling", 3500, false);
            AltaArticulo("Skateboard", 2400, false);
            AltaArticulo("Patines en línea", 2900, false);
            AltaArticulo("Salvavidas", 1200, false);
            AltaArticulo("Set de pesas", 4200, false);
            AltaArticulo("Cuerda para saltar", 300, false);
            AltaArticulo("Bicicleta de carrera", 18500, false);
            AltaArticulo("Tobilleras con peso", 850, false);
            AltaArticulo("Set de dardos", 400, false);
            AltaArticulo("Bate de béisbol", 1900, false);
            AltaArticulo("Bola de voleibol", 850, false);
            AltaArticulo("Aro de baloncesto", 2700, false);
            AltaArticulo("Zapatilla de ciclismo", 1900, false);
            AltaArticulo("Silla de camping", 1100, false);
            AltaArticulo("Sombrilla", 1600, false);
            AltaArticulo("Tienda de campaña", 8700, false);
            AltaArticulo("Colchoneta de yoga", 1200, false);
            AltaArticulo("Barra de dominadas", 1900, false);
            AltaArticulo("Malla", 600, false);
            AltaArticulo("Reloj deportivo", 6500, false);
            AltaArticulo("Monopatín eléctrico", 18000, false);
            AltaArticulo("Kit de pesca", 3200, false);
            AltaArticulo("Bolsa de golf", 7600, false);
            AltaArticulo("Raqueta de bádminton", 1600, false);
            AltaArticulo("Patineta longboard", 3300, false);
            AltaArticulo("Bola de rugby", 1050, false);
            AltaArticulo("Kit de snorkel", 1800, false);
            AltaArticulo("Camiseta de compresión", 1300, false);
            AltaArticulo("Gorra deportiva", 400, false);
            AltaArticulo("Balón medicinal", 2000, false);
            AltaArticulo("Kit de arquería", 9800, false);
            AltaArticulo("Soga de escalada", 5600, false);
            AltaArticulo("Casco de esquí", 3700, false);
            AltaArticulo("Balde", 1050, false);
            AltaArticulo("Gafas de ciclismo", 900, false);

        }
        public void PrecargarPublicacion()
        {
            AltaPublicacion("Verano en la playa", "ABIERTA", DateTime.ParseExact("05/01/2024", "dd/MM/yyyy", null), ObtenerArticuloPorId(new List<int> { 11, 24, 35, 54 }), null, null, DateTime.MinValue, false);
            AltaPublicacion("Vuelta ciclista", "ABIERTA", DateTime.ParseExact("06/01/2024", "dd/MM/yyyy", null), ObtenerArticuloPorId(new List<int> { 27, 33, 39 }), null, null, DateTime.MinValue, false);
            AltaPublicacion("Set de playa", "ABIERTA", DateTime.ParseExact("13/12/2024", "dd/MM/yyyy", null), ObtenerArticuloPorId(new List<int> { 1, 3, 4 }), null, null, DateTime.MinValue, false);
        }
        public void PrecargaUsuario()
        {
            AltaUsuario("Valentin", "Latorre", "ValentinLatorre@Gmail.com", "Valentin1234", false);
            AltaUsuario("Agustin", "Butrico", "AgustinButrico@gmail.com", "Agustin1234", false);
            AltaUsuario("Juan", "Peres", "Juanperes@hmail.com", "Juan1234", false);
            AltaUsuario("Esteban", "Lopez", "EstebanLopez@hmail.com", "556643", false);
            AltaUsuario("Carlos", "Medina", "CarlosMedina@hmail.com", "Medina1234", false);
            AltaUsuario("Mariano", "Morales", "MarianoMorales@hmail.com", "Mariano2", false);
            AltaUsuario("Estela", "Rosales", "EstelaRosales@hmail.com", "Rosalia46", false);
            AltaUsuario("Marcos", "Sauce", "MarcosSauce@hmail.com", "Sauce31", false);
            AltaUsuario("Lucia", "Gomez", "LuciaGomezs@hmail.com", "Lucia1990", false);
            AltaUsuario("Rodrigo", "Barrios", "RodrigoBarrios@hmail.com", "RodrigoBarrios12", false);
        }
        #endregion
    }
}

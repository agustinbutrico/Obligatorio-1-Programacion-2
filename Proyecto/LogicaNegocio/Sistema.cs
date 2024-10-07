using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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

        /// <summary>
        /// El Parseo de datos sirve para modificar los datos ingresados por el usuario
        /// o modificar datos para mostrarlos al usuario.
        /// La funcion ParseoId permite obtener una lista de Ids a partir de una cadena de texto
        /// La funcion ParseoArticulo permite obtener una cadena de texto a partir de una lista de articulos
        /// </summary>
        #region Parseo Datos
        #region Universal
        // Convierte en una lista de ids el string pasado por parametros
        public List<int> ParseoId(string ids_crudos)
        {
            List<int> lista_ids = new List<int>(); // Crea una lista de los ids ingresados
            string[] ids = ids_crudos.Split(','); // Crea un array de los ids

            for (int i = 0; i < ids.Length; i++) // Recorre todos los elementos de ids
            {
                lista_ids.Add(int.Parse(ids[i].Trim())); // Remueve los espacios, transforma a int y añade a la lista el id
            }
            return lista_ids;
        }
        // Convierte en una lista de nombres el string pasado por parametros
        public List<string> ParseoNombre(string nombres_crudos)
        {
            List<string> lista_nombres = new List<string>(); // Crea una lista de los nombres ingresados
            string[] nombres = nombres_crudos.Split(','); // Crea un array de los nombres

            for (int i = 0; i < nombres.Length; i++) // Recorre todos los elementos de nombres
            {
                lista_nombres.Add(nombres[i].Trim()); // Remueve los espaciosy añade a la lista el nombre
            }
            return lista_nombres;
        }
        #endregion
        #region Articulo
        // Convierte en string los ids de la lista de articulos pasada por parametros
        public string ParseoArticulo(List<Articulo> articulos)
        {
            string ids_articulos = string.Empty;
            for (int i = 0; i < articulos.Count; i++)
            {
                ids_articulos += $"{articulos[i].Id}, ";
            }

            if (articulos.Count > 0)
            {
                // Quitamos la , del final de los ids
                ids_articulos = ids_articulos.Substring(0, ids_articulos.Length - 2);
            }
            return ids_articulos;
        }
        #endregion
        #region Oferta
        // Convierte en string los ids de la lista de ofertas pasada por parametros
        public string ParseoOferta(List<Oferta> ofertas)
        {
            string ids_ofertas = string.Empty;
            for (int i = 0; i < ofertas.Count; i++)
            {
                ids_ofertas += $"{ofertas[i].Id}, ";
            }

            if (ofertas.Count > 0)
            {
                // Quitamos la , del final de los ids
                ids_ofertas = ids_ofertas.Substring(0, ids_ofertas.Length - 2);
            }
            return ids_ofertas;
        }
        #endregion
        #endregion

        /// <summary>
        /// Las lista son utilizadas en todas las funciones de impresión.
        /// Por ejemplo si queremos imprimir clientes, debemos pasarle a la función
        /// imprimirUsuario una lista de clientes.
        /// Esta lista se puede conseguir con:
        /// ObtenerCliente, almacena en una lista todos los usuarios que sean clientes
        /// obtenerClientePorId, almacena en una lista los clientes de ids determinados
        /// obtenerClientePorNombre, almacena en una lista los clientes de nombres determinados
        /// </summary>
        #region Obtención de listas
        #region Articulo
        public List<Articulo> ObtenerArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();  // Inicializamos la lista que contendrá los artículos
            for (int i = 0; i < _articulos.Count; i++)
            {
                articulos.Add(_articulos[i]); // Se añade cualquier artículo a la lista artículos
            }

            if (articulos.Count == 0)
            {
                // Mensaje si no encontramos ningún artículo
                Console.WriteLine("Articulo no encontrado");
            } 
            return articulos;
        }
        public List<Articulo> ObtenerArticuloPorId(List<int> ids)
        {
            List<Articulo> articulos = new List<Articulo>();  // Inicializamos la lista que contendrá los artículos
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
            return articulos;
        }
        public List<Articulo> ObtenerArticuloPorNombre(List<string> nombres)
        {
            List<Articulo> articulos = new List<Articulo>();  // Inicializamos la lista que contendrá los artículos
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
            return articulos;
        }
        #endregion
        #region Publicacion
        public List<Publicacion> ObtenerPublicaciones(bool esUnicamenteVenta, bool esUnicamenteSubasta)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();  // Inicializamos la lista que contendrá las publicaciones
            for (int i = 0; i < _publicaciones.Count; i++)
            {
                if (!esUnicamenteVenta && !esUnicamenteSubasta)
                {
                    publicaciones.Add(_publicaciones[i]); // Se añade cualquier publicacion a la lista publicaciones
                }
                else if (_publicaciones[i] is Venta venta && esUnicamenteVenta)
                {
                    publicaciones.Add(venta); // Se añade la venta a la lista publicaciones
                }
                else if (_publicaciones[i] is Subasta subasta && esUnicamenteSubasta)
                {
                    publicaciones.Add(subasta); // Se añade la subasta a la lista publicaciones
                }
            }

            if (publicaciones.Count == 0)
            {
                // Mensaje si no encontramos ninguna publicación
                Console.WriteLine("Publicación no encontrada");
            }
            return publicaciones;
        }
        public List<Publicacion> ObtenerPublicacionPorId(List<int> ids, bool esUnicamenteVenta, bool esUnicamenteSubasta)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();  // Inicializamos la lista que contendrá las publicaciones
            for (int i = 0; i < _publicaciones.Count; i++)
            {
                if (ids.Contains(_publicaciones[i].Id)) // Si la lista de ids contiene algúna publicacion
                {
                    if (!esUnicamenteVenta && !esUnicamenteSubasta)
                    {
                        publicaciones.Add(_publicaciones[i]); // Se añade la publicacion a la lista publicaciones
                    }
                    else if (_publicaciones[i] is Venta venta && esUnicamenteVenta)
                    {
                        publicaciones.Add(venta); // Se añade la venta a la lista publicaciones
                    }
                    else if (_publicaciones[i] is Subasta subasta && esUnicamenteSubasta)
                    {
                        publicaciones.Add(subasta); // Se añade la subasta a la lista publicaciones
                    }
                }
            }

            if (publicaciones.Count == 0)
            {
                // Mensaje si no encontramos ninguna publicación
                Console.WriteLine("Publicación no encontrada");
            }
            return publicaciones;
        }
        public List<Publicacion> ObtenerPublicacionPorNombre(List<string> nombres, bool esUnicamenteVenta, bool esUnicamenteSubasta)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();  // Inicializamos la lista que contendrá las publicaciones
            for (int i = 0; i < _publicaciones.Count; i++)
            {
                if (nombres.Contains(_publicaciones[i].Nombre)) // Si la lista de nombres contiene algúna publicación
                {
                    if (!esUnicamenteVenta && !esUnicamenteSubasta)
                    {
                        publicaciones.Add(_publicaciones[i]); // Se añade la publicacion a la lista publicaciones
                    }
                    else if (_publicaciones[i] is Venta venta && esUnicamenteVenta)
                    {
                        publicaciones.Add(venta); // Se añade la venta a la lista publicaciones
                    }
                    else if (_publicaciones[i] is Subasta subasta && esUnicamenteSubasta)
                    {
                        publicaciones.Add(subasta); // Se añade la subasta a la lista publicaciones
                    }
                }
            }

            if (publicaciones.Count == 0)
            {
                // Mensaje si no encontramos ningúna publicacion
                Console.WriteLine("Publicacion no encontrada");
            }
            return publicaciones;
        }
        #endregion
        #region Usuario
        public List<Usuario> ObtenerUsuarios(bool esUnicamenteCliente, bool esUnicamenteAdministrador)
        {
            List<Usuario> usuarios = new List<Usuario>();  // Inicializamos la lista que contendrá los usuarios
            for (int i = 0; i < _usuarios.Count; i++)
            {
                if (!esUnicamenteCliente && !esUnicamenteAdministrador)
                {
                    usuarios.Add(_usuarios[i]); // Se añade el usuario a la lista usuarios
                }
                else if (_usuarios[i] is Cliente cliente && esUnicamenteCliente)
                {
                    usuarios.Add(cliente); // Se añade el cliente a la lista usuarios
                }
                else if (_usuarios[i] is Administrador administrador && esUnicamenteAdministrador)
                {
                    usuarios.Add(administrador); // Se añade el administrador a la lista usuarios
                }
            }

            if (usuarios.Count == 0)
            {
                // Mensaje si no encontramos ningún usuario
                Console.WriteLine("Usuario no encontrado");
            }
            return usuarios;
        }
        public List<Usuario> ObtenerUsuarioPorId(List<int> ids, bool esUnicamenteCliente, bool esUnicamenteAdministrador)
        {
            List<Usuario> usuarios = new List<Usuario>();  // Inicializamos la lista que contendrá los usuarios
            for (int i = 0; i < _usuarios.Count; i++)
            {
                if (ids.Contains(_usuarios[i].Id)) // Si la lista de ids contiene algún usuario
                {
                    if (!esUnicamenteCliente && !esUnicamenteAdministrador)
                    {
                        usuarios.Add(_usuarios[i]); // Se añade el usuario a la lista usuarios
                    }
                    else if (_usuarios[i] is Cliente cliente && esUnicamenteCliente)
                    {
                        usuarios.Add(cliente); // Se añade el cliente a la lista usuarios
                    }
                    else if (_usuarios[i] is Administrador administrador && esUnicamenteAdministrador)
                    {
                        usuarios.Add(administrador); // Se añade el administrador a la lista usuarios
                    }
                }
            }

            if (usuarios.Count == 0)
            {
                // Mensaje si no encontramos ningún usuario
                Console.WriteLine("Usuario no encontrado");
            }
            return usuarios;
        }
        public List<Usuario> ObtenerUsuarioPorNombre(List<string> nombres, bool esUnicamenteCliente, bool esUnicamenteAdministrador)
        {
            List<Usuario> usuarios = new List<Usuario>();  // Inicializamos la lista que contendrá los usuarios
            for (int i = 0; i < _usuarios.Count; i++)
            {
                if (nombres.Contains(_usuarios[i].Nombre)) // Si la lista de nombres contiene algún usuario
                {
                    if (!esUnicamenteCliente && !esUnicamenteAdministrador)
                    {
                        usuarios.Add(_usuarios[i]); // Se añade el usuario a la lista usuarios
                    }
                    else if (_usuarios[i] is Cliente cliente && esUnicamenteCliente)
                    {
                        usuarios.Add(cliente); // Se añade el cliente a la lista usuarios
                    }
                    else if (_usuarios[i] is Administrador administrador && esUnicamenteAdministrador)
                    {
                        usuarios.Add(administrador); // Se añade el administrador a la lista usuarios
                    }
                }
            }

            if (usuarios.Count == 0)
            {
                // Mensaje si no encontramos ningún usuario
                Console.WriteLine("Usuario no encontrado");
            }
            return usuarios;
        }
        #endregion
        #endregion
        
        /// <summary>
        /// Las funciones de impresión son las menores posibles para evitar diferencias en la impresion.
        /// Estas imprimen los datos basandose en listas de datos.
        /// Tambien tienen booleanos como margenesGrandes o vistaResumida que sirven para facilitar
        /// la lectura de los datos por parte del usuario al utilizar el programa
        /// </summary>
        #region Impresion de listas
        #region Articulo
        public void ImprimirArticulo(List<Articulo> articulos, bool margenesGrandes)
        {
            for (int i = 0; i < articulos.Count; i++)
            {
                if (margenesGrandes)
                {
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------");
                }
                // Mostramos los detalles del Artículo
                Console.WriteLine($"ID: {articulos[i].Id}");
                Console.WriteLine($"Nombre: {articulos[i].Nombre}");
                Console.WriteLine($"Precio: {articulos[i].Precio}");
            }
            if (margenesGrandes)
            {
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine("------------------");
            }
        }
        #endregion
        #region Publicacion
        public void ImprimirPublicacion(List<Publicacion> publicaciones, bool margenesGrandes, bool vistaResumida)
        {
            for (int i = 0; i < publicaciones.Count; i++)
            {
                if (margenesGrandes)
                {
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------");
                }
                // Mostramos los detalles de las publicaciones
                Console.WriteLine($"ID: {publicaciones[i].Id}");
                Console.WriteLine($"Nombre: {publicaciones[i].Nombre}");
                Console.WriteLine($"Estado: {publicaciones[i].Estado}");
                Console.WriteLine($"Fecha: {publicaciones[i].Fecha}");
                Console.WriteLine($"Articulos: {ParseoArticulo(publicaciones[i].Articulos)}");
                if (!vistaResumida)
                {
                    ImprimirArticulo(publicaciones[i].Articulos, false); // Imprime los datos de los articulos asociados
                }
                Console.WriteLine($"Cliente: {publicaciones[i].Cliente}");
                Console.WriteLine($"Administrador: {publicaciones[i].Administrador}");
                Console.WriteLine($"Fecha Fin: {publicaciones[i].FechaFin}");
                if (_publicaciones[i] is Venta venta)
                {
                    Console.WriteLine($"Oferta relampago: {venta.OfertaRelampago}");
                }
                if (_publicaciones[i] is Subasta subasta)
                {
                    Console.WriteLine($"Ofertas: {ParseoOferta(subasta.Ofertas)}");
                    if (!vistaResumida)
                    {
                        ImprimirOferta(subasta.Ofertas, false); // Imprime los datos de las ofertas asociadas
                    }
                }
            }
            if (margenesGrandes)
            {
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine("------------------");
            }
        }
        #endregion
        #region Usuario
        public void ImprimirUsuario(List<Usuario> usuarios, bool margenesGrandes)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (margenesGrandes)
                {
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------");
                }
                // Mostramos los detalles del Usuario
                Console.WriteLine($"ID: {usuarios[i].Id}");
                Console.WriteLine($"Nombre: {usuarios[i].Nombre}");
                Console.WriteLine($"Apellido: {usuarios[i].Apellido}");
                Console.WriteLine($"Email: {usuarios[i].Email}");
                if (usuarios[i] is Cliente cliente)
                {
                    Console.WriteLine($"Saldo: {cliente.Saldo}");
                }
            }
            if (margenesGrandes)
            {
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine("------------------");
            }
        }
        #endregion
        #region Oferta
        public void ImprimirOferta(List<Oferta> ofertas, bool margenesGrandes)
        {
            for (int i = 0; i < ofertas.Count; i++)
            {
                if (margenesGrandes)
                {
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------");
                }
                // Mostramos los detalles de las ofertas
                Console.WriteLine($"ID: {ofertas[i].Id}");
                Console.WriteLine($"Usuario: {ofertas[i].Usuario}");
                Console.WriteLine($"Monto: {ofertas[i].Monto}");
                Console.WriteLine($"Fecha: {ofertas[i].Fecha}");
            }
            if (margenesGrandes)
            {
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine("------------------");
            }
        }
        #endregion
        #endregion
        
        /// <summary>
        /// Las funciones de alta se encargan de llamar a los constructores de las
        /// diferentes clases y pasar los parametros obtenidos en Program.
        /// </summary>
        #region Altas
        #region Articulo
        public void AltaArticulo(string nombre, decimal precio)
        {
            Articulo nuevoArticulo = new Articulo(nombre, precio);
            // Validación de la relacion entre los datos ingresados
            nuevoArticulo.Validar();
            // Si los datos son validos entonces se registra el Articulo
            if (!_articulos.Contains(nuevoArticulo))
            {
                _articulos.Add(nuevoArticulo);
            }
        }
        #endregion
        #region Publicacion
        public void AltaPublicacion(string nombre, string estado, DateTime fecha, List<Articulo> articulos, Cliente? cliente, Administrador? administrador, DateTime fechaFin)
        {
            Publicacion nuevaPublicacion = new Publicacion(nombre, estado, fecha, articulos, cliente, administrador, fechaFin);
            // Validación de la relacion entre los datos ingresados
            nuevaPublicacion.Validar();
            // Si los datos son validos entonces se registra la Publicación
            if (!_publicaciones.Contains(nuevaPublicacion))
            {
                _publicaciones.Add(nuevaPublicacion);
            }
        }
        public void AltaVenta(string nombre, string estado, DateTime fecha, List<Articulo> articulos, Cliente? cliente, Administrador? administrador, DateTime fechaFin, bool ofertaRelampago)
        {
            Venta nuevaVenta = new Venta(nombre, estado, fecha, articulos, cliente, administrador, fechaFin, ofertaRelampago);
            // Validación de la relacion entre los datos ingresados
            nuevaVenta.Validar();
            // Si los datos son validos entonces se registra la Venta
            if (!_publicaciones.Contains(nuevaVenta))
            {
                _publicaciones.Add(nuevaVenta);
            }
        }
        public void AltaSubasta(string nombre, string estado, DateTime fecha, List<Articulo> articulos, Cliente? cliente, Administrador? administrador, DateTime fechaFin, List<Oferta> ofertas)
        {
            Subasta nuevaSubasta = new Subasta(nombre, estado, fecha, articulos, cliente, administrador, fechaFin, ofertas);
            // Validación de la relacion entre los datos ingresados
            nuevaSubasta.Validar();
            // Si los datos son validos entonces se registra la Subasta
            if (!_publicaciones.Contains(nuevaSubasta))
            {
                _publicaciones.Add(nuevaSubasta);

            }
        }
        #endregion
        #region Usuario
        public void AltaUsuario(string nombre, string apellido, string email, string contrasenia)
        {
            Usuario nuevoUsuario = new Usuario(nombre, apellido, email, contrasenia);
            // Validación de la relacion entre los datos ingresados
            nuevoUsuario.Validar();
            // Si los datos son validos entonces se registra el Usuario
            if (!_usuarios.Contains(nuevoUsuario))
            {
                _usuarios.Add(nuevoUsuario);
            }
        }
        public void AltaCliente(string nombre, string apellido, string email, string contrasenia, decimal saldo)
        {
            Cliente nuevoCliente = new Cliente(nombre, apellido, email, contrasenia, saldo);
            // Validación de la relacion entre los datos ingresados
            nuevoCliente.Validar();
            // Si los datos son validos entonces se registra el Cliente
            if (!_usuarios.Contains(nuevoCliente))
            {
                _usuarios.Add(nuevoCliente);
            }
        }
        public void AltaAdministrador(string nombre, string apellido, string email, string contrasenia)
        {
            Administrador nuevoAdministrador = new Administrador(nombre, apellido, email, contrasenia);
            // Validación de la relacion entre los datos ingresados
            nuevoAdministrador.Validar();
            // Si los datos son validos entonces se registra el Administrador
            if (!_usuarios.Contains(nuevoAdministrador))
            {
                _usuarios.Add(nuevoAdministrador);
            }
        }
        #endregion
        #endregion
        
        /// <summary>
        /// Las funciones de consulta tienen el objetivo de obtener datos calculados.
        /// Por ejemplo ConsultarPrecioVentaDeListaVenta obtiene los precios de las ventas buscadas.
        /// Este es un dato calculado ya que es necesario acceder a la venta y sumar el precio de todos sus articulos.
        /// </summary>
        #region Consultas
        public List<decimal> ConsultarPrecioVentaDeListaVenta(List<Publicacion> ventas)
        {
            List<decimal> precio = new List<decimal>();
            for (int i = 0; i < ventas.Count; i++)
            {
                // Accede a la venta en especifico
                if (ventas[i] is Venta venta)
                {
                    // Recorre la lista de articulos de la venta en especifico y suma su precio al total
                    for (int j = 0; j < venta.Articulos.Count; j++)
                    {
                        precio[i] += venta.Articulos[j].Precio;
                    }
                    // Una vez sumado los precios de todos los articulos
                    // se aplica descuento si corresponde a la venta en especifico
                    if (venta.OfertaRelampago)
                    {
                        precio[i] = precio[i] * 80 / 100;
                    }
                }
            }
            return precio;
        }
        #endregion

        /// <summary>
        /// Las precargas son relizadas a travez de las funciones de alta,
        /// esto se hace de este modo para que el id autoincremental se asigne correctamente
        /// </summary>
        #region Precargas
        #region Articulo
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
            AltaArticulo("Protector solar", 320);
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
            AltaArticulo("Salvavidas", 1200);
            AltaArticulo("Set de pesas", 4200);
            AltaArticulo("Cuerda para saltar", 300);
            AltaArticulo("Bicicleta de carrera", 18500);
            AltaArticulo("Tobilleras con peso", 850);
            AltaArticulo("Set de dardos", 400);
            AltaArticulo("Bate de béisbol", 1900);
            AltaArticulo("Bola de voleibol", 850);
            AltaArticulo("Aro de baloncesto", 2700);
            AltaArticulo("Zapatilla de ciclismo", 1900);
            AltaArticulo("Silla de camping", 1100);
            AltaArticulo("Sombrilla", 1600);
            AltaArticulo("Tienda de campaña", 8700);
            AltaArticulo("Colchoneta de yoga", 1200);
            AltaArticulo("Barra de dominadas", 1900);
            AltaArticulo("Malla", 600);
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
            AltaArticulo("Balde", 1050);
            AltaArticulo("Gafas de ciclismo", 900);
        }
        #endregion
        #region Publicacion
        public void PrecargarPublicacion()
        {
            AltaVenta("Verano en la playa", "ABIERTA", DateTime.ParseExact("05/01/2024", "dd/MM/yyyy", null), ObtenerArticuloPorId(new List<int> { 11, 24, 35, 54 }), null, null, DateTime.MinValue, false);
            AltaSubasta("Vuelta ciclista", "ABIERTA", DateTime.ParseExact("06/01/2024", "dd/MM/yyyy", null), ObtenerArticuloPorId(new List<int> { 27, 33, 39 }), null, null, DateTime.MinValue, new List<Oferta>());
            AltaVenta("Set de playa", "ABIERTA", DateTime.ParseExact("13/12/2024", "dd/MM/yyyy", null), ObtenerArticuloPorId(new List<int> { 1, 3, 4 }), null, null, DateTime.MinValue, false);
        }
        #endregion
        #region Usuario
        public void PrecargaUsuario()
        {
            AltaAdministrador("Valentin", "Latorre", "ValentinLatorre@Gmail.com", "Valentin1234");
            AltaAdministrador("Agustin", "Butrico", "AgustinButrico@gmail.com", "Agustin1234");
            AltaCliente("Juan", "Peres", "Juanperes@hmail.com", "Juan1234", 2000);
            AltaCliente("Esteban", "Lopez", "EstebanLopez@hmail.com", "556643", 2000);
            AltaCliente("Carlos", "Medina", "CarlosMedina@hmail.com", "Medina1234", 4500);
            AltaCliente("Mariano", "Morales", "MarianoMorales@hmail.com", "Mariano2", 5000);
            AltaCliente("Estela", "Rosales", "EstelaRosales@hmail.com", "Rosalia46", 300);
            AltaCliente("Marcos", "Sauce", "MarcosSauce@hmail.com", "Sauce31", 30000);
            AltaCliente("Lucia", "Gomez", "LuciaGomezs@hmail.com", "Lucia1990", 7200);
            AltaCliente("Rodrigo", "Barrios", "RodrigoBarrios@hmail.com", "RodrigoBarrios12", 900);
        }
        #endregion
        #endregion
    }
}

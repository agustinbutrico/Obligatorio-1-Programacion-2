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
        #region Universal
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
        #endregion
        #region Articulo
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
        #region Oferta
        // Convierte en string los ids de la lista de ofertas pasada por parametros
        public string ParseoOferta(List<Oferta> ofertas)
        {
            string ids_ofertas = string.Empty;
            try
            {
                for (int i = 0; i < ofertas.Count; i++)
                {
                    ids_ofertas += $"{ofertas[i].Id}, ";
                }

                if (ofertas.Count > 0)
                {
                    // Quitamos la , del final de los ids
                    ids_ofertas = ids_ofertas.Substring(0, ids_ofertas.Length - 2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return ids_ofertas;
        }
        #endregion
        #endregion

        #region Obtención de listas
        #region Articulo
        public List<Articulo> ObtenerArticuloPorId(List<int> ids)
        {
            List<Articulo> articulos = new List<Articulo>();  // Inicializamos la lista que contendrá los artículos
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
        public List<Articulo> ObtenerArticuloPorNombre(List<string> nombres)
        {
            List<Articulo> articulos = new List<Articulo>();  // Inicializamos la lista que contendrá los artículos
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
        #endregion
        #region Publicacion
        public List<Publicacion> ObtenerPublicacionPorId(List<int> ids, bool buscarTodas)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();  // Inicializamos la lista que contendrá las publicaciones
            try
            {
                for (int i = 0; i < _publicaciones.Count; i++)
                {
                    if (ids.Contains(_publicaciones[i].Id) || buscarTodas) // Si la lista de ids contiene algúna publicacion
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
        public List<Publicacion> ObtenerPublicacionPorNombre(List<string> nombres, bool buscarTodas)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();  // Inicializamos la lista que contendrá las publicaciones
            try
            {
                for (int i = 0; i < _publicaciones.Count; i++)
                {
                    if (nombres.Contains(_publicaciones[i].Nombre) || buscarTodas) // Si la lista de nombres contiene algúna publicación
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
        public List<Publicacion> ObtenerVentaPorId(List<int> ids, bool buscarTodas)
        {
            List<Publicacion> ventas = new List<Publicacion>();  // Inicializamos la lista que contendrá las ventas
            try
            {
                for (int i = 0; i < _publicaciones.Count; i++)
                {
                    if (_publicaciones[i] is Venta venta)
                    {
                        if (ids.Contains(venta.Id) || buscarTodas) // Si la lista de ids contiene algúna venta
                        {
                            ventas.Add(venta); // Se añade la venta a la lista ventas
                        }
                    }
                }

                if (ventas.Count == 0)
                {
                    // Mensaje si no encontramos ninguna venta
                    Console.WriteLine("Venta no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return ventas;
        }
        public List<Publicacion> ObtenerVentaPorNombre(List<string> nombres, bool buscarTodas)
        {
            List<Publicacion> ventas = new List<Publicacion>();  // Inicializamos la lista que contendrá las ventas
            try
            {
                for (int i = 0; i < _publicaciones.Count; i++)
                {
                    if (_publicaciones[i] is Venta venta)
                    {
                        if (nombres.Contains(venta.Nombre) || buscarTodas) // Si la lista de nombres contiene algúna venta
                        {
                            ventas.Add(venta); // Se añade la venta a la lista ventas
                        }
                    }
                }

                if (ventas.Count == 0)
                {
                    // Mensaje si no encontramos ningúna venta
                    Console.WriteLine("Venta no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return ventas;
        }
        public List<Publicacion> ObtenerSubastaPorId(List<int> ids, bool buscarTodas)
        {
            List<Publicacion> subastas = new List<Publicacion>();  // Inicializamos la lista que contendrá las subastas
            try
            {
                for (int i = 0; i < _publicaciones.Count; i++)
                {
                    if (_publicaciones[i] is Subasta subasta)
                    {
                        if (ids.Contains(subasta.Id) || buscarTodas) // Si la lista de ids contiene algúna subasta
                        {
                            subastas.Add(subasta); // Se añade la subasta a la lista subastas
                        }
                    }
                }

                if (subastas.Count == 0)
                {
                    // Mensaje si no encontramos ninguna subasta
                    Console.WriteLine("Subasta no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return subastas;
        }
        public List<Publicacion> ObtenerSubastaPorNombre(List<string> nombres, bool buscarTodas)
        {
            List<Publicacion> subastas = new List<Publicacion>();  // Inicializamos la lista que contendrá las subastas
            try
            {
                for (int i = 0; i < _publicaciones.Count; i++)
                {
                    if (_publicaciones[i] is Subasta subasta)
                    {
                        if (nombres.Contains(subasta.Nombre) || buscarTodas) // Si la lista de nombres contiene algúna subasta
                        {
                            subastas.Add(subasta); // Se añade la subasta a la lista subastas
                        }
                    }
                }

                if (subastas.Count == 0)
                {
                    // Mensaje si no encontramos ningúna subasta
                    Console.WriteLine("Subasta no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return subastas;
        }
        #endregion
        #region Usuario
        public List<Usuario> ObtenerUsuarioPorId(List<int> ids, bool buscarTodos)
        {
            List<Usuario> usuarios = new List<Usuario>();  // Inicializamos la lista que contendrá los usuarios
            try
            {
                for (int i = 0; i < _usuarios.Count; i++)
                {
                    if (ids.Contains(_usuarios[i].Id) || buscarTodos) // Si la lista de ids contiene algún usuario
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
        public List<Usuario> ObtenerUsuarioPorNombre(List<string> nombres, bool buscarTodos)
        {
            List<Usuario> usuarios = new List<Usuario>();  // Inicializamos la lista que contendrá los usuarios
            try
            {
                for (int i = 0; i < _usuarios.Count; i++)
                {
                    if (nombres.Contains(_usuarios[i].Nombre) || buscarTodos) // Si la lista de nombres contiene algún usuario
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
        public List<Usuario> ObtenerClientePorId(List<int> ids, bool buscarTodos)
        {
            List<Usuario> clientes = new List<Usuario>();  // Inicializamos la lista que contendrá los clientes
            try
            {
                for (int i = 0; i < _usuarios.Count; i++)
                {
                    if (_usuarios[i] is Cliente cliente)
                    {
                        if (ids.Contains(cliente.Id) || buscarTodos) // Si la lista de ids contiene algún cliente
                        {
                            clientes.Add(cliente); // Se añade el cliente a la lista clientes
                        }
                    }
                }

                if (clientes.Count == 0)
                {
                    // Mensaje si no encontramos ningún cliente
                    Console.WriteLine("Cliente no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return clientes;
        }
        public List<Usuario> ObtenerClientePorNombre(List<string> nombres, bool buscarTodos)
        {
            List<Usuario> clientes = new List<Usuario>();  // Inicializamos la lista que contendrá los clientes
            try
            {
                for (int i = 0; i < _usuarios.Count; i++)
                {
                    if (_usuarios[i] is Cliente cliente)
                    {
                        if (nombres.Contains(cliente.Nombre) || buscarTodos) // Si la lista de nombres contiene algún cliente
                        {
                            clientes.Add(cliente); // Se añade el cliente a la lista clientes
                        }
                    }
                }

                if (clientes.Count == 0)
                {
                    // Mensaje si no encontramos ningún cliente
                    Console.WriteLine("Cliente no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return clientes;
        }
        public List<Usuario> ObtenerAdministradorPorId(List<int> ids, bool buscarTodos)
        {
            List<Usuario> administradores = new List<Usuario>();  // Inicializamos la lista que contendrá los administradores
            try
            {
                for (int i = 0; i < _usuarios.Count; i++)
                {
                    if (_usuarios[i] is Administrador administrador)
                    {
                        if (ids.Contains(administrador.Id) || buscarTodos) // Si la lista de ids contiene algún administrador
                        {
                            administradores.Add(administrador); // Se añade el administrador a la lista administradores
                        }
                    }
                }

                if (administradores.Count == 0)
                {
                    // Mensaje si no encontramos ningún administrador
                    Console.WriteLine("Administrador no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return administradores;
        }
        public List<Usuario> ObtenerAdministradorPorNombre(List<string> nombres, bool buscarTodos)
        {
            List<Usuario> administradores = new List<Usuario>();  // Inicializamos la lista que contendrá los administradores
            try
            {
                for (int i = 0; i < _usuarios.Count; i++)
                {
                    if (_usuarios[i] is Administrador administrador)
                    {
                        if (nombres.Contains(administrador.Nombre) || buscarTodos) // Si la lista de nombres contiene algún administrador
                        {
                            administradores.Add(administrador); // Se añade el administrador a la lista administradores
                        }
                    }
                }

                if (administradores.Count == 0)
                {
                    // Mensaje si no encontramos ningún administrador
                    Console.WriteLine("Administrador no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return administradores;
        }
        #endregion
        #endregion

        #region Impresion de listas
        #region Articulo
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
                if (_publicaciones[i] is Venta venta)
                {
                    Console.WriteLine($"Oferta relampago: {venta.OfertaRelampago}");
                }
                if (_publicaciones[i] is Subasta subasta)
                {
                    Console.WriteLine($"Ofertas:");
                }
            }
            Console.WriteLine("-------------------------------------");
        }
        public void ImprimirPublicacion(List<Publicacion> publicaciones, bool margenesGrandes)
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
                ImprimirArticulo(publicaciones[i].Articulos, false); // Imprime los datos de los articulos asociados
                Console.WriteLine($"Cliente: {publicaciones[i].Cliente}");
                Console.WriteLine($"Administrador: {publicaciones[i].Administrador}");
                Console.WriteLine($"Fecha Fin: {publicaciones[i].FechaFin}");
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
        public void ImprimirVenta()
        {
            bool hayVenta = false;
            for (int i = 0; i < _publicaciones.Count; i++)
            {
                if (_publicaciones[i] is Venta venta)
                {
                    hayVenta = true;
                    // Mostramos los detalles de las ventas
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"ID: {venta.Id}");
                    Console.WriteLine($"Nombre: {venta.Nombre}");
                    Console.WriteLine($"Estado: {venta.Estado}");
                    Console.WriteLine($"Fecha: {venta.Fecha}");
                    Console.WriteLine($"Articulos: {ParseoArticulo(venta.Articulos)}");
                    Console.WriteLine($"Cliente: {venta.Cliente}");
                    Console.WriteLine($"Administrador: {venta.Administrador}");
                    Console.WriteLine($"Fecha Fin: {venta.FechaFin}");
                    Console.WriteLine($"Oferta relampago: {venta.OfertaRelampago}");
                }
            }
            if (hayVenta)
            {
                Console.WriteLine("-------------------------------------");
            }
        }
        public void ImprimirVenta(List<Publicacion> publicaciones, bool margenesGrandes)
        {
            bool hayVenta = false;
            for (int i = 0; i < publicaciones.Count; i++)
            {
                if (publicaciones[i] is Venta venta)
                {
                    hayVenta = true;
                    if (margenesGrandes)
                    {
                        Console.WriteLine("-------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------");
                    }
                    // Mostramos los detalles de las ventas
                    Console.WriteLine($"ID: {venta.Id}");
                    Console.WriteLine($"Nombre: {venta.Nombre}");
                    Console.WriteLine($"Estado: {venta.Estado}");
                    Console.WriteLine($"Fecha: {venta.Fecha}");
                    Console.WriteLine($"Articulos: {ParseoArticulo(venta.Articulos)}");
                    ImprimirArticulo(venta.Articulos, false); // Imprime los datos de los articulos asociados
                    Console.WriteLine($"Cliente: {venta.Cliente}");
                    Console.WriteLine($"Administrador: {venta.Administrador}");
                    Console.WriteLine($"Fecha Fin: {venta.FechaFin}");
                    Console.WriteLine($"Oferta relampago: {venta.OfertaRelampago}");
                }
            }
            if (hayVenta)
            {
                if (margenesGrandes)
                {
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------");
                }
            }
        }
        public void ImprimirSubasta()
        {
            bool haySubasta = false;
            for (int i = 0; i < _publicaciones.Count; i++)
            {
                if (_publicaciones[i] is Subasta subasta)
                {
                    haySubasta = true;
                    // Mostramos los detalles de las ventas
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"ID: {subasta.Id}");
                    Console.WriteLine($"Nombre: {subasta.Nombre}");
                    Console.WriteLine($"Estado: {subasta.Estado}");
                    Console.WriteLine($"Fecha: {subasta.Fecha}");
                    Console.WriteLine($"Articulos: {ParseoArticulo(subasta.Articulos)}");
                    Console.WriteLine($"Cliente: {subasta.Cliente}");
                    Console.WriteLine($"Administrador: {subasta.Administrador}");
                    Console.WriteLine($"Fecha Fin: {subasta.FechaFin}");
                    Console.WriteLine($"Ofertas: {ParseoOferta(subasta.Ofertas)}");
                }
            }
            if (haySubasta)
            {
                Console.WriteLine("-------------------------------------");
            }
        }
        public void ImprimirSubasta(List<Publicacion> publicaciones, bool margenesGrandes)
        {
            bool haySubasta = false;
            for (int i = 0; i < publicaciones.Count; i++)
            {
                if (publicaciones[i] is Subasta subasta)
                {
                    haySubasta = true;
                    if (margenesGrandes)
                    {
                        Console.WriteLine("-------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------");
                    }
                    // Mostramos los detalles de las ventas
                    Console.WriteLine($"ID: {subasta.Id}");
                    Console.WriteLine($"Nombre: {subasta.Nombre}");
                    Console.WriteLine($"Estado: {subasta.Estado}");
                    Console.WriteLine($"Fecha: {subasta.Fecha}");
                    Console.WriteLine($"Articulos: {ParseoArticulo(subasta.Articulos)}");
                    ImprimirArticulo(subasta.Articulos, false); // Imprime los datos de los articulos asociados
                    Console.WriteLine($"Cliente: {subasta.Cliente}");
                    Console.WriteLine($"Administrador: {subasta.Administrador}");
                    Console.WriteLine($"Fecha Fin: {subasta.FechaFin}");
                    Console.WriteLine($"Ofertas: {ParseoOferta(subasta.Ofertas)}");
                    ImprimirOferta(subasta.Ofertas, false); // Imprime los datos de las ofertas asociadas
                }
            }
            if (haySubasta)
            {
                if (margenesGrandes)
                {
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------");
                }
            }
        }
        #endregion
        #region Usuario
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
        public void ImprimirCliente()
        {
            bool hayCliente = false;
            for (int i = 0; i < _usuarios.Count; i++)
            {
                if (_usuarios[i] is Cliente cliente)
                {
                    hayCliente = true;
                    // Mostramos los detalles de los usuarios
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"ID: {cliente.Id}");
                    Console.WriteLine($"Nombre: {cliente.Nombre}");
                    Console.WriteLine($"Apellido: {cliente.Apellido}");
                    Console.WriteLine($"Email: {cliente.Email}");
                    Console.WriteLine($"Saldo: {cliente.Saldo}");
                }
            }
            if (hayCliente)
            {
                Console.WriteLine("-------------------------------------");
            }
        }
        public void ImprimirCliente(List<Usuario> usuarios, bool margenesGrandes)
        {
            bool hayCliente = false;
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i] is Cliente cliente)
                {
                    hayCliente = true;
                    if (margenesGrandes)
                    {
                        Console.WriteLine("-------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------");
                    }
                    // Mostramos los detalles de los usuarios
                    Console.WriteLine($"ID: {cliente.Id}");
                    Console.WriteLine($"Nombre: {cliente.Nombre}");
                    Console.WriteLine($"Apellido: {cliente.Apellido}");
                    Console.WriteLine($"Email: {cliente.Email}");
                    Console.WriteLine($"Saldo: {cliente.Saldo}");
                }
            }
            if (hayCliente)
            {
                if (margenesGrandes)
                {
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------");
                }
            }
        }
        public void ImprimirAdministrador()
        {
            bool hayAdministrador = false;
            for (int i = 0; i < _usuarios.Count; i++)
            {
                if (_usuarios[i] is Administrador administrador)
                {
                    hayAdministrador = true;
                    // Mostramos los detalles de los usuarios
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"ID: {administrador.Id}");
                    Console.WriteLine($"Nombre: {administrador.Nombre}");
                    Console.WriteLine($"Apellido: {administrador.Apellido}");
                    Console.WriteLine($"Email: {administrador.Email}");
                }
            }
            if (hayAdministrador)
            {
                Console.WriteLine("-------------------------------------");
            }
        }
        public void ImprimirAdministrador(List<Usuario> usuarios, bool margenesGrandes)
        {
            bool hayAdministrador = false;
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i] is Administrador administrador)
                {
                    hayAdministrador = true;
                    if (margenesGrandes)
                    {
                        Console.WriteLine("-------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------");
                    }
                    // Mostramos los detalles de los usuarios
                    Console.WriteLine($"ID: {administrador.Id}");
                    Console.WriteLine($"Nombre: {administrador.Nombre}");
                    Console.WriteLine($"Apellido: {administrador.Apellido}");
                    Console.WriteLine($"Email: {administrador.Email}");
                }
            }
            if (hayAdministrador)
            {
                if (margenesGrandes)
                {
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------");
                }
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

        #region Altas
        #region Articulo
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
        #endregion
        #region Publicacion
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
        public void AltaVenta(string nombre, string estado, DateTime fecha, List<Articulo> articulos, Cliente? cliente, Administrador? administrador, DateTime fechaFin, bool ofertaRelampago, bool imprimir)
        {
            try
            {
                Venta nuevaVenta = new Venta(nombre, estado, fecha, articulos, cliente, administrador, fechaFin, ofertaRelampago);
                // Validación de la relacion entre los datos ingresados
                nuevaVenta.Validar();
                // Si los datos son validos entonces se registra la Venta
                if (!_publicaciones.Contains(nuevaVenta))
                {
                    _publicaciones.Add(nuevaVenta);
                    if (imprimir)
                    {
                        Console.WriteLine("La venta fue registrada correctamente");
                    }
                }
                else
                {
                    throw new Exception("Ya existe una venta con el mismo nombre");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void AltaSubasta(string nombre, string estado, DateTime fecha, List<Articulo> articulos, Cliente? cliente, Administrador? administrador, DateTime fechaFin, List<Oferta> ofertas, bool imprimir)
        {
            try
            {
                Subasta nuevaSubasta = new Subasta(nombre, estado, fecha, articulos, cliente, administrador, fechaFin, ofertas);
                // Validación de la relacion entre los datos ingresados
                nuevaSubasta.Validar();
                // Si los datos son validos entonces se registra la Subasta
                if (!_publicaciones.Contains(nuevaSubasta))
                {
                    _publicaciones.Add(nuevaSubasta);
                    if (imprimir)
                    {
                        Console.WriteLine("La subasta fue registrada correctamente");
                    }
                }
                else
                {
                    throw new Exception("Ya existe una subasta con el mismo nombre");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        #endregion
        #region Usuario
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
        public void AltaCliente(string nombre, string apellido, string email, string contrasenia, decimal saldo, bool imprimir)
        {
            try
            {
                Cliente nuevoCliente = new Cliente(nombre, apellido, email, contrasenia, saldo);
                // Validación de la relacion entre los datos ingresados
                nuevoCliente.Validar();
                // Si los datos son validos entonces se registra el Cliente
                if (!_usuarios.Contains(nuevoCliente))
                {
                    _usuarios.Add(nuevoCliente);
                    if (imprimir)
                    {
                        Console.WriteLine("El cliente fue registrado correctamente");
                    }
                }
                else
                {
                    throw new Exception("Ya existe un cliente con el mismo nombre y apellido");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void AltaAdministrador(string nombre, string apellido, string email, string contrasenia, bool imprimir)
        {
            try
            {
                Administrador nuevoAdministrador = new Administrador(nombre, apellido, email, contrasenia);
                // Validación de la relacion entre los datos ingresados
                nuevoAdministrador.Validar();
                // Si los datos son validos entonces se registra el Administrador
                if (!_usuarios.Contains(nuevoAdministrador))
                {
                    _usuarios.Add(nuevoAdministrador);
                    if (imprimir)
                    {
                        Console.WriteLine("El administrador fue registrado correctamente");
                    }
                }
                else
                {
                    throw new Exception("Ya existe un administrador con el mismo nombre y apellido");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        #endregion
        #endregion

        #region Precargas
        #region Articulo
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
        #endregion
        #region Publicacion
        public void PrecargarPublicacion()
        {
            AltaVenta("Verano en la playa", "ABIERTA", DateTime.ParseExact("05/01/2024", "dd/MM/yyyy", null), ObtenerArticuloPorId(new List<int> { 11, 24, 35, 54 }), null, null, DateTime.MinValue, false, false);
            AltaSubasta("Vuelta ciclista", "ABIERTA", DateTime.ParseExact("06/01/2024", "dd/MM/yyyy", null), ObtenerArticuloPorId(new List<int> { 27, 33, 39 }), null, null, DateTime.MinValue, new List<Oferta>(), false);
            AltaVenta("Set de playa", "ABIERTA", DateTime.ParseExact("13/12/2024", "dd/MM/yyyy", null), ObtenerArticuloPorId(new List<int> { 1, 3, 4 }), null, null, DateTime.MinValue, false, false);
        }
        #endregion
        #region Usuario
        public void PrecargaUsuario()
        {
            AltaAdministrador("Valentin", "Latorre", "ValentinLatorre@Gmail.com", "Valentin1234", false);
            AltaAdministrador("Agustin", "Butrico", "AgustinButrico@gmail.com", "Agustin1234", false);
            AltaCliente("Juan", "Peres", "Juanperes@hmail.com", "Juan1234", 2000, false);
            AltaCliente("Esteban", "Lopez", "EstebanLopez@hmail.com", "556643", 2000, false);
            AltaCliente("Carlos", "Medina", "CarlosMedina@hmail.com", "Medina1234", 4500, false);
            AltaCliente("Mariano", "Morales", "MarianoMorales@hmail.com", "Mariano2", 5000, false);
            AltaCliente("Estela", "Rosales", "EstelaRosales@hmail.com", "Rosalia46", 300, false);
            AltaCliente("Marcos", "Sauce", "MarcosSauce@hmail.com", "Sauce31", 30000, false);
            AltaCliente("Lucia", "Gomez", "LuciaGomezs@hmail.com", "Lucia1990", 7200, false);
            AltaCliente("Rodrigo", "Barrios", "RodrigoBarrios@hmail.com", "RodrigoBarrios12", 900, false);
        }
        #endregion
        #endregion

        #region Consultas
        /// <summary>
        /// Estas función averigua el precio total de una lista de ventas
        /// que puede obtenerse con funciones como ObtenerVentaPorId y ObtenerVentaPorNombre
        /// La función recorre la lista pasada por parametros, castea las ventas y entra en otro for
        /// para acceder a los articulos de esa venta y sumar sus precios.
        /// Los precios sumados de los articulos de una venta son almacenados en la posicion de la
        /// lista precio correspondiente (siempre es i).
        /// Una vez sumados los precios de los articulos de una venta, se evalua si es oferta,
        /// si así lo es, entonces se aplica el 20% de descuento.
        /// </summary>
        public List<decimal> ConsultarPrecioVentaDeListaVenta(List<Publicacion> ventas)
        {
            List<decimal> precio = new List<decimal>();
            for (int i = 0; i < ventas.Count; i++)
            {
                if (ventas[i] is Venta venta)
                {
                    // Recorre la lista de articulos de la venta en especifico y suma su precio al total
                    for (int j = 0; j < venta.Articulos.Count; j++)
                    {
                        precio[i] += venta.Articulos[j].Precio;
                    }
                    if (venta.OfertaRelampago)
                    {
                        precio[i] = precio[i] * 80 / 100;
                    }
                }
            }
            return precio;
        }
        #endregion
    }
}

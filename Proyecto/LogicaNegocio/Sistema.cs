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
        // Atributos de la clase
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();

        // Propiedades
        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }
        public List<Publicacion> Publicacion
        {
            get { return _publicaciones; }
            set { _publicaciones = value; }
        }
        public List<Articulo> Articulo
        {
            get { return _articulos; }
            set { _articulos = value; }
        }

        // Ejecucion principal
        public Sistema()
        {
            PrecargaArticulos();
            PrecargarPublicaciones();
        }

        // Obtencion de listas
        public void ObtenerUsuarioPorId(int id)
        {
            int indice = 0; // Inicializamos un índice
            Usuario? usuario = null;  // Inicializamos la variable que contendrá el Usuario

            while (indice < _usuarios.Count && usuario == null)
            {
                // Comprobamos si el ID coincide
                if (_usuarios[indice].Id == id)
                {
                    usuario = _usuarios[indice];  // Asignamos el Usuario encontrada
                }
                indice++;
            }

            if (usuario != null)
            {
                // Mostramos los detalles del Usuario
                Console.WriteLine($"ID: {usuario.Id}");
                Console.WriteLine($"Nombre: {usuario.Nombre}");
                Console.WriteLine($"Apellido: {usuario.Apellido}");
                Console.WriteLine($"Email: {usuario.Email}");
                Console.WriteLine($"Contraseña: {usuario.Contrasenia}");
            }
            else
            {
                // Mensaje si no encontramos de Usuario
                Console.WriteLine("Usuario no encontrada.");
            }
        }
        public void ObtenerArticuloPorId(int id)
        {
            int indice = 0; // Inicializamos un índice
            Articulo? articulo = null;  // Inicializamos la variable que contendrá el Articulo

            while (indice < _articulos.Count && articulo == null)
            {
                // Comprobamos si el ID coincide
                if (_articulos[indice].Id == id)
                {
                    articulo = _articulos[indice];  // Asignamos el Articulo encontrada
                }
                indice++;
            }

            if (articulo != null)
            {
                // Mostramos los detalles del Articulo
                Console.WriteLine($"ID: {articulo.Id}");
                Console.WriteLine($"Nombre: {articulo.Nombre}");
                Console.WriteLine($"Estado: {articulo.Precio}");
            }
            else
            {
                // Mensaje si no encontramos de Articulo
                Console.WriteLine("Articulo no encontrada.");
            }
        }
        public void ObtenerPublicacionPorId(int id)
        {
            int index = 0;  // Inicializamos un índice
            Publicacion? publicacion = null;  // Inicializamos la variable que contendrá la publicación

            while (index < _publicaciones.Count && publicacion == null)
            {
                // Comprobamos si el ID coincide
                if (_publicaciones[index].Id == id)
                {
                    publicacion = _publicaciones[index];  // Asignamos la publicación encontrada
                }
                index++;
            }

            if (publicacion != null)
            {
                // Mostramos los detalles de la publicación
                Console.WriteLine($"ID: {publicacion.Id}");
                Console.WriteLine($"Nombre: {publicacion.Nombre}");
                Console.WriteLine($"Estado: {publicacion.Estado}");
                Console.WriteLine($"Fecha: {publicacion.Fecha}");
                Console.WriteLine($"Articulos: {publicacion.Articulos}");
                Console.WriteLine($"Cliente: {publicacion.Cliente}");
                Console.WriteLine($"Administrador: {publicacion.Administrador}");
                Console.WriteLine($"Fecha Fin: {publicacion.FechaFin}");
            }
            else
            {
                // Mensaje si no encontramos la publicación
                Console.WriteLine("Publicación no encontrada.");
            }
        }

        // Altas
        public void AltaArticulo(string nombre, decimal precio)
        {
            Articulo nuevoArticulo = new Articulo(nombre, precio);
            try
            {
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
            Publicacion nuevaPublicacion = new Publicacion(nombre, estado, fecha, articulos, cliente, administrador, fechaFin);
            try
            {
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

        // Precargas
        private void PrecargaArticulos()
        {
            AltaArticulo("Pelota", 450);
            AltaArticulo("Auto", 400503);
            AltaArticulo("Mouse gamer", 950);

        }
        private void PrecargarPublicaciones()
        {

        }

    }
}

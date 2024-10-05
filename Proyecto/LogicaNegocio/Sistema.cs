﻿using System;
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

        // Parseo Datos

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

        // Obtencion de listas
        public void ObtenerUsuarioPorId(List<int> ids, bool imprimir)
        {
            List<Usuario> usuarios = new List<Usuario>();  // Inicializamos la lista que contendrá el o los usuarios

            for (int i = 0; i < _usuarios.Count; i++)
            {
                if (ids.Contains(_usuarios[i].Id)) // Si la lista de ids contiene algun usuario
                {
                    usuarios.Add(_usuarios[i]); // Se añade el usuario a la lista usuarios
                }
            }

            if (usuarios.Count < 0 && imprimir) // Si hay algún usuario en la lista entonces se muestran los datos
            {
                for (int i =0; i < usuarios.Count; i++)
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
            else if (usuarios.Count < 0) // No muestra nada en pantalla
            {
            }
            else
            {
                // Mensaje si no encontramos de Usuario
                Console.WriteLine("Usuario no encontrado.");
            }
        }
        public void ObtenerArticuloPorId(List<int> ids, bool imprimir)
        {
            List<Articulo> articulos = new List<Articulo>();  // Inicializamos la lista que contendrá el o los articulos

            for (int i = 0; i < _articulos.Count; i++)
            {
                if (ids.Contains(_articulos[i].Id)) // Si la lista de ids contiene algun articulo
                {
                    articulos.Add(_articulos[i]); // Se añade el articulo a la lista articulos
                }
            }

            if (articulos.Count < 0 && imprimir) // Si hay algún articulo en la lista entonces se muestran los datos
            {
                for (int i = 0; i < articulos.Count; i++)
                {
                    // Mostramos los detalles del Articulo
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"ID: {articulos[i].Id}");
                    Console.WriteLine($"Nombre: {articulos[i].Nombre}");
                    Console.WriteLine($"Estado: {articulos[i].Precio}");
                }
                Console.WriteLine("-------------------------------------");
            }
            else if (articulos.Count < 0) // No muestra nada en pantalla
            {
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
        public void PrecargaUsuarios()
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
        public void PrecargaArticulos()
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
        public void PrecargarPublicaciones()
        {

        }

    }
}

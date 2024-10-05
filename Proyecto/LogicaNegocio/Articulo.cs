using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Articulo : IValidate
    {
        // Atributos de la clase
        private int _id;
        private static int s_ultId = 3; // Inicializado con el id siguiente a la ultima precarga
        private string _nombre = string.Empty; // Inicializado con una cadena vacía
        private decimal _precio = 0; // Inicializado con 0

        // Propiedades
        public int Id
        {
            get { return _id; }  // Solo lectura, asignado internamente.
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = EvaluarNombre(value); }
        }
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = EvaluarPrecio(value); }
        }

        // Constructor
        public Articulo(string nombre, decimal precio)
        {
            _id = Articulo.s_ultId; // Asigna el ID único
            Articulo.s_ultId++; // Incrementa el ID único
            Nombre = nombre;
            Precio = precio;
        }

        // Evaluaciones
        private static string EvaluarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new Exception("El nombre no puede ser vacío");
            }
            return nombre;
        }
        private static decimal EvaluarPrecio(decimal precio)
        {
            if (precio < 0)
            {
                throw new Exception("El precio no puede ser negativo");
            }
            return precio;
        }

        // Validación de Articulo
        public void Validar()
        {
        }

        // Sobre escritura del metodo Equals que es usado por Contains
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Articulo)
            {
                Articulo articulo = (Articulo)obj;
                return Nombre == articulo.Nombre;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Nombre.GetHashCode();
        }
    }
}

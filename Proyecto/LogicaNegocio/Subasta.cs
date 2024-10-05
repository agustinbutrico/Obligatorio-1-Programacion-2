using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Subasta : Publicacion
    {
        // Atributos de la clase
        private List<Oferta> _ofertas = new List<Oferta>(); // Inicializado con una lista vacía

        // Propiedades
        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
            set { _ofertas = value; }
        }

        // Constructor
        public Subasta(string nombre, string estado, DateTime fecha, List<Articulo> articulos, Cliente cliente, Administrador administrador, DateTime fechaFin, List<Oferta> ofertas)
            : base(nombre, estado, fecha, articulos, cliente, administrador, fechaFin) // Llamada al constructor de la clase base (Usuario)
        {
            Ofertas = ofertas;
        }

        // Sobre escritura del metodo Equals que es usado por Contains
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Subasta)
            {
                Subasta subasta = (Subasta)obj;
                return Nombre == subasta.Nombre;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Nombre.GetHashCode();
        }

        // Añade validaciones sobre la validacion de Publicaion
        public override void Validar()
        {

        }
    }
}

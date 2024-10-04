using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Venta : Publicacion
    {
        // Atributos de la clase
        private bool _ofertaRelampago = false; // Inicializado en falso

        // Propiedades
        public bool OfertaRelampago
        {
            get { return _ofertaRelampago; }
            set { _ofertaRelampago = value; }
        }

        // Constructor
        public Venta(string nombre, string estado, DateTime fecha, List<Articulo> articulos, Cliente cliente, Administrador administrador, DateTime fechaFin, bool ofertaRelampago)
            : base(nombre, estado, fecha, articulos, cliente, administrador, fechaFin) // Llamada al constructor de la clase base (Usuario)
        {
            OfertaRelampago = ofertaRelampago;
        }

        // Sobre escritura del metodo Equals que es usado por Contains
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Venta)
            {
                Venta venta = (Venta)obj;
                // return _nombre == venta.Nombre;
            }
            return false;
        }
    }
}

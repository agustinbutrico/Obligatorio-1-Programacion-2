using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio
{
    public class Oferta : IValidate
    {
        // Atributos de la clase
        private int _id;
        private static int s_ultId = 0; // Inicializado con el id siguiente a la ultima precarga
        private Usuario? _usuario; // Inicializado con una instancia por defecto
        private decimal _monto = 0; // Inicializado con 0
        private DateTime _fecha = DateTime.Now; // Inicializado con la fecha actual

        // Propiedades
        public int Id
        {
            get { return _id; }  // Solo lectura, asignado internamente.
        }
        public Usuario? Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public decimal Monto
        {
            get { return _monto; }
            set { _monto = EvaluarMonto(value); }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        // Constructor
        public Oferta(Usuario? usuario, decimal monto, DateTime fecha)
        {
            _id = Oferta.s_ultId; // Asigna el ID único
            Oferta.s_ultId++; // Incrementa el ID único
            Usuario = usuario;
            Monto = monto;
            Fecha = fecha;
        }

        // Evaluaciones
        private static decimal EvaluarMonto(decimal monto)
        {
            if (monto < 0)
            {
                throw new Exception("El monto no puede ser negativo");
            }
            return monto;
        }

        // Validación de Oferta
        public void Validar()
        {
        }

        // Sobre escritura del metodo Equals que es usado por Contains
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Oferta)
            {
                Oferta oferta = (Oferta)obj;
                return Monto == oferta.Monto;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Monto.GetHashCode();
        }
    }
}


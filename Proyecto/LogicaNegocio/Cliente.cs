using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cliente : Usuario, IValidate
    {
        // Atributos de la clase
        private decimal _saldo = 0; // Inicializado en 0

        // Propiedades
        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = EvaluarSaldo(value); }
        }

        // Constructor
        public Cliente(string nombre, string apellido, string email, string contrasenia, decimal saldo)
           : base(nombre, apellido, email, contrasenia) // Llamada al constructor de la clase base (Usuario)
        {
            Saldo = saldo;
        }

        // Sobre escritura del metodo Equals que es usado por Contains
        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Cliente)
            {
                Cliente cliente = (Cliente)obj;
                // return _nombre == cliente.Nombre;
            }
            return false;
        }

        // Evaluaciones
        private static decimal EvaluarSaldo(decimal saldo)
        {
            if (saldo < 0)
            {
                throw new Exception("El saldo no puede ser negativo");
            }
            return saldo;
        }

        // Validación de Publicacion
        public void Validar()
        {

        }
    }
}

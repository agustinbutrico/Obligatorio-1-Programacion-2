using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Administrador : Usuario
    {
        // Constructor
        public Administrador(string nombre, string apellido, string email, string contrasenia)
            : base(nombre, apellido, email, contrasenia) // Llamada al constructor de la clase base (Usuario)
        {
        }
    }
}


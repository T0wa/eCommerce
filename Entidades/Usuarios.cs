using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _contraseña;
        private bool _esAdmin;
        private int _dni;
        private bool _estado;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Email { get => _email; set => _email = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public bool EsAdmin { get => _esAdmin; set => _esAdmin = value; }
        public int Dni { get => _dni; set => _dni = value; }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}

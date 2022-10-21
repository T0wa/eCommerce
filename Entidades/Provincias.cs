using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincias
    {
        private int _idProvincia;
        private string _descripcion;
        private bool _estado;

        public int IdProvincia { get => _idProvincia; set => _idProvincia = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}

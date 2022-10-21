using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Localidades
    {
        private Provincias _provincia;
        private int _idLocalidades;
        private string _descripcion;
        private bool _estado;

        public Provincias Provincia { get => _provincia; set => _provincia = value; }
        public int IdLocalidades { get => _idLocalidades; set => _idLocalidades = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool Estado { get => _estado; set => _estado = value; }

        public Localidades()
        {
            _provincia = new Provincias();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorías
    {
        private static int _idcategoria;
        private string _descripcion;
        private bool _estado;

        public int IdCategoria { get => _idcategoria; set => _idcategoria = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool Estado { get => _estado; set => _estado = value; }

        public Categorías()
        {
            _idcategoria = -1;
            _descripcion = "";
            Estado = true;
        }
    }
}

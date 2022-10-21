using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class ReseñasProducto
    {
        private Productos _producto;
        private Usuarios _usuario;
        private string _contenido;
        private int _calificación;
        private DateTime _fecha;
        private bool _estado;

        public Usuarios Usuario { get => _usuario; set => _usuario = value; }
        public string Contenido { get => _contenido; set => _contenido = value; }
        public int Calificación { get => _calificación; set => _calificación = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public Productos Producto { get => _producto; set => _producto = value; }

        public ReseñasProducto()
        {
            _producto = new Productos();
            _usuario = new Usuarios();
        }
    }
}

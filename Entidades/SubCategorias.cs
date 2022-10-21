using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SubCategorias
    {
        private Categorías _Categoria;
        private int _idSubCategoria;
        private string _descripcion;
        private bool _estado;

        public int IdSubCategoria { get => _idSubCategoria; set => _idSubCategoria = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public Categorías Categoria { get => _Categoria; set => _Categoria = value; }

        public SubCategorias()
        {
            _Categoria = new Categorías();
            _Categoria.IdCategoria = -1;
            _idSubCategoria = -1;
            _descripcion = "";
            _estado = true;
        }
    }
}

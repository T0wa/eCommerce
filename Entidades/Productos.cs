using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Productos
    {
        private int _idProducto;
        private string _nombre;
        private string _descripcion;
        private decimal _precio;
        private SubCategorias _subcategoria;
        private int _stock;
        private string _urlImage;
        private bool _estado;

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public decimal Precio { get => _precio; set => _precio = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public string UrlImage { get => _urlImage; set => _urlImage = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public SubCategorias Subcategoria { get => _subcategoria; set => _subcategoria = value; }

        public Productos()
        {
            _subcategoria = new SubCategorias();
        }
    }

}

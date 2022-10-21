using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace Negocio
{
    public class FiltrosProductos
    {
        private int idCat;
        private int idSubCat;
        private string nombre;
        private int PrecioMin;
        private int PrecioMax;

        public FiltrosProductos()
        {
            this.IdCat = -1;
            this.IdSubCat = -1;
            this.Nombre = "";
            this.PrecioMin = -1;
            this.PrecioMax = -1;
        }

        public int IdCat { get => idCat; set => idCat = value; }
        public int IdSubCat { get => idSubCat; set => idSubCat = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int PrecioMinimo { get => PrecioMin; set => PrecioMin = value; }
        public int PrecioMaximo { get => PrecioMax; set => PrecioMax = value; }
    }

}

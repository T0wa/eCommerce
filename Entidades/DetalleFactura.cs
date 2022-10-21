using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFactura
    {
        private Facturas _factura;
        private Productos _producto;
        private decimal _precioUnitario;
        private int _cantidad;
        private bool _estado;

        public decimal PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public Facturas Factura { get => _factura; set => _factura = value; }
        public Productos Producto { get => _producto; set => _producto = value; }

        public DetalleFactura()
        {
            _factura = new Facturas();
            _producto = new Productos();
        }
    }

}

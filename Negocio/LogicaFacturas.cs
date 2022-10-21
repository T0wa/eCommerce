using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades;

namespace Negocio
{
    public class LogicaFacturas
    {
        DAOFacturas df = new DAOFacturas();

        public void agregarFactura(Facturas fac, DataTable carrito)
        {
            DetalleFactura detFac = new DetalleFactura();
            
            df.agregarFactura(fac);

            detFac.Factura.IdFactura = df.IdFacturaMaximo();

            foreach(DataRow dr in carrito.Rows)  //crea detalle de los productos del carrito
            {
                detFac.Producto.IdProducto = int.Parse(dr["IdProd"].ToString());
                detFac.PrecioUnitario = decimal.Parse(dr["Precio"].ToString());
                detFac.Cantidad = int.Parse(dr["Cantidad"].ToString());
                df.agregarDetalle(detFac);
            }
        }
        public DataTable obtenerFacturaSegunCliente(Usuarios us)
        {
            return df.obtenerFacturasXCliente(us);
        }

        public DataTable obtenerDetalles(Facturas fac)
        {
            return df.obtenerDetalleSegunFactura(fac);
        }
    }
}

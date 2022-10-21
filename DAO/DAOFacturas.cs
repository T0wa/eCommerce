using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class DAOFacturas
    {
        private Conexion cn = new Conexion();

        public int IdFacturaMaximo()
        {
            return cn.obtenerMaximo("SELECT MAX(Id_Factura) from Facturas");
        }

        public DataTable obtenerFacturasXCliente(Usuarios us)
        {
            return cn.obtenerTabla("SELECT Id_Factura,ValorTotal_Factura,FechaEmision_Factura " +
                "FROM FacturasXcliente where DNI_Usuario = " + us.Dni);
        }

        public DataTable obtenerDetalleSegunFactura(Facturas fac)
        {
            return cn.obtenerTabla("select Nombre_Producto,Precio_Producto,Cantidad_Detalle,Total from DetallesXFacturas where Id_Factura_Detalle = " + fac.IdFactura);
        }

        private void armarParametrosAgregarFactura(ref SqlCommand comando, Facturas fac)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@NROTARJETA", SqlDbType.Char, 20);
            parametro.Value = fac.Tarjeta.NumeroTarjeta;
            parametro = comando.Parameters.Add("@SEENVIA", SqlDbType.Bit);
            parametro.Value = fac.Envio;
            parametro = comando.Parameters.Add("@DIRECCION", SqlDbType.VarChar, 50);
            parametro.Value = fac.DireccionEnvio;
            parametro = comando.Parameters.Add("@RANGO", SqlDbType.VarChar, 20);
            parametro.Value = fac.RangoHorario;
            parametro = comando.Parameters.Add("@IDPROV", SqlDbType.Int);
            parametro.Value = fac.Localidad.Provincia.IdProvincia;
            parametro = comando.Parameters.Add("@IDLOCAL", SqlDbType.Int);
            parametro.Value = fac.Localidad.IdLocalidades;
        }

        private void armarParametrosAgregarDetalle(ref SqlCommand comando, DetalleFactura df)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@IDFACTURA", SqlDbType.Int);
            parametro.Value = df.Factura.IdFactura;
            parametro = comando.Parameters.Add("@IDPRODUCTO", SqlDbType.Int);
            parametro.Value = df.Producto.IdProducto;
            parametro = comando.Parameters.Add("@PRECIO", SqlDbType.Decimal);
            parametro.Value = df.PrecioUnitario;
            parametro = comando.Parameters.Add("@CANTIDAD", SqlDbType.Int);
            parametro.Value = df.Cantidad;
        }

        public int agregarDetalle(DetalleFactura df)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosAgregarDetalle(ref cmd, df);
            return cn.ejecutarSP(cmd, "SP_AgregarDetalleFactura");
        }

        public int agregarFactura(Facturas fac)
        {
            //Parametros obligatorios: NroTarjeta, Envío(Bool)
            //Parametros que se agregan si envío es true: Direccion,Rango,IdProv,IdLocalidad
            SqlCommand cmd = new SqlCommand();
            armarParametrosAgregarFactura(ref cmd, fac);
            return cn.ejecutarSP(cmd, "SP_AgregarFactura");
        }
    }
}

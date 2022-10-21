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
    public class LogicaTarjetas
    {
        private DaoTarjetas dt = new DaoTarjetas();

        public DataTable getTarjetas()
        {
            return dt.obtenerTarjetas();
        }

        public DataTable tarjetasDeUsuario(Usuarios us)
        {
            return dt.obtenerTarjetasDeUsuario(us);
        }

        public bool agregarTarjeta(Tarjetas tarjeta)
        {
            return dt.SP_agregarTarjeta(tarjeta) != 0;
        }

        public bool eliminarTarjeta(Tarjetas tarjeta)
        {
            return dt.eliminarTarjeta(tarjeta) != 0;
        }
    }
}

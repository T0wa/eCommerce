using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using Entidades;
using System.Data;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaReseñas
    {
        private DaoReseñas dRes = new DaoReseñas();

        public DataTable getReseñas()
        {
            return dRes.ObtenerReseñas();
        }

        public bool agregarReseña(ReseñasProducto res)
        {
            return dRes.agregarReseña(res) == 1;
        }

        public bool EliminarReseña(ReseñasProducto res)
        {
            return dRes.EliminarReseña(res) == 1;
        }

        public bool VerificarReseña(ReseñasProducto res)
        {
            if (dRes.VerificarReseña(res) == 1)
                return true;
            else
                return false;
        }


        public DataTable ultimas10Reseñas(Productos prod)
        {
            return dRes.ultimas10Reseñas(prod);
        }
    }
}

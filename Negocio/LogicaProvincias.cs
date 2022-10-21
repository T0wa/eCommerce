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
    public class LogicaProvincias
    {
        private DaoProvincias daoProv = new DaoProvincias();

        public DataTable getProvincias()
        {
            return daoProv.obtenerProvincias();
        }

        public DataTable getLocalidades(Provincias prov)
        {
            return daoProv.obtenerLocalidadesXProvincia(prov);
        }
    }
}

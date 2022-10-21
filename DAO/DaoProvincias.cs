using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using Entidades;

namespace DAO
{
    public class DaoProvincias
    {
        private Conexion cn = new Conexion();

        public DataTable obtenerProvincias()
        {
            return cn.obtenerTabla("SELECT Id_Provincia,Nombre_Provincia FROM Provincias");
        }

        public DataTable obtenerLocalidadesXProvincia(Provincias prov)
        {
            return cn.obtenerTabla("SELECT * FROM Localidades WHERE Id_Provincia_Localidad = " + prov.IdProvincia);
        }
    }
}

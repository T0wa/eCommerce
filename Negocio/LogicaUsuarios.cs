using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using DAO;

namespace Negocio
{
    public class LogicaUsuarios
    {
        private DaoUsuarios dUs = new DaoUsuarios();

        public Usuarios getUsuarioSegunMail(Usuarios user) //Recibe un usuario con email cargado, devuelve el usuario con todos sus datos
        {
            return dUs.obtenerDatosUsuarioXMail(user);
        }

        public bool verificarQueUsuarioExiste(Usuarios user)
        {
            return dUs.verificarExistenciaUsuario(user);
        }

        public DataTable getUsuarios()
        {
            return dUs.obtenerUsuarios();
        }

        public bool agregarUsuario(Usuarios user)
        {
            return (dUs.ejecutarSP_AgregarUsuario(user) > 0);
        }

        public bool eliminarUsuario(Usuarios user)
        {
            return (dUs.ejecutarSP_EliminarUsuario(user) > 0);
        }

        public bool EditarUsuario(Usuarios user)
        {
            if (dUs.EditarUsuario(user) == 1)
                return true;
            else
                return false;
        }

        public bool EditarAdminUsuario(Usuarios user)
        {
            if (dUs.EditarAdminUsuario(user) == 1)
                return true;
            else
                return false;
        }

        //public bool modificarUsuario(Usuarios user)
        //{
        //    return (dUs.modificarCamposUsuario(user) > 0);
        //}

        public DataTable BusquedaConFiltrosGrdAdmin(string nombre, string apellido)
        {
            string consulta = "";

            if (nombre != "")
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from UsuariosHabilitados where [Nombre_Usuario] like '%" + nombre + "%' ";
                }
                else
                {
                    consulta +=
                    " and [Nombre_Usuario] like '%" + nombre + "%'";
                }
            }

            if (apellido != "")
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from UsuariosHabilitados where [Apellido_Usuario] like '%" + apellido + "%' ";
                }
                else
                {
                    consulta +=
                    " and [Apellido_Usuario] like '%" + apellido + "%'";
                }
            }
            if (consulta == "")
            {
                consulta = "select * from UsuariosHabilitados";
                return dUs.obtenerUsuarios(consulta);
            }

            return dUs.obtenerUsuarios(consulta);
        }


    }
}

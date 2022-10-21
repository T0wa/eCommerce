using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;


namespace DAO
{
    public class DaoUsuarios
    {
        private Conexion conn = new Conexion();

        public DataTable obtenerUsuarios()
        {
            return conn.obtenerTabla("select * from UsuariosHabilitados");
        }

        public DataTable obtenerUsuarios(string consulta)
        {
            return conn.obtenerTabla(consulta);
        }

        public bool verificarExistenciaUsuario(Usuarios user)
        {
            string consulta = "SELECT Email_Usuario, Contraseña_Usuario FROM UsuariosHabilitados WHERE Email_Usuario = '" + user.Email + "' AND Contraseña_Usuario='" + user.Contraseña + "'";

            if (conn.obtenerTabla(consulta).Rows.Count > 0)
                return true;
            else
                return false;
        }

        public Usuarios obtenerDatosUsuarioXMail(Usuarios user)
        {
            DataTable tablaUsuarios = new DataTable();
            tablaUsuarios = conn.obtenerTabla("Select * from UsuariosHabilitados where Email_Usuario = '" + user.Email + "'");

            user.Dni = Convert.ToInt32(tablaUsuarios.Rows[0][0]);
            user.Nombre = tablaUsuarios.Rows[0][1].ToString();
            user.Apellido = tablaUsuarios.Rows[0][2].ToString();
            user.Email = tablaUsuarios.Rows[0][3].ToString();
            user.Contraseña = tablaUsuarios.Rows[0][4].ToString();
            user.EsAdmin = Convert.ToBoolean(tablaUsuarios.Rows[0][5]);
            user.Estado = Convert.ToBoolean(tablaUsuarios.Rows[0][7]);

            return user;
        }

        

        private void armarParametrosAgregarUsuario(ref SqlCommand cmd, Usuarios user)
        {
            SqlParameter sqlP = new SqlParameter();
            sqlP = cmd.Parameters.Add("@DNI", SqlDbType.Char, 10);
            sqlP.Value = user.Dni.ToString();
            sqlP = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 20);
            sqlP.Value = user.Nombre;
            sqlP = cmd.Parameters.Add("@APELLIDO", SqlDbType.VarChar, 20);
            sqlP.Value = user.Apellido;
            sqlP = cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 50);
            sqlP.Value = user.Email;
            sqlP = cmd.Parameters.Add("@CONTRASEÑA", SqlDbType.VarChar, 20);
            sqlP.Value = user.Contraseña;
        }

        public int ejecutarSP_AgregarUsuario(Usuarios user)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosAgregarUsuario(ref cmd, user);
            return conn.ejecutarSP(cmd, "SP_AgregarUsuario");
        }

        private void armarParametrosEliminarUsuario(ref SqlCommand cmd, Usuarios user)
        {
            SqlParameter sqlP = new SqlParameter();
            sqlP = cmd.Parameters.Add("@DNI", SqlDbType.Char, 10);
            sqlP.Value = user.Dni.ToString();
        }

        public int ejecutarSP_EliminarUsuario(Usuarios user)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosEliminarUsuario(ref cmd, user);
            return conn.ejecutarSP(cmd, "SP_EliminarUsuario");
        }

        private void armarParametrosEditarUsuario(ref SqlCommand cmd, Usuarios user)
        {
            SqlParameter sqlP = new SqlParameter();
            sqlP = cmd.Parameters.Add("@DNI", SqlDbType.Char, 10);
            sqlP.Value = user.Dni.ToString();
            sqlP = cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 20);
            sqlP.Value = user.Nombre;
            sqlP = cmd.Parameters.Add("@APELLIDO", SqlDbType.VarChar, 20);
            sqlP.Value = user.Apellido;
            sqlP = cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 50);
            sqlP.Value = user.Email;
            sqlP = cmd.Parameters.Add("@CONTRASEÑA", SqlDbType.VarChar, 20);
            sqlP.Value = user.Contraseña;
        }
        public int EditarUsuario(Usuarios user)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosEditarUsuario(ref cmd, user);
            return conn.ejecutarSP(cmd, "SP_EditarUsuario");
        }

        private void armarParametrosEditarAdminUsuario(ref SqlCommand cmd, Usuarios user)
        {
            SqlParameter sqlP = new SqlParameter();
            sqlP = cmd.Parameters.Add("@DNI", SqlDbType.Char, 10);
            sqlP.Value = user.Dni.ToString();
            sqlP = cmd.Parameters.Add("@ADMIN", SqlDbType.Bit);
            sqlP.Value = user.EsAdmin;
        }
        public int EditarAdminUsuario(Usuarios user)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosEditarAdminUsuario(ref cmd, user);
            return conn.ejecutarSP(cmd, "SP_EditarAdminUsuario");
        }

        //public int modificarCamposUsuario(Usuarios user) 
        //{
        //    string consulta = "UPDATE Usuarios Set DNI_Usuario = '" + user.Dni + "' ";

        //    if (user.Nombre != "")
        //        consulta += ",Nombre_Usuario = '" + user.Nombre + "' ";
        //    if (user.Apellido != "")
        //        consulta += ",Apellido_Usuario = '" + user.Apellido + "' ";
        //    if (user.Contraseña != "")
        //        consulta += ",Contraseña_Usuario = '" + user.Contraseña + "' ";
        //    if (user.Email != "")
        //        consulta += ",Email_Usuario = '" + user.Email + "' ";
        //    consulta += "Where DNI_Usuario = " + user.Dni;

        //    return conn.ejecutarTransaccion(consulta);
        //}

    }
}

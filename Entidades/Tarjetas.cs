using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tarjetas
    {
        private string _numeroTarjeta;
        private Usuarios _usuario;
        private int _codigoSeguridad;
        private DateTime _fechaExpiracion;
        private bool _estado;

        public string NumeroTarjeta { get => _numeroTarjeta; set => _numeroTarjeta = value; }
        public Usuarios Usuario { get => _usuario; set => _usuario = value; }
        public int CodigoSeguridad { get => _codigoSeguridad; set => _codigoSeguridad = value; }
        public DateTime FechaExpiracion { get => _fechaExpiracion; set => _fechaExpiracion = value; }
        public bool Estado { get => _estado; set => _estado = value; }

        public Tarjetas()
        {
            _usuario = new Usuarios();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Facturas
    {
        private int _idFactura;
        private Tarjetas _tarjeta;
        private int _valorTotal;
        private DateTime _fechaEmicion;
        private bool _envio;
        private string _direccionEnvio;
        private string _rangoHorario;
        private Provincias _provincia;
        private Localidades _localidad;
        private bool _estado;

        public int IdFactura { get => _idFactura; set => _idFactura = value; }
        public Tarjetas Tarjeta { get => _tarjeta; set => _tarjeta = value; }
        public int ValorTotal { get => _valorTotal; set => _valorTotal = value; }
        public DateTime FechaEmicion { get => _fechaEmicion; set => _fechaEmicion = value; }
        public bool Envio { get => _envio; set => _envio = value; }
        public string DireccionEnvio { get => _direccionEnvio; set => _direccionEnvio = value; }
        public string RangoHorario { get => _rangoHorario; set => _rangoHorario = value; }
        public Provincias Provincia { get => _provincia; set => _provincia = value; }
        public Localidades Localidad { get => _localidad; set => _localidad = value; }
        public bool Estado { get => _estado; set => _estado = value; }

        public Facturas()
        {
            _tarjeta = new Tarjetas();
            _provincia = new Provincias();
            _localidad = new Localidades();
        }
    }
}

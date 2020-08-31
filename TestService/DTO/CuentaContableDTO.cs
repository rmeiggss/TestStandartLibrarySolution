using System;

namespace TestService.DTO
{
    public class CuentaContableDTO
    {
        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string Descripcion { get; set; }
        public string Analisis { get; set; }
        public bool Destino { get; set; }
        public string Nivel { get; set; }
        public bool OtrosTributos { get; set; }
        public bool FlagBaseImponible { get; set; }
        public bool FlagCentroCosto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Usuario { get; set; }
        public int? IdCuentaDebe { get; set; }
        public int? IdCuentaHaber { get; set; }
        public string TipoCuenta { get; set; }
    }
}

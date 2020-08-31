using Dapper.Contrib.Extensions;
using System;

namespace TestModels.Models
{
    [Table("cuenta_contable")]
    public class cuenta_contable
    {
        [Key]
        public int cue_cont_id { get; set; }
        public string cue_cont_numero { get; set; }
        public string cue_cont_padre { get; set; }
        public string cue_cont_descri { get; set; }
        public string cue_cont_nivel { get; set; }
        public string cue_cont_analisis { get; set; }
        public string cue_cont_moneda { get; set; }
        public bool cue_cont_destino { get; set; }
        public string cue_cont_tipo { get; set; }
        public bool cue_cont_ajuste { get; set; }
        public bool cue_cont_cent_cost { get; set; }
        public int? cue_cont_id_debe { get; set; }
        public int? cue_cont_id_haber { get; set; }
        public string cue_tipo_saldo { get; set; }
        public bool cue_bflag_base_imponible { get; set; }
        public bool cue_bflag_otros_tributos { get; set; }
        public string usuario_registro { get; set; }
        public DateTime fecha_registro { get; set; }
        public string usuario_modificacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}

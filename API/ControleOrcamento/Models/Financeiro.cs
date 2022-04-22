using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleOrcamento.Models {
    public class Financeiro {
        public int? Id { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public int Valor { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
    }
}

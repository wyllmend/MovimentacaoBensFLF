using System;
using System.ComponentModel.DataAnnotations;

namespace MovimentacaoBensFLF.Models
{
    public class Solicitacao
    {
        public int Id { get; set; }

        [Required]
        public int BemId { get; set; }
        public Bem Bem { get; set; } = null!;

        [Required, StringLength(50)]
        public string Tipo { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Origem { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Destino { get; set; } = string.Empty;

        [StringLength(500)]
        public string Justificativa { get; set; } = string.Empty;

        [Required]
        public string UsuarioId { get; set; } = string.Empty; // email ou id do usuário logado

        public DateTime DataSolicitacao { get; set; } = DateTime.Now;

        [Required]
        public string Status { get; set; } = "Pendente"; // Pendente | Aprovada | Rejeitada | Cancelada

        public string MotivoRejeicao { get; set; } = string.Empty;
    }
}

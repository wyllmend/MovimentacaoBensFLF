using System;

namespace MovimentacaoBensFLF.Models
{
    public class ChatMensagem
    {
        public int Id { get; set; }

        public int SolicitacaoId { get; set; }
        public Solicitacao Solicitacao { get; set; } = null!;

        public string UsuarioId { get; set; } = string.Empty; // solicitante ou gestor
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}

using System.ComponentModel.DataAnnotations;

namespace MovimentacaoBensFLF.Models
{
    public class Bem
    {
        public int Id { get; set; }  

        [Required, StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string MarcaModelo { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string LocalizacaoAtual { get; set; } = string.Empty;

        [Required]
        public string NumeroPatrimonio { get; set; } = string.Empty;
    }
}

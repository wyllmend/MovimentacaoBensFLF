using System.ComponentModel.DataAnnotations;

namespace MovimentacaoBensFLF.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@instituicao\.com$",
            ErrorMessage = "Use apenas o e-mail institucional")]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public required string SenhaHash { get; set; } // Armazena o hash da senha

        public required string Papel { get; set; }  // "Usuario" ou "Gestor"
    }
}

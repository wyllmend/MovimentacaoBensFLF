using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovimentacaoBensFLF.Models;

namespace MovimentacaoBensFLF.Data
{
    public class MovimentacaoBensFLFContext : DbContext
    {
        public MovimentacaoBensFLFContext (DbContextOptions<MovimentacaoBensFLFContext> options)
            : base(options)
        {
        }

        public DbSet<MovimentacaoBensFLF.Models.Bem> Bem { get; set; } = default!;
        public DbSet<MovimentacaoBensFLF.Models.Solicitacao> Solicitacao { get; set; } = default!;
        public DbSet<MovimentacaoBensFLF.Models.ChatMensagem> ChatMensagem { get; set; } = default!;
        public DbSet<MovimentacaoBensFLF.Models.Usuario> Usuario { get; set; } = default!;
    }
}

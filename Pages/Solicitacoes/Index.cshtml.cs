using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovimentacaoBensFLF.Data;
using MovimentacaoBensFLF.Models;

namespace MovimentacaoBensFLF.Pages.Solicitacoes
{
    public class IndexModel : PageModel
    {
        private readonly MovimentacaoBensFLFContext _context;

        public IndexModel(MovimentacaoBensFLFContext context)
        {
            _context = context;
        }

        public IList<Solicitacao> Solicitacao { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Solicitacao = await _context.Solicitacao
                .Include(s => s.Bem).ToListAsync();
        }
    }
}

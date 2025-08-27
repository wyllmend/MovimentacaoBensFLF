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
    public class DeleteModel : PageModel
    {
        private readonly MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext _context;

        public DeleteModel(MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Solicitacao Solicitacao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacao.FirstOrDefaultAsync(m => m.Id == id);

            if (solicitacao is not null)
            {
                Solicitacao = solicitacao;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacao = await _context.Solicitacao.FindAsync(id);
            if (solicitacao != null)
            {
                Solicitacao = solicitacao;
                _context.Solicitacao.Remove(Solicitacao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

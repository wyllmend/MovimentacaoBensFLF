using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovimentacaoBensFLF.Data;
using MovimentacaoBensFLF.Models;

namespace MovimentacaoBensFLF.Pages.Solicitacoes
{
    public class CreateModel : PageModel
    {
        private readonly MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext _context;

        public CreateModel(MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BemId"] = new SelectList(_context.Bem, "Id", "LocalizacaoAtual");
            return Page();
        }

        [BindProperty]
        public Solicitacao Solicitacao { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Solicitacao.Add(Solicitacao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

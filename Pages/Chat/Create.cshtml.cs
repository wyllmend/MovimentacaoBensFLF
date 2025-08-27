using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovimentacaoBensFLF.Data;
using MovimentacaoBensFLF.Models;

namespace MovimentacaoBensFLF.Pages.Chat
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
        ViewData["SolicitacaoId"] = new SelectList(_context.Solicitacao, "Id", "Destino");
            return Page();
        }

        [BindProperty]
        public ChatMensagem ChatMensagem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ChatMensagem.Add(ChatMensagem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

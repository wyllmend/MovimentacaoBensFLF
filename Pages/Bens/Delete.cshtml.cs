using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovimentacaoBensFLF.Data;
using MovimentacaoBensFLF.Models;

namespace MovimentacaoBensFLF.Pages.Bens
{
    public class DeleteModel : PageModel
    {
        private readonly MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext _context;

        public DeleteModel(MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bem Bem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bem = await _context.Bem.FirstOrDefaultAsync(m => m.Id == id);

            if (bem is not null)
            {
                Bem = bem;

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

            var bem = await _context.Bem.FindAsync(id);
            if (bem != null)
            {
                Bem = bem;
                _context.Bem.Remove(Bem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

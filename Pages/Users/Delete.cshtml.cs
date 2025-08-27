using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovimentacaoBensFLF.Data;
using MovimentacaoBensFLF.Models;

namespace MovimentacaoBensFLF.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext _context;

        public DeleteModel(MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FirstOrDefaultAsync(m => m.Id == id);

            if (usuario is not null)
            {
                Usuario = usuario;

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

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                Usuario = usuario;
                _context.Usuario.Remove(Usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

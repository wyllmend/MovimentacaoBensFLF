using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovimentacaoBensFLF.Data;
using MovimentacaoBensFLF.Models;

namespace MovimentacaoBensFLF.Pages.Bens
{
    public class EditModel : PageModel
    {
        private readonly MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext _context;

        public EditModel(MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext context)
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

            var bem =  await _context.Bem.FirstOrDefaultAsync(m => m.Id == id);
            if (bem == null)
            {
                return NotFound();
            }
            Bem = bem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BemExists(Bem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BemExists(int id)
        {
            return _context.Bem.Any(e => e.Id == id);
        }
    }
}

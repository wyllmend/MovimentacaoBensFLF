using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovimentacaoBensFLF.Data;
using MovimentacaoBensFLF.Models;

namespace MovimentacaoBensFLF.Pages.Chat
{
    public class IndexModel : PageModel
    {
        private readonly MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext _context;

        public IndexModel(MovimentacaoBensFLF.Data.MovimentacaoBensFLFContext context)
        {
            _context = context;
        }

        public IList<ChatMensagem> ChatMensagem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ChatMensagem = await _context.ChatMensagem
                .Include(c => c.Solicitacao).ToListAsync();
        }
    }
}

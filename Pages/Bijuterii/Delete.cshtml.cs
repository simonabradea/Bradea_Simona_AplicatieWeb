using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bradea_Simona_AplicatieWeb.Data;
using Bradea_Simona_AplicatieWeb.Models;

namespace Bradea_Simona_AplicatieWeb.Pages.Bijuterii
{
    public class DeleteModel : PageModel
    {
        private readonly Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext _context;

        public DeleteModel(Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bijuterie Bijuterie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bijuterie = await _context.Bijuterie.FirstOrDefaultAsync(m => m.ID == id);

            if (Bijuterie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bijuterie = await _context.Bijuterie.FindAsync(id);

            if (Bijuterie != null)
            {
                _context.Bijuterie.Remove(Bijuterie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

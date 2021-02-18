using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bradea_Simona_AplicatieWeb.Data;
using Bradea_Simona_AplicatieWeb.Models;

namespace Bradea_Simona_AplicatieWeb.Pages.Categorii
{
    public class CreateModel : PageModel
    {
        private readonly Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext _context;

        public CreateModel(Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Categorie Categorie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Categorie.Add(Categorie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

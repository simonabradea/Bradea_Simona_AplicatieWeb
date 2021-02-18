using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bradea_Simona_AplicatieWeb.Data;
using Bradea_Simona_AplicatieWeb.Models;

namespace Bradea_Simona_AplicatieWeb.Pages.Bijuterii
{
    public class CreateModel : BijuterieCategoriiPaginaModel
    {
        private readonly Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext _context;

        public CreateModel(Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "ClientNume");
            var bijuterie = new Bijuterie(); bijuterie.BijuterieCategorii = new List<BijuterieCategorie>();
            PopulateAssignedCategoryData(_context, bijuterie);
            return Page();

        }

        [BindProperty]
        public Bijuterie Bijuterie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategorii)
        {
            var newBijuterie = new Bijuterie(); if (selectedCategorii != null)
            {
                newBijuterie.BijuterieCategorii = new List<BijuterieCategorie>(); foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new BijuterieCategorie
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newBijuterie.BijuterieCategorii.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Bijuterie>(newBijuterie, "Bijuterie", i => i.Denumire, i => i.Bijutier, i => i.Pret, i => i.DataVanzarii, i => i.ClientID)) { _context.Bijuterie.Add(newBijuterie); await _context.SaveChangesAsync(); return RedirectToPage("./Index"); }
            PopulateAssignedCategoryData(_context, newBijuterie); return Page();
        }
    }
}

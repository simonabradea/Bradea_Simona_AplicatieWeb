using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bradea_Simona_AplicatieWeb.Data;
using Bradea_Simona_AplicatieWeb.Models;

namespace Bradea_Simona_AplicatieWeb.Pages.Bijuterii
{
    public class EditModel : BijuterieCategoriiPaginaModel
    {
        private readonly Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext _context;

        public EditModel(Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext context)
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
            Bijuterie = await _context.Bijuterie.Include(b => b.Client).Include(b => b.BijuterieCategorii).ThenInclude(b => b.Categorie).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            

            if (Bijuterie == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Bijuterie);
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "ClientNume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategorii)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bijuterieToUpdate = await _context.Bijuterie
            .Include(i => i.Client)
            .Include(i => i.BijuterieCategorii)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (bijuterieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Bijuterie>(
            bijuterieToUpdate,
            "Bijuterie",
            i => i.Denumire, i => i.Bijutier,
            i => i.Pret, i => i.DataVanzarii, i => i.Client))
            {
                UpdateBijuterieCategorii(_context, selectedCategorii, bijuterieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateBijuterieCategorii(_context, selectedCategorii, bijuterieToUpdate);
            PopulateAssignedCategoryData(_context, bijuterieToUpdate);
            return Page();
        }
    }
 }



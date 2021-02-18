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
    public class IndexModel : PageModel
    {
        private readonly Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext _context;

        public IndexModel(Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext context)
        {
            _context = context;
        }

        public IList<Bijuterie> Bijuterie { get; set; }

        public BijuterieData BijuterieD { get; set; }
        public int BijuterieID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            BijuterieD = new BijuterieData();

            BijuterieD.Bijuterii = await _context.Bijuterie
            .Include(b => b.Client)
            .Include(b => b.BijuterieCategorii)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();
            if (id != null)
            {
                BijuterieID = id.Value;
                Bijuterie bijuterie = BijuterieD.Bijuterii
                .Where(i => i.ID == id.Value).Single();
                BijuterieD.Categorii = bijuterie.BijuterieCategorii.Select(s => s.Categorie);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bradea_Simona_AplicatieWeb.Data;
using Bradea_Simona_AplicatieWeb.Models;

namespace Bradea_Simona_AplicatieWeb.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext _context;

        public IndexModel(Bradea_Simona_AplicatieWeb.Data.Bradea_Simona_AplicatieWebContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; }

        public async Task OnGetAsync()
        {
            Categorie = await _context.Categorie.ToListAsync();
        }
    }
}

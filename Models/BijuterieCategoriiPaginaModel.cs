using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bradea_Simona_AplicatieWeb.Data;

namespace Bradea_Simona_AplicatieWeb.Models
{
    public class BijuterieCategoriiPaginaModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Bradea_Simona_AplicatieWebContext context,
        Bijuterie bijuterie)
        {
            var allCategorii = context.Categorie;
            var bijuterieCategorii = new HashSet<int>(
            bijuterie.BijuterieCategorii.Select(c => c.BijuterieID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategorii)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Nume = cat.CategorieNume,
                    Atribuire = bijuterieCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateBijuterieCategorii(Bradea_Simona_AplicatieWebContext context,
        string[] selectedCategorii, Bijuterie bijuterieToUpdate)
        {
            if (selectedCategorii == null)
            {
                bijuterieToUpdate.BijuterieCategorii = new List<BijuterieCategorie>();
                return;
            }
            var selectedCategoriiHS = new HashSet<string>(selectedCategorii);
            var bijuterieCategorii = new HashSet<int>
            (bijuterieToUpdate.BijuterieCategorii.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriiHS.Contains(cat.ID.ToString()))
                {
                    if (!bijuterieCategorii.Contains(cat.ID))
                    {
                        bijuterieToUpdate.BijuterieCategorii.Add(
                        new BijuterieCategorie
                        {
                            BijuterieID = bijuterieToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bijuterieCategorii.Contains(cat.ID))
                    {
                        BijuterieCategorie courseToRemove = bijuterieToUpdate.BijuterieCategorii.SingleOrDefault(i => i.CategorieID == cat.ID); context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
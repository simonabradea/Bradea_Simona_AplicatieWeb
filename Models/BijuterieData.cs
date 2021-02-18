using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bradea_Simona_AplicatieWeb.Models
{
    public class BijuterieData
    {
        public IEnumerable<Bijuterie> Bijuterii { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<BijuterieCategorie> BijuterieCategorii { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bradea_Simona_AplicatieWeb.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string CategorieNume { get; set; }
        public ICollection<BijuterieCategorie> BijuterieCategorii { get; set; }
    }
}

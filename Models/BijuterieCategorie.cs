using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bradea_Simona_AplicatieWeb.Models
{
    public class BijuterieCategorie
    {
        public int ID { get; set; }
        public int BijuterieID { get; set; }
        public Bijuterie Bijuterie { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}

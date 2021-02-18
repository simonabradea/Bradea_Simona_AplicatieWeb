using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bradea_Simona_AplicatieWeb.Models
{
    public class Bijuterie
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Denumire Bijuterie")]
        public string Denumire { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$"), Required, StringLength(50, MinimumLength = 3)]
        public string Bijutier { get; set; }
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataVanzarii { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public ICollection<BijuterieCategorie> BijuterieCategorii { get; set; }
    }
}

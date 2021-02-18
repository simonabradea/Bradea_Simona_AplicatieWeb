using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bradea_Simona_AplicatieWeb.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string ClientNume { get; set; }
        public ICollection<Bijuterie> Bijuterii { get; set; }
    }
}

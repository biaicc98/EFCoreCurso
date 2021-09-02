using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legacy
{
    public partial class Battle
    {
        public Battle()
        {
            HeroesBattles = new HashSet<HeroesBattle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }

        public virtual ICollection<HeroesBattle> HeroesBattles { get; set; }
    }
}

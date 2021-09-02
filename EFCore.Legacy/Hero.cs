using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legacy
{
    public partial class Hero
    {
        public Hero()
        {
            HeroesBattles = new HashSet<HeroesBattle>();
            Weapons = new HashSet<Weapon>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual SecretId SecretId { get; set; }
        public virtual ICollection<HeroesBattle> HeroesBattles { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}

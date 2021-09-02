using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legacy
{
    public partial class HeroesBattle
    {
        public int HeroId { get; set; }
        public int BattleId { get; set; }

        public virtual Battle Battle { get; set; }
        public virtual Hero Hero { get; set; }
    }
}

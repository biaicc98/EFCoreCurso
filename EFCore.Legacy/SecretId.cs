using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legacy
{
    public partial class SecretId
    {
        public int Id { get; set; }
        public int RealName { get; set; }
        public int HeroId { get; set; }

        public virtual Hero Hero { get; set; }
    }
}

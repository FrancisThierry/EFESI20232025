using System;
using System.Collections.Generic;

namespace TDScaffoldOneToMany.Models
{
    public partial class Piece
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long FkVoitureId { get; set; }

        public virtual Voiture FkVoiture { get; set; } = null!;
    }
}

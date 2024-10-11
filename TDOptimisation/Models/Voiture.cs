using System;
using System.Collections.Generic;

namespace TDScaffoldOneToMany.Models
{
    public partial class Voiture
    {
        public Voiture()
        {
            Pieces = new HashSet<Piece>();
        }

        public long Id { get; set; }
        public string Modele { get; set; } = null!;

        public virtual ICollection<Piece> Pieces { get; set; }
    }
}

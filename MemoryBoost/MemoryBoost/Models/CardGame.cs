using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models
{
    public class CardGame
    {
        public Guid CardId { get; set; }
        public Card Card { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}

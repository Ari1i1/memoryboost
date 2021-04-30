using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models
{
    public class Card
    {
        public Guid Id { get; set; } = new Guid();
        public Guid? GameId { get; set; }
        public Game Game { get; set; }

    }
}

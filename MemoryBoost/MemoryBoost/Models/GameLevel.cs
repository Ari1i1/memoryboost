using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models
{
    public class GameLevel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 CardsNumber { get; set; }
        public Int32 SecForMemorizing { get; set; }
    }
}

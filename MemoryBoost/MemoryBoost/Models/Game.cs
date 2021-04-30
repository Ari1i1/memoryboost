using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models
{
    public class Game
    {
        public Guid Id { get; set; } = new Guid();
        public Int32 LevelId { get; set; }
        public GameLevel Level { get; set; }
        public String PlayerId { get; set; }
        public ApplicationUser Player { get; set; }
        public Int32? Score { get; set; }
        public ICollection<Card> Cards { get; set; }
        
    }
}

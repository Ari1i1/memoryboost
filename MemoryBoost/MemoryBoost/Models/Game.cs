using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models
{
    public class Game
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Int32 LevelId { get; set; }
        public GameLevel Level { get; set; }
        public String PlayerId { get; set; }
        public ApplicationUser Player { get; set; }
        public DateTime Created { get; set; }
        public Int32? Score { get; set; }
        public String Time { get; set; } = "00:00:00";
        public List<CardGame> Cards { get; set; }
    }
}

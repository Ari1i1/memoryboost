using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models.ViewModels
{
    public class GameViewModel
    {
        public Guid Id { get; set; } 
        public GameLevel Level { get; set; }
        public Int32? Score { get; set; }
        public String Time { get; set; } = "00:00:00";
        public List<Card> Cards { get; set; }
        public Training Training { get; set; }
        public Int32? NumInQueue { get; set; }
    }
}

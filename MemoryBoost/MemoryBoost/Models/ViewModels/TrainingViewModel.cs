using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models.ViewModels
{
    public class TrainingViewModel
    {
        public Guid Id { get; set; } 
        public String Name { get; set; }
        public List<Game> Games { get; set; }
    }
}

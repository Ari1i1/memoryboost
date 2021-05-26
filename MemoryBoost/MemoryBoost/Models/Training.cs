using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models
{
    public class Training
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(200)]
        public String Name { get; set; }
        public String PlayerId { get; set; }
        public ApplicationUser Player { get; set; }
        public DateTime Created { get; set; }
        public List<Game> Games { get; set; }
        public Int32? NumOfLevelOneGame { get; set; }
        public Int32? NumOfLevelTwoGame { get; set; }
        public Int32? NumOfLevelThreeGame { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models.ViewModels
{
    public class TrainingCreateViewModel
    {
        [Required]
        [MaxLength(200)]
        public String Name { get; set; }
        public Int32? NumOfLevelOneGame { get; set; }
        public Int32? NumOfLevelTwoGame { get; set; }
        public Int32? NumOfLevelThreeGame { get; set; }
    }
}

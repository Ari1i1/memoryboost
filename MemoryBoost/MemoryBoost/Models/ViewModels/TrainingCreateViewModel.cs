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
        [MaxLength(11)]
        public String Name { get; set; }
        [Required]
        [Range(0, 20)]
        public Int32? NumOfLevelOneGame { get; set; }
        [Required]
        [Range(0, 20)]
        public Int32? NumOfLevelTwoGame { get; set; }
        [Required]
        [Range(0, 20)]
        public Int32? NumOfLevelThreeGame { get; set; }
    }
}

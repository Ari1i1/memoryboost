using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models
{
    public class Card
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public String FilePath { get; set; }
        [Required]
        public String FileName { get; set; }
        public Int32? RandNum { get; set; }
        public List<CardGame> Games { get; set; }
    }
}

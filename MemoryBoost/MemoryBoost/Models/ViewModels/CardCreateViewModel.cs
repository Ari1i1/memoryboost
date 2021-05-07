using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Models.ViewModels
{
    public class CardCreateViewModel
    {
        public IFormFile FilePath { get; set; }
        public String FileName { get; set; }
    }
}

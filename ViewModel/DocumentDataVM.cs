using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.ViewModel
{
    public class DocumentDataVM
    {
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string DocPath { get; set; }
        public IFormFile file { get; set; }
    }
}

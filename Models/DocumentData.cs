using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Task1.Models

{
    public partial class DocumentData
    {
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string DocPath { get; set; }
        
        [NotMapped]
        public IFormFile file { get; set; }
    }
}

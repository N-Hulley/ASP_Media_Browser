using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class GenreDTO
    {
        [Key]
        public int? ID { get; set; } = null;
        [Required]
        public String Name { get; set; } = null;
    }
}
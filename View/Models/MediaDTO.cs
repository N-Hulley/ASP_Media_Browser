using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class MediaDTO
    {
        public String Title { get; set; }
        public String Genre { get; set; }
        public String Director { get; set; }
        public String Language { get; set; }
        public int GenreID { get; set; }
        public int DirectorID { get; set; }
        public int LanguageID { get; set; }
        public int Year { get; set; }
        public decimal BudgetValue { get; set; }


    }
}
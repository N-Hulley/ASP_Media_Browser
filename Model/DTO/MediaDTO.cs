using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MediaDTO
    {
        public int MediaID { get; set; }
        public String Title { get; set; }

        public GenreDTO Genre { get; set; }
        public DirectorDTO Director { get; set; }
        public LanguageDTO Language { get; set; }

        public int Year { get; set; }
        public decimal Budget { get; set; }

        public MediaDTO(int mediaID, string title, GenreDTO genre, DirectorDTO director, LanguageDTO language, int year, decimal budget)
        {
            MediaID = mediaID;
            Title = title;
            Genre = genre;
            Director = director;
            Language = language;
            Year = year;
            Budget = budget;
        }

    }
}

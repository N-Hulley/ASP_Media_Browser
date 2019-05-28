using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MediaDTO
    {
        public String Title { get; set; }

        public GenreDTO Genre { get; set; }
        public DirectorDTO Director { get; set; }
        public LanguageDTO Language { get; set; }

        public int Year { get; set; }
        public int Budget { get; set; }

        public MediaDTO(string title, GenreDTO genre, DirectorDTO director, LanguageDTO language, int year, int budget)
        {
            Title = title;
            Genre = genre;
            Director = director;
            Language = language;
            Year = year;
            Budget = budget;

        }
    }
}

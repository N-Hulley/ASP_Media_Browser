using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class MediaDTO
    {
        public String Title { get; set; }
        public GenreDTO Genre { get; set; }
        public DirectorDTO Director { get; set; }
        public LanguageDTO Language { get; set; }
        public int Year { get; set; }
        public String Budget { get; set; }
        public decimal BudgetValue { get; set; }

        /// <summary>
        /// Constructor function that copys a media row
        /// </summary>
        /// <param name="mediaRow"></param>
        public MediaDTO(Model.MediaDTO mediaRow)
        {
            Title = mediaRow.Title;
            Genre = new GenreDTO(mediaRow.Genre);
            Language = new LanguageDTO(mediaRow.Language);
            Director = new DirectorDTO(mediaRow.Director);
            Year = mediaRow.Year;
            BudgetValue = mediaRow.Budget * 1000000;

            if (mediaRow.Budget > 1)
            {
                Budget = (int)mediaRow.Budget + " Million";
            }
            else
            {
                Budget = (int)(mediaRow.Budget * 1000) + " Thousand";
            }
        }
    }
}

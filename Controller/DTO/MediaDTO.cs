using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class MediaDTO
    {
        public int MediaID { get; set; }
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
            MediaID = mediaRow.MediaID;
            Title = mediaRow.Title;
            Genre = new GenreDTO(mediaRow.Genre);
            Language = new LanguageDTO(mediaRow.Language);
            Director = new DirectorDTO(mediaRow.Director);
            Year = mediaRow.Year;
            this.SetBudget(mediaRow.Budget * 1000000);

        }

        public MediaDTO(string title, GenreDTO genre, DirectorDTO director, LanguageDTO language, int year, decimal budgetValue, int? mediaID = null)
        {
            if (mediaID != null) MediaID = (int)mediaID;
            Title = title;
            Genre = genre;
            Director = director;
            Language = language;
            Year = year;
            this.SetBudget(budgetValue);

        }

        public void SetBudget(decimal budget)
        {
            this.BudgetValue = budget;
            budget /= 1000000;
            if (budget > 1)
            {
                Budget = (int)budget + " Million";
            }
            else
            {
                Budget = (int)(budget * 1000) + " Thousand";
            }
        }
        public Model.MediaDTO Translate()
        {
            Model.MediaDTO Output = new Model.MediaDTO(
                this.MediaID,
                this.Title,
                this.Genre.Translate(),
                this.Director.Translate(),
                this.Language.Translate(),
                this.Year,
                this.BudgetValue / 1000000
                );

            return Output;

        }
    }
}

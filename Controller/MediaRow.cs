using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class MediaRow
    {
        public String Title { get; set; }
        public String Genre { get; set; }
        public String Director { get; set; }
        public String Language { get; set; }
        public int Year { get; set; }
        public String Budget { get; set; }
        public Decimal BudgetValue { get; set; }

        /// <summary>
        /// Constructor function that copys a media row
        /// </summary>
        /// <param name="mediaRow"></param>
        public MediaRow(Model.ModelDataSet.ViewMediaRow mediaRow)
        {
            Title = mediaRow.Title;
            Genre = mediaRow.GenreName;
            Director = mediaRow.DirectorName;
            Language = mediaRow.LanguageName;
            Year = mediaRow.PublishYear;
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

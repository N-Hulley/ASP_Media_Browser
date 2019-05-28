using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class SearchMediaManager : iSearchMediaManager
    {
        /// <summary>
        /// Makes a call to the model for any media matching the inputs.
        /// If inputs are null they are not included.
        /// Any media matching any input will be returned.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="director"></param>
        /// <param name="language"></param>
        /// <param name="year"></param>
        /// <param name="budgetLow"></param>
        /// <param name="budgetHigh"></param>
        /// <returns></returns>
        public IList<MediaDTO> MakeMediaQuery(String title, String genre, String director, String language, int? year ,decimal? budgetLow, decimal? budgetHigh)
        {
            // add % signs to all valid inputs so that the whole string is searched for
            if (title != null)
                title = "%" + title + "%";

            if (genre != null)
                genre = "%" + genre + "%";

            if (director != null)
                director = "%" + director + "%";

            if (language != null)
                language = "%" + language + "%";
            
            // Call the model to get matching media
            Model.ModelDataSet.ViewMediaDataTable MediaRows = new Model.ModelDataSet.ViewMediaDataTable();
            Model.ModelDataSetTableAdapters.ViewMediaTableAdapter Adapter = new Model.ModelDataSetTableAdapters.ViewMediaTableAdapter();
            Model.ModelDataSet.ViewMediaDataTable MediaData;

            MediaData = Adapter.ViewMediaByCriteria(title, genre, director, language, year, budgetLow, budgetHigh);

            // Convert the output to a useable media row.
            IList<MediaDTO> Output = new List<MediaDTO>();
            for (int i = 0; i < MediaData.Count; i++)
            {
                Output.Add(new MediaDTO(MediaData[i]));
            }
            return Output;
        }
        public IList<MediaDTO> MakeMediaQuery()
        {
            
            // Call the model to get matching media
            Model.ModelDataSet.ViewMediaDataTable MediaRows = new Model.ModelDataSet.ViewMediaDataTable();
            Model.ModelDataSetTableAdapters.ViewMediaTableAdapter Adapter = new Model.ModelDataSetTableAdapters.ViewMediaTableAdapter();
            Model.ModelDataSet.ViewMediaDataTable MediaData;

            //MediaData = Adapter.ViewMediaByCriteria(title, genre, director, language, year, budgetLow, budgetHigh);

            // Convert the output to a useable media row.
            IList<MediaDTO> Output = new List<MediaDTO>();
            /*for (int i = 0; i < MediaData.Count; i++)
            {
                Output.Add(new MediaRow(MediaData[i]));
            }*/
            return Output;
        }
    }
}

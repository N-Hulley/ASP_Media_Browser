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
            IList<MediaDTO> Output = new List<MediaDTO>();

            Model.IManageMediaRecords RecordManager = new Model.ManageMediaRecordsImp();
            IList<Model.MediaDTO> results = RecordManager.Search(title, genre, director, language, year);

            // Convert the output to a useable media row.
            for (int i = 0; i < results.Count; i++)
            {
                Output.Add(new MediaDTO(results[i]));
            }
            return Output;
        }
        public IList<MediaDTO> MakeMediaQuery()
        {
            
            // Call the model to get matching media

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

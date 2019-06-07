using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class SearchMediaManager : iSearchMediaManager
    {
        Model.IManageMediaRecords RecordManager = new Model.ManageMediaRecordsImp();
        Model.IManageUserRecords UserManager = new Model.ManageUserRecordsImp();
        public MediaDTO ChangeMedia(MediaDTO media, string field, object newValue)
        {
            if (field == "Title" && newValue is string)
            {
                RecordManager.ChangeRecord(media.Translate(), field, newValue);
                media.Title = ((string)newValue);
            }
            if (field == "Genre" && newValue is int)
            {
                RecordManager.ChangeRecord(media.Translate(), field, newValue);
                media.Genre.GID = ((int)newValue);
            }
            if (field == "Director" && newValue is int)
            {
                RecordManager.ChangeRecord(media.Translate(), field, newValue);
                media.Director.DID = ((int)newValue);
            }
            if (field == "Language" && newValue is int)
            {
                RecordManager.ChangeRecord(media.Translate(), field, newValue);
                media.Language.LID = ((int)newValue);
            }
            if (field == "Year" && newValue is int)
            {
                RecordManager.ChangeRecord(media.Translate(), field, newValue);
                media.Year = ((int)newValue);
            }
            if (field == "Budget" && newValue is decimal)
            {
                RecordManager.ChangeRecord(media.Translate(), field, (decimal)newValue / 1000000);
                media.SetBudget((decimal)newValue);
            }
            return media;
        }

        public MediaDTO CreateMedia(MediaDTO mediaInput)
        {
            return new MediaDTO(RecordManager.AddRecord(mediaInput.Translate()));
        }

        public bool DeleteMedia(MediaDTO mediaInput)
        {
            return RecordManager.DeleteRecord(mediaInput.Translate());
        }

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
        public IList<MediaDTO> MakeMediaQuery(
            String title = null,
            String genre = null,
            String director = null,
            String language = null,
            int? year = null)
        {
            IList<MediaDTO> Output = new List<MediaDTO>();

            IList<Model.MediaDTO> results = RecordManager.Search(title, genre, director, language, year);

            // Convert the output to a useable media row.
            for (int i = 0; i < results.Count; i++)
            {
                Output.Add(new MediaDTO(results[i]));
            }
            return Output;
        }
       
    }
}

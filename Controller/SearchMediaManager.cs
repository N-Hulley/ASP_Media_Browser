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
        const int AdminLevel = 3;
        private readonly Model.IManageMediaRecords RecordManager = new Model.ManageMediaRecordsImp();
        private readonly Model.IManageUserRecords UserManager = new Model.ManageUserRecordsImp();


        public int AddDirector(string name)
        {
            return RecordManager.AddDirector(name);
        }

        public int AddGenere(string name)
        {
            return RecordManager.AddGenre(name);
        }

        public int AddLanguage(string name)
        {
            return RecordManager.AddLanguage(name);
        }

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

        public bool DeleteDirector(int iD)
        {
            return RecordManager.DeleteDirector(iD);
        }

        public bool DeleteGenre(int iD)
        {
            return RecordManager.DeleteGenre(iD);
        }

        public bool DeleteLanguage(int iD)
        {
            return RecordManager.DeleteLanguage(iD);
        }

        public bool DeleteMedia( MediaDTO mediaInput)
        {
            if (mediaInput != null)
                return RecordManager.DeleteRecord(mediaInput.Translate());
            return false;
        }

        public MediaDTO FindByID(int iD)
        {
            return new MediaDTO(RecordManager.FindByID(iD));

        }

        public IList<DirectorDTO> GetDirectors(int? iD = null)
        {
            IList<Model.DirectorDTO> response = (RecordManager.GetDirectors(iD));
            IList<DirectorDTO> translated = new List<DirectorDTO>();
            for (int i = 0; i < response.Count; i++)
            {
                translated.Add(new DirectorDTO(response[i]));
            }
            return translated;
        }

        public IList<GenreDTO> GetGenres(int? iD = null)
        {
            IList<Model.GenreDTO> response = (RecordManager.GetGenres(iD));
            IList<GenreDTO> translated = new List<GenreDTO>();
            for (int i = 0; i < response.Count; i++)
            {
                translated.Add(new GenreDTO(response[i]));
            }
            return translated;
        }

        public IList<LanguageDTO> GetLanguages(int? iD = null)
        {
            IList<Model.LanguageDTO> response = (RecordManager.GetLanguages(iD));
            IList<LanguageDTO> translated = new List<LanguageDTO>();
            for (int i = 0; i < response.Count; i++)
            {
                translated.Add(new LanguageDTO(response[i]));
            }
            return translated;
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ManageMediaRecordsImp : IManageMediaRecords
    {
        private readonly static string table = "TabMedia";
        private readonly static string director = "TabDirector";
        private readonly static string genre = "TabGenre";
        private readonly static string language = "TabLanguage";
        private readonly static string view = "ViewMedia";
        public MediaDTO AddRecord(MediaDTO record)
        {
            IDictionary<string, object> values = new Dictionary<string, object>();

            values["Title"] = record.Title;
            values["Genre"] = record.Genre.GID;
            values["Director"] = record.Director.DID;
            values["Language"] = record.Language.LID;
            values["PublishYear"] = record.Year;
            values["Budget"] = record.Budget;

            record.MediaID = CrudFunctions.Create("MediaID", values, table);
            return record;
        }

        public bool ChangeRecord(MediaDTO record, string Field, object Value)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();

            conditions["MediaID"] = record.MediaID;

            CrudFunctions.UpdateField(table, Field, Value, conditions);
            return true;
        }

        public bool DeleteRecord(MediaDTO record)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();

            conditions["MediaID"] = record.MediaID;

            return CrudFunctions.Delete(table, conditions) > 0;

        }

        public MediaDTO FindByID(int iD)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();

            conditions["MediaID"] = iD;

            IList<MediaDTO> results = Translate(CrudFunctions.Read(view, conditions));
            return results[0];
        }

        public IList<DirectorDTO> GetDirectors(int? iD = null)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();

            if (iD != null) { conditions["DID"] = iD; } else { conditions["1"] = 1; }

            return (IList<DirectorDTO>)TranslateDirector(CrudFunctions.Read(director, conditions));
        }

        public IList<GenreDTO> GetGenres(int? iD = null)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();

            if (iD != null) { conditions["GID"] = iD; } else { conditions["1"] = 1; }

            return (IList<GenreDTO>)TranslateGenre(CrudFunctions.Read(genre, conditions));
        }

        public IList<LanguageDTO> GetLanguages(int? iD = null)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();

            if (iD != null) { conditions["LID"] = iD; } else { conditions["1"] = 1; }

            return (IList<LanguageDTO>)TranslateLanguage(CrudFunctions.Read(language, conditions));
        }

        public IList<MediaDTO> Search()
        {
            throw new NotImplementedException();
        }

        public IList<MediaDTO> Search(string title = null, string genre = null, string director = null, string language = null, int? year = null)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();

            if (title != null)
                conditions["Title"] = title;
            if (genre != null)
                conditions["GenreName"] = genre;
            if (director != null)
                conditions["DirectorName"] = director;
            if (language != null)
                conditions["LanguageName"] = language;
            if (year != null)
                if (year > 0)
                    conditions["PublishYear"] = year;

            return Translate(CrudFunctions.Read(view, conditions, true));
        }
        IList<GenreDTO> TranslateGenre(DataTable records) { IList<GenreDTO> DTOs = new List<GenreDTO>(); foreach (DataRow row in records.Rows) DTOs.Add(TranslateGenre(row));return DTOs; }
        IList<DirectorDTO> TranslateDirector(DataTable records) { IList<DirectorDTO> DTOs = new List<DirectorDTO>(); foreach (DataRow row in records.Rows) DTOs.Add(TranslateDirector(row)); return DTOs; }
        IList<LanguageDTO> TranslateLanguage(DataTable records) { IList<LanguageDTO> DTOs = new List<LanguageDTO>(); foreach (DataRow row in records.Rows) DTOs.Add(TranslateLanguage(row)); return DTOs; }

        GenreDTO TranslateGenre(DataRow record){return new GenreDTO(record.Field<int>("GID"), record.Field<string>("GenreName"));}
        DirectorDTO TranslateDirector(DataRow record) { return new DirectorDTO(record.Field<int>("DID"), record.Field<string>("DirectorName")); }
        LanguageDTO TranslateLanguage(DataRow record) { return new LanguageDTO(record.Field<int>("LID"), record.Field<string>("LanguageName")); }


        IList<MediaDTO> Translate(DataTable records)
        {
            IList<MediaDTO> DTOs = new List<MediaDTO>();
            foreach (DataRow row in records.Rows)
            {
                DTOs.Add(Translate(row));
            }
            return DTOs;
        }
        MediaDTO Translate(DataRow record)
        {
            GenreDTO Genre = new GenreDTO(record.Field<int>("Genre"), record.Field<string>("GenreName"));
            LanguageDTO Language = new LanguageDTO(record.Field<int>("Language"), record.Field<string>("LanguageName"));
            DirectorDTO Director = new DirectorDTO(record.Field<int>("Director"), record.Field<string>("DirectorName"));
            return new MediaDTO(
                record.Field<int>("MediaID"),
                record.Field<string>("Title"),
                Genre, Director, Language,
                record.Field<int>("PublishYear"),
                record.Field<decimal>("Budget")
            ); ;
        }

        public bool DeleteDirector(int iD)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();
            conditions["DID"] = iD;
            return CrudFunctions.Delete(director, conditions) > 0;
        }

        public bool DeleteLanguage(int iD)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();
            conditions["LID"] = iD;
            return CrudFunctions.Delete(language, conditions) > 0;
        }

        public bool DeleteGenre(int iD)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();
            conditions["GID"] = iD;
            return CrudFunctions.Delete(genre, conditions) > 0;
        }

        public int AddDirector(string name)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();
            conditions["DirectorName"] = name;
            return CrudFunctions.Create("DID", conditions, director);
        }

        public int AddLanguage(string name)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();
            conditions["LanguageName"] = name;
            return CrudFunctions.Create("LID", conditions, language);
        }

        public int AddGenre(string name)
        {
            IDictionary<string, object> conditions = new Dictionary<string, object>();
            conditions["GenreName"] = name;
            return CrudFunctions.Create("GID", conditions, genre);
        }
    }
}

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
        private static string table = "TabMedia";
        private static string view = "ViewMedia";
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
                conditions["PublishYear"] = year;

            return Translate(CrudFunctions.Read(view, conditions, true));
        }

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
                record.Field<string>("Title"), 
                Genre, Director, Language,
                record.Field<int>("PublishYear"), 
                record.Field<decimal>("Budget")
            );
        }
    }
}

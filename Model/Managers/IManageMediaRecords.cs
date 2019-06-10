using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IManageMediaRecords
    {
        MediaDTO AddRecord(MediaDTO record);
        IList<MediaDTO> Search();
        bool ChangeRecord(MediaDTO record, string Field, object Value);
        MediaDTO FindByID(int iD);
        IList<MediaDTO> Search
        (
            String title = null,
            String genre = null,
            String director = null,
            String language = null,
            int? year = null
        );
        bool DeleteRecord(MediaDTO record);

        IList<GenreDTO> GetGenres(int? iD = null);
        IList<DirectorDTO> GetDirectors(int? iD = null);
        IList<LanguageDTO> GetLanguages(int? iD = null);
        bool DeleteDirector(int iD);
        bool DeleteLanguage(int iD);
        bool DeleteGenre(int iD);

        int AddDirector(string name);
        int AddLanguage(string name);
        int AddGenre(string name);

    }
}

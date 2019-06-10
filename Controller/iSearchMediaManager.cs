using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public interface iSearchMediaManager
    {
        IList<MediaDTO> MakeMediaQuery
        (
            String title = null,
            String genre = null,
            String director = null,
            String language = null,
            int? year = null
        );

        MediaDTO ChangeMedia(MediaDTO newMedia, string field, object value);
        bool DeleteMedia( MediaDTO mediaInput);
        MediaDTO CreateMedia(MediaDTO mediaInput);
        MediaDTO FindByID(int iD);


        IList<GenreDTO> GetGenres(int? iD = null);
        IList<DirectorDTO> GetDirectors(int? iD = null);
        IList<LanguageDTO> GetLanguages(int? iD = null);


        bool DeleteDirector(int iD);
        bool DeleteLanguage(int iD);
        bool DeleteGenre(int iD);

        int AddDirector(string name);
        int AddLanguage(string name);
        int AddGenere(string name);
    }
}

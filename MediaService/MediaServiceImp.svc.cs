using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MediaBrowserWSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MediaServiceImp : IMediaService
    {
        public MediaWSDTO AddMedia(MediaWSDTO media)
        {
            throw new NotImplementedException();
        }

        public IList<MediaWSDTO> MakeQuery(string title = null, string genre = null, string director = null, string language = null, int? year = null)
        {
            ControllerLayer.iSearchMediaManager manager = new ControllerLayer.SearchMediaManager();
            return Translate(manager.MakeMediaQuery(title, genre, director, language, year));
        }

        public MediaWSDTO ValidateUser(MediaWSDTO media)
        {
            throw new NotImplementedException();
        }
        public ControllerLayer.MediaDTO Translate(MediaWSDTO media)
        {
            return null;
        }
        public MediaWSDTO Translate(ControllerLayer.MediaDTO media)
        {
            MediaWSDTO Output = new MediaWSDTO();
            Output.Budget = media.Budget;
            Output.BudgetValue = media.BudgetValue;
            Output.Director = Translate(media.Director);
            Output.Genre = Translate(media.Genre);
            Output.Language = Translate(media.Language);
            Output.MediaID = media.MediaID;
            Output.Year = media.Year;
            return Output;
        }
        public IList<MediaWSDTO> Translate(IList<ControllerLayer.MediaDTO> media)
        {
            IList<MediaWSDTO> Output = new List<MediaWSDTO>();
            for (int i = 0; i < media.Count; i++)
            {
                Output.Add(Translate(media[i]));
            }
            return Output;
        }





        public DirectorWSDTO Translate(ControllerLayer.DirectorDTO director)
        {
            DirectorWSDTO Output = new DirectorWSDTO();
            Output.DID = director.DID;
            Output.DirectorName = director.DirectorName;
            return Output;
        }
        public GenreWSDTO Translate(ControllerLayer.GenreDTO genre)
        {
            GenreWSDTO Output = new GenreWSDTO();
            Output.GID = genre.GID;
            Output.GenreTitle = genre.GenreName;
            return Output;
        }
        public LanguageWSDTO Translate(ControllerLayer.LanguageDTO director)
        {
            LanguageWSDTO Output = new LanguageWSDTO();
            Output.LID = director.LID;
            Output.LanguageName = director.LanguageName;
            return Output;
        }
    }
}

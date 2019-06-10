using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using UserWSService;

namespace MediaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MediaServiceImp : IMediaService
    {
        private readonly UserWSService.IUserLoginService UserManager = new UserWSService.UserLoginServiceImp();
        private readonly ControllerLayer.iSearchMediaManager Manager = new ControllerLayer.SearchMediaManager();

        private const int AdminLevel = 3;
        public MediaWSDTO AddMedia(UserWSService.UserWSDTO user, MediaWSDTO media)
        {
            if (user.IsValid && user.UserLevel >= AdminLevel)
            {
                if (
                    media.Genre != null &&
                    media.Genre.GID != null &&
                    media.Title != null && 
                    media.Year != null &&
                    media.Language != null &&
                    media.Language.LID != null &&
                    media.Director != null && 
                    media.Director.DID != null &&
                    media.BudgetValue != null
                    )
                {
                    return Translate(Manager.CreateMedia(Translate(media))); 
                } else
                {
                    throw new System.Web.HttpRequestValidationException("Not enough information given");

                }
            } else
            {
                throw new System.Web.HttpRequestValidationException("Invalid user");
            }
        }

        public bool DeleteMedia(UserWSDTO user, MediaWSDTO media)
        {
            if (user.IsValid && user.UserLevel >= AdminLevel)
                return Manager.DeleteMedia(Translate(media));
            else
                throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public MediaWSDTO getMediaByID(UserWSDTO user, int iD)
        {
            if (user.IsValid && user.UserLevel >= AdminLevel)
                return Translate(Manager.FindByID(iD));
            else
                throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public IList<MediaWSDTO> MakeQuery(UserWSService.UserWSDTO user, string title = null, string genre = null, string director = null, string language = null, int? year = null)
        {
            if (user.IsValid)
                return Translate(Manager.MakeMediaQuery(title, genre, director, language, year));
            else
                throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public ControllerLayer.MediaDTO Translate(MediaWSDTO media)
        {
            if (media.Title != null && media.BudgetValue != null && media.Director != null && media.Genre != null && media.Language != null && media.Year != null)
                return new ControllerLayer.MediaDTO(
                    media.Title,
                    Translate(media.Genre),
                    Translate(media.Director),
                    Translate(media.Language),
                    media.Year,
                    media.BudgetValue,
                    media.MediaID
                    );

            throw new System.Web.HttpRequestValidationException("Invalid media given");
        }
        public ControllerLayer.LanguageDTO Translate(LanguageWSDTO language) {
            if (language.LID != null || language.LanguageName != null)
                return new ControllerLayer.LanguageDTO((int)language.LID, language.LanguageName);

            throw new System.Web.HttpRequestValidationException("Invalid Language");
        }
        public ControllerLayer.GenreDTO Translate(GenreWSDTO Genre)
        {
            if (Genre.GID != null || Genre.GenreTitle != null)
                return new ControllerLayer.GenreDTO((int)Genre.GID, Genre.GenreTitle);

            throw new System.Web.HttpRequestValidationException("Invalid Genre");
        }
        public ControllerLayer.DirectorDTO Translate(DirectorWSDTO Director)
        {
            if (Director.DID != null || Director.DirectorName != null)
                return new ControllerLayer.DirectorDTO((int)Director.DID, Director.DirectorName);

            throw new System.Web.HttpRequestValidationException("Invalid Director");
        }
        public MediaWSDTO Translate(ControllerLayer.MediaDTO media)
        {
            MediaWSDTO Output = new MediaWSDTO();
            Output.Title = media.Title;
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

        public IList<GenreWSDTO> GetGenres(UserWSDTO user, int? iD = null)
        {
            if (user.IsValid)
            {
                IList<ControllerLayer.GenreDTO> response = (Manager.GetGenres(iD));
                IList<GenreWSDTO> result = new List<GenreWSDTO>();
                for (int i = 0; i < response.Count; i++)
                {
                    result.Add(Translate(response[i]));
                }
                return result;
            }
            throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public IList<DirectorWSDTO> GetDirectors(UserWSDTO user, int? iD = null)
        {
            if (user.IsValid)
            {
                IList<ControllerLayer.DirectorDTO> response = (Manager.GetDirectors(iD));
                IList<DirectorWSDTO> result = new List<DirectorWSDTO>();
                for (int i = 0; i < response.Count; i++)
                {
                    result.Add(Translate(response[i]));
                }
                return result;
            }
            throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public IList<LanguageWSDTO> GetLanguages(UserWSDTO user, int? iD = null)
        {

            if (user.IsValid)
            {
                IList<ControllerLayer.LanguageDTO> response = (Manager.GetLanguages(iD));
                IList<LanguageWSDTO> result = new List<LanguageWSDTO>();
                for (int i = 0; i < response.Count; i++)
                {
                    result.Add(Translate(response[i]));
                }
                return result;
            }
            throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public bool DeleteDirector(UserWSDTO user, int iD)
        {
            if (user.IsValid && user.UserLevel >= AdminLevel)
            {
                return Manager.DeleteDirector(iD);
            }
            throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public bool DeleteLanguage(UserWSDTO user, int iD)
        {
            if (user.IsValid && user.UserLevel >= AdminLevel)
            {
                return Manager.DeleteLanguage(iD);
            }
            throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public bool DeleteGenre(UserWSDTO user, int iD)
        {
            if (user.IsValid && user.UserLevel >= AdminLevel)
            {
                return Manager.DeleteGenre(iD);
            }
            throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public int AddDirector(UserWSDTO user, string name)
        {
            if (user.IsValid && user.UserLevel >= AdminLevel)
            {
                return Manager.AddDirector(name);
            }
            throw new System.Web.HttpRequestValidationException("Invalid user");

        }

        public int AddLanguage(UserWSDTO user, string name)
        {
            if (user.IsValid && user.UserLevel >= AdminLevel)
            {
                return Manager.AddLanguage(name);
            }
            throw new System.Web.HttpRequestValidationException("Invalid user");
        }

        public int AddGenre(UserWSDTO user, string name)
        {
            if (user.IsValid && user.UserLevel >= AdminLevel)
            {
                return Manager.AddGenere(name);
            }
            throw new System.Web.HttpRequestValidationException("Invalid user");
        }
    }
}

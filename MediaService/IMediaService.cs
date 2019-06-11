using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MediaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMediaService
    {
        
        /// <summary>
        /// Add a given piece of media into the database, requires a user for verification and security
        /// </summary>
        /// <param name="user"></param>
        /// <param name="media"></param>
        /// <returns>The new media</returns>
        [OperationContract]
        MediaWSDTO AddMedia(UserWSService.UserWSDTO user, MediaWSDTO media);
        /// <summary>
        /// Delete a piece of media from the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="media"></param>
        /// <returns>true if successful</returns>
        [OperationContract]
        bool DeleteMedia(UserWSService.UserWSDTO user, MediaWSDTO media);

        /// <summary>
        /// Makes a query to the database with the given parameters
        /// </summary>
        /// <param name="user">Required for verification</param>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="director"></param>
        /// <param name="language"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [OperationContract]
        IList<MediaWSDTO> MakeQuery(UserWSService.UserWSDTO user, string title = null, string genre = null, string director = null, string language = null, int? year = null);

        /// <summary>
        /// Get media with a certain id from the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="iD"></param>
        /// <returns></returns>
        [OperationContract]
        MediaWSDTO getMediaByID(UserWSService.UserWSDTO user, int iD);

        /// <summary>
        /// Query the database for Genres, Directors, Languages
        /// </summary>
        /// <param name="user"></param>
        /// <param name="iD"></param>
        /// <returns></returns>
        [OperationContract]
        IList<GenreWSDTO> GetGenres(UserWSService.UserWSDTO user, int? iD = null);
        [OperationContract]
        IList<DirectorWSDTO> GetDirectors(UserWSService.UserWSDTO user, int? iD = null);
        [OperationContract]
        IList<LanguageWSDTO> GetLanguages(UserWSService.UserWSDTO user, int? iD = null);

        /// <summary>
        /// Delete a director, language or genre from the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="iD"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteDirector(UserWSService.UserWSDTO user, int iD);
        [OperationContract]
        bool DeleteLanguage(UserWSService.UserWSDTO user, int iD);
        [OperationContract]
        bool DeleteGenre(UserWSService.UserWSDTO user, int iD);

        /// <summary>
        /// Add a director, genre or language to the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract]
        int AddDirector(UserWSService.UserWSDTO user, string name);
        [OperationContract]
        int AddLanguage(UserWSService.UserWSDTO user, string name);
        [OperationContract]
        int AddGenre(UserWSService.UserWSDTO user, string name);


        [OperationContract]
        int AddBorrowed(UserWSService.UserWSDTO user, BorrowDTO record); 
        [OperationContract]
        int AddReserved(UserWSService.UserWSDTO user, ReserveDTO record);

        [OperationContract]
        IList<BorrowDTO> GetBorrowed(UserWSService.UserWSDTO user, int? bID = null, int? uID = null, int? MediaID = null);
        [OperationContract]
        IList<ReserveDTO> GetReserved(UserWSService.UserWSDTO user, int? rID = null, int? uID = null, int? MediaID = null);

        [OperationContract]
        bool DeleteBorrowed(UserWSService.UserWSDTO user, int? iD);
        [OperationContract]
        bool DeleteReserve(UserWSService.UserWSDTO user, int? iD);


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]

    public class DirectorWSDTO
    {
        bool isValid = false;
        int? dID = null;
        string directorName = null;

        [DataMember]
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        [DataMember]
        public string DirectorName
        {
            get { return directorName; }
            set { directorName = value; }
        }

        [DataMember]
        public int? DID
        {
            get { return dID; }
            set { dID = value; }
        }


    }
    public class GenreWSDTO
    {
        bool isValid = false;
        int? gID = null;
        string genreTitle = null;


        [DataMember]
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        [DataMember]
        public string GenreTitle
        {
            get { return genreTitle; }
            set { genreTitle = value; }
        }

        [DataMember]
        public int? GID
        {
            get { return gID; }
            set { gID = value; }
        }


    }

    public class LanguageWSDTO
    {
        bool isValid = false;
        int? lID = null;
        string languageName = null;


        [DataMember]
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        [DataMember]
        public string LanguageName
        {
            get { return languageName; }
            set { languageName = value; }
        }

        [DataMember]
        public int? LID
        {
            get { return lID; }
            set { lID = value; }
        }


    }
    public class MediaWSDTO
    {
        bool isValid = false;
        private int mediaID;
        GenreWSDTO genre = null;
        DirectorWSDTO director = null;
        LanguageWSDTO language = null;
        private string title;
        private string budget;
        private decimal budgetValue;
        private int year;

        [DataMember]
        public bool IsValid
        {
            get
            {
                return isValid;
            }

            set
            {
                isValid = value;
            }
        }

        [DataMember]
        public int MediaID
        {
            get
            {
                return mediaID;
            }

            set
            {
                mediaID = value;
            }
        }

        [DataMember]
        public GenreWSDTO Genre
        {
            get
            {
                return genre;
            }

            set
            {
                genre = value;
            }
        }

        [DataMember]
        public DirectorWSDTO Director
        {
            get
            {
                return director;
            }

            set
            {
                director = value;
            }
        }

        [DataMember]
        public LanguageWSDTO Language
        {
            get
            {
                return language;
            }

            set
            {
                language = value;
            }
        }

        [DataMember]
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        [DataMember]
        public string Budget
        {
            get
            {
                return budget;
            }

            set
            {
                budget = value;
            }
        }

        [DataMember]
        public decimal BudgetValue
        {
            get
            {
                return budgetValue;
            }

            set
            {
                budgetValue = value;
            }
        }

        [DataMember]
        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }
    }
    public class BorrowDTO
    {
        int? bID = null;
        int? uID = null;
        int? mediaID = null;
        DateTime? borrowDate = null;
        DateTime? returnDate = null;
        DateTime? actualReturnDate = null;
        decimal? lateFee = null;

        [DataMember]
        public int? BID
        {
            get
            {
                return bID;
            }

            set
            {
                bID = value;
            }
        }

        [DataMember]
        public int? UID
        {
            get
            {
                return uID;
            }

            set
            {
                uID = value;
            }
        }

        [DataMember]
        public int? MediaID
        {
            get
            {
                return mediaID;
            }

            set
            {
                mediaID = value;
            }
        }

        [DataMember]
        public DateTime? BorrowDate
        {
            get
            {
                return borrowDate;
            }

            set
            {
                borrowDate = value;
            }
        }

        [DataMember]
        public DateTime? ReturnDate
        {
            get
            {
                return returnDate;
            }

            set
            {
                returnDate = value;
            }
        }

        [DataMember]
        public DateTime? ActualReturnDate
        {
            get
            {
                return actualReturnDate;
            }

            set
            {
                actualReturnDate = value;
            }
        }

        [DataMember]
        public decimal? LateFee
        {
            get
            {
                return lateFee;
            }

            set
            {
                lateFee = value;
            }
        }
    }
    public class ReserveDTO
    {
        int? rID = null;
        int? uID = null;
        int? mediaID = null;
        DateTime? reservedDate = null;

        [DataMember]
        public int? RID
        {
            get
            {
                return rID;
            }

            set
            {
                rID = value;
            }
        }

        [DataMember]
        public int? UID
        {
            get
            {
                return uID;
            }

            set
            {
                uID = value;
            }
        }

        [DataMember]
        public int? MediaID
        {
            get
            {
                return mediaID;
            }

            set
            {
                mediaID = value;
            }
        }

        public DateTime? ReservedDate
        {
            get
            {
                return reservedDate;
            }

            set
            {
                reservedDate = value;
            }
        }
    }
}

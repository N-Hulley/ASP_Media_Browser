using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MediaBrowserWSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMediaService
    {


        [OperationContract]
        MediaWSDTO AddMedia(MediaWSDTO media);
        IList<MediaWSDTO> MakeQuery(string title = null, string genre = null, string director = null, string language = null, int? year = null);


        // TODO: Add your service operations here
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
        public string Title { get => title; set => title = value; }
        [DataMember]
        public int Year { get => year; set => year = value; }
        [DataMember]
        public string Budget { get => budget; set => budget = value; }
        [DataMember]
        public decimal BudgetValue { get => budgetValue; set => budgetValue = value; }
        [DataMember]
        public int MediaID { get => mediaID; set => mediaID = value; }



        [DataMember]
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        [DataMember]
        public GenreWSDTO Genre { get => genre; set => genre = value; }
        [DataMember]
        public DirectorWSDTO Director { get => director; set => director = value; }
        [DataMember]
        public LanguageWSDTO Language { get => language; set => language = value; }


    }
}

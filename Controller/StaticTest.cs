using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class StaticTest
    {
        public static void login()
        {
            iUserManager RecordManager = new UserManagerImp();

            UserDTO newUser = RecordManager.ValidateUser("admin", "Hello1");
            

        }
        public static void updateTable()
        {

            Model.DirectorDTO director = new Model.DirectorDTO(3, "Sam");
            Model.GenreDTO genre = new Model.GenreDTO(3, "Action");
            Model.LanguageDTO language = new Model.LanguageDTO(3, "French");

            Model.MediaDTO test = new Model.MediaDTO("ABCD",genre, director, language, 2000, 100);

            Model.IManageMediaRecords RecordManager = new Model.ManageMediaRecordsImp();
            RecordManager.AddRecord(test);
            

        }

    }
}

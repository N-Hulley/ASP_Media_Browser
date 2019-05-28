using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class StaticTest
    {
        public static void updateTable()
        {
            //Model.CrudFunctions.UpdateField("TabUser", "Password", "Hello1", "UID", 3);

            Model.MediaDTO test = new Model.MediaDTO("TestMovie", "", 3, "", 3, "", 3, 2000, 100);
            Model.CrudFunctions.Create(test);
        }

    }
}

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
            Model.CrudFunctions<string, int>.UpdateField("TabUser", "Password", "Hello1", "UID", 3);
        }

    }
}

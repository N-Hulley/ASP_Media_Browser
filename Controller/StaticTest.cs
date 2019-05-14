using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class StaticTest
    {
        public static string ToHex(int value)
        {
            return String.Format("{0:X}", value);
        }
        public static String Test { get; set; } = "asdasdasd";

    }
}

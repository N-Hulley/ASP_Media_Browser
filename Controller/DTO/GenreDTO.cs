using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class GenreDTO
    {
        public int GID { get; set; }
        public string GenreName { get; set; }
        public GenreDTO(Model.GenreDTO director)
        {
            GID = director.GID;
            GenreName = director.GenreName;
        }
        public GenreDTO(int gID, string genreName)
        {
            GID = gID;
            GenreName = genreName;
        }
        public GenreDTO(string genreName)
        {
            GenreName = genreName;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GenreDTO
    {
        public int GID { get; set; }
        public string GenreName { get; set; }

        public GenreDTO(int gID, string genreName)
        {
            GID = gID;
            GenreName = genreName;
        }

    }
}

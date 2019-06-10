using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GenreDTO : GenericDTO
    {
        public int GID { get => ID; set => ID = value; }
        public string GenreName { get => Name; set => Name = value; }

        public GenreDTO(int gID, string genreName) : base(gID, genreName)
        {}
        public GenreDTO(string genreName) : base(genreName)
        {}

    }
}

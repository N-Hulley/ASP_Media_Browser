using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class DirectorDTO
    {
        public DirectorDTO(int dID, string directorName)
        {
            DID = dID;
            DirectorName = directorName;
        }
        public DirectorDTO(string directorName)
        {
            DirectorName = directorName;
        }
        public DirectorDTO(Model.DirectorDTO director)
        {
            DID = director.DID;
            DirectorName = director.DirectorName;
        }
        public int DID { get; set; }
        public string DirectorName { get; set; }
    }
}

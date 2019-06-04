using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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
        public int DID { get; set; }
        public string DirectorName { get; set; }
    }
}

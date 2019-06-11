using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DirectorDTO : GenericDTO
    {
        public DirectorDTO(string directorName) : base(directorName)
        {}
        
        public DirectorDTO(int dID, string directorName) : base(dID, directorName)
        {}
        
        public string DirectorName
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        public int DID
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }
    }
}

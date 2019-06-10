using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class GenericDTO
    {
        protected int ID;
        protected string Name;

        public GenericDTO(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public GenericDTO(string name)
        {
            this.Name = name;
        }
        
    }
}

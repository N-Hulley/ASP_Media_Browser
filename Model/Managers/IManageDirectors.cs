using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IManageDirectors
    {
        DirectorDTO Add(DirectorDTO record);
        DirectorDTO change(DirectorDTO record, string Field, string Value);
        DirectorDTO read();
    }
}

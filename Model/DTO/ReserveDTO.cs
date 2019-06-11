using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReserveDTO
    {
        public int RID { get; set; }
        public int UID { get; set; }
        public int MediaID { get; set; }
        public DateTime ReservedDate { get; set; }
    }
}

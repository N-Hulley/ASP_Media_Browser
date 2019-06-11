using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class ReserveDTO
    {
        public ReserveDTO(int? uID, int? mediaID, DateTime? reservedDate)
        {
            try
            {
                UID = (int)uID;
                MediaID = (int)mediaID;
                ReservedDate = (DateTime)reservedDate;
            } catch (InvalidCastException e)
            {
                throw new Exceptions.ValidationException("Failed to create Reservation", e);
            }
        }
        public ReserveDTO(int rID)
        {
           RID = rID;
        }
        private ReserveDTO() { }
        public static ReserveDTO Translate(Model.ReserveDTO field)
        {
            ReserveDTO Output = new ReserveDTO();
            Output.RID = field.RID;
            Output.UID = field.UID;
            Output.MediaID = field.MediaID;
            Output.ReservedDate = field.ReservedDate;
            return Output;
        }

        public int RID { get; set; }
        public int UID { get; set; }
        public int MediaID { get; set; }
        public DateTime ReservedDate { get; set; }
    }

}

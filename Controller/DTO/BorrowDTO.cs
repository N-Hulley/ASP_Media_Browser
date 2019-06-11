using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class BorrowDTO
    {
        public int BID { get; set; }
        public int UID { get; set; }
        public int MediaID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public decimal LateFee { get; set; }
        public BorrowDTO() {
        }

        
        public BorrowDTO(int bID)
        {
            try
            {
                BID = bID;
                ActualReturnDate = DateTime.Now;
            }
            catch (InvalidCastException e)
            {
                throw new Exceptions.ValidationException("Failed to create Borrow", e);
            }
        }
        
        public BorrowDTO(int? uID, int? mediaID)
        {
            try
            {
                UID = (int)uID;
                MediaID = (int)mediaID;
                BorrowDate = DateTime.UtcNow;
                ReturnDate = DateTime.UtcNow.AddDays(7);
            }
            catch (InvalidCastException e)
            {
                throw new Exceptions.ValidationException("Failed to create Borrow", e);
            }
        }
    }
}

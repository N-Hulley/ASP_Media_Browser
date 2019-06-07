using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IManageMediaRecords
    {
        MediaDTO AddRecord(MediaDTO record);
        IList<MediaDTO> Search();
        bool ChangeRecord(MediaDTO record, string Field, object Value);

        IList<MediaDTO> Search
        (
            String title = null,
            String genre = null,
            String director = null,
            String language = null,
            int? year = null
        );
        bool DeleteRecord(MediaDTO record);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IManageMediaRecords
    {
        bool AddRecord();
        IList<MediaDTO> Search();
        bool ChangeRecord();

        IList<MediaDTO> MakeMediaQuery
        (
            String title = null,
            String genre = null,
            String director = null,
            String language = null,
            int? year = null,
            decimal? budgetLow = null,
            decimal? budgetHigh = null
        );
    }
}

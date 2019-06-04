using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLayer
{
    public class LanguageDTO
    {
        public LanguageDTO(Model.LanguageDTO language)
        {
            LID = language.LID;
            LanguageName = language.LanguageName;
        }
        public LanguageDTO(string languageName)
        {
            LanguageName = languageName;
        }

        public LanguageDTO(int lID, string languageName)
        {
            LID = lID;
            LanguageName = languageName;
        }

        public int LID { get; set; }
        public string LanguageName { get; set; }
    }
}

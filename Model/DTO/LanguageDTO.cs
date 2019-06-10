using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LanguageDTO : GenericDTO
    {
        public LanguageDTO(string languageName) : base(languageName)
        { }


        public LanguageDTO(int lID, string languageName) : base(lID, languageName) { }

        public int LID { get => ID; set => ID = value; }
        public string LanguageName { get => Name; set => Name = value; }
    }
}

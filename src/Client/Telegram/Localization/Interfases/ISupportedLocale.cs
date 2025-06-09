using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBot.Localization.Interfases
{
    internal interface ISupportedLocale
    {
        string PathToFile { get; set; }
        string Code { get; set; }
        string NameButton { get; set; }
        string Message { get; set; }
    }

}

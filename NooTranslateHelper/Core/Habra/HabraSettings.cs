using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NooTranslateHelper.Core.Habra
{
    class HabraSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "https://savesubs.com/ru";
        public string Prefix { get; set; } = "page{currentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr8_Validation
{
    public class Training
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public string Load { get; set; }
        public string Description { get; set; }

        public string DisplayInfo
        {
            get { return $"{Date:dd.MM.yyyy} | {Type} | {Duration} мин | {Load}"; }
        }
    }
}

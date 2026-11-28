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
            get { return $" Тип тренировки: {Type} |  Дата тренировки: {Date:dd.MM.yyyy} \n {DurationDisplay}   |   {Load} \n {Description}" ; }
        }
        public string DurationDisplay
        {
            get
            {
                if (!int.TryParse(Duration, out var duration))
                {
                    return Duration + " мин.";
                }
                int hours = duration / 60;
                int minutes = duration % 60;

                if (hours == 0)
                {
                    return minutes + " мин.";
                }
                if (minutes == 0)
                {
                    return hours + " ч.";
                }
                return hours + " ч. " + minutes + " мин."; 

            }
        }
    }
}

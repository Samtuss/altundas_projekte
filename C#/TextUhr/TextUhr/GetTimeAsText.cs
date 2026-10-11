using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextUhr.enums;

namespace TextUhr
{
    public class GetTimeAsText
    {
        public string GetCurrentTimeAsText()
        {
            DateTime currentTime = DateTime.Now;

            Hours hour = (Hours)currentTime.Hour;
            Minutes minute = (Minutes)currentTime.Minute;
            Minutes second = (Minutes)currentTime.Second;

            string text = $"{hour} UHR";

            if (currentTime.Minute > 0)
            {
                if (currentTime.Minute == 1)
                {
                    text += $" EINE MINUTE";
                }
                else
                {
                    text += $" {minute} MINUTEN";
                }        
            }

            if (currentTime.Second > 0)
            {
                if (currentTime.Second == 1)
                {
                    text += $" UND EINE SEKUNDE";
                }
                else
                {
                    text += $" UND {second} SEKUNDEN";
                }
                    
            }


            return text;
        }
    }
}

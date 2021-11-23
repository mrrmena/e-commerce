using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Business
{
    public static class TimeSimulator
    {
        private static DateTime TimeStart = DateTime.Parse("01.01.1900 00:00:00");
        private static DateTime TimeNow = DateTime.Parse("01.01.1900 00:00:00");

        public static string GetTime()
        {
            return $"Time is {TimeNow.ToString("HH:mm")}";
        }

        public static void IncrementTime(int hours)
        {
            TimeNow = TimeNow.AddHours(hours);
            Console.WriteLine(GetTime());
            CampaignRepo.TimeTracker();
        }
        public static int Past()
        {
            return (TimeNow - TimeStart).Days;
        }
    }
}

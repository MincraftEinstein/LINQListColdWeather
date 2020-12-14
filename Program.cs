using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQListColdWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            List<Weather> daysForcasted = new List<Weather>();

            daysForcasted.Add(new Weather(DayOfWeek.TUE, 34, 27));
            daysForcasted.Add(new Weather(DayOfWeek.WED, 35, 29));
            daysForcasted.Add(new Weather(DayOfWeek.THU, 36, 27));
            daysForcasted.Add(new Weather(DayOfWeek.FRI, 38, 28));
            daysForcasted.Add(new Weather(DayOfWeek.SAT, 42, 33));

            var coldDays =
                from forecast in daysForcasted
                where forecast.HighTemp < 40
                select forecast;

            foreach (var forecast in coldDays)
            {
                Console.WriteLine("The weather on {0} is cold", forecast.Day);
            }

            var warmDays =
                from forecast in daysForcasted
                where forecast.HighTemp > 40
                select forecast;

            foreach (var forecast in warmDays)
            {
                Console.WriteLine("The weather on {0} is warm", forecast.Day);
            }
        }
    }

    enum DayOfWeek
    {
        SUN = 1, MON = 2, TUE = 3, WED = 4, THU = 5, FRI = 6, SAT = 7
    }

    class Weather
    {
        public DayOfWeek Day { get; set; }
        public int HighTemp { get; set; }
        public int LowTemp { get; set; }

        public Weather (DayOfWeek day, int high, int low) {
            Day = day;
            HighTemp = high;
            LowTemp = low;
        }
    }
}

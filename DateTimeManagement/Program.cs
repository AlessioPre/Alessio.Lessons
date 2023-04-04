using System;

namespace DateTimeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetTime();
        }


        static void GetTime()
        {
            DateTime now = DateTime.Now;

            DateTime myBirtday = new DateTime(1992,10,07);

            var mybirtdaytick = myBirtday.Ticks;
            Console.WriteLine("{0},{1}", myBirtday, mybirtdaytick);
        }


        static void GetDateFromInput()
        {

        }

        static void CreateTimeSpan()
        {
            TimeSpan time = new TimeSpan(0,5,0,0);

            DateTime mydate = DateTime.Now.Add(time);


        }
    }
}

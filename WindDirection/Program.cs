using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindDirection
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }

    public class Measure { public int Speed; public int Direction; }

    public static class WindDirectionCalculator
    {
        public static int CalculateAvgDirection(List<Measure> measureList, bool Scale = true)
        {
            int roundDecimals = 10;
            double x = 0;
            double y = 0;

            int retval = 0;

            foreach (var a in measureList)
            {
                double scaleCoef = (Scale ? (double)a.Speed : 1.0);

                var x0 = Math.Cos(DegreeToRadian(a.Direction));
                x += Math.Round(scaleCoef * x0, roundDecimals);

                var y0 = Math.Sin(DegreeToRadian(a.Direction));
                y += Math.Round(scaleCoef * y0, roundDecimals);
            }

            if (measureList.Count > 0)
            {
                retval = (int)Math.Round(XYToDegrees(x, y), 0);
                retval += (retval < 0) ? 360 : 0;
            }

            return retval;
        }

        //Info: http://www.vcskicks.com/code-snippet/degree-to-xy.php
        private static double XYToDegrees(double x, double y)
        {
            double radAngle = Math.Atan2(y, x);
            double degreeAngle = radAngle * 180.0 / Math.PI;
            return (double)(degreeAngle);
        }

        //Info: http://www.vcskicks.com/csharp_net_angles.php
        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        //Info: http://www.vcskicks.com/csharp_net_angles.php
        private static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        //Info: https://stackoverflow.com/questions/7490660/converting-wind-direction-in-angles-to-text-words
        public static string AngleToCompass(double angle)
        {   
            var val = (int)Math.Floor((angle / 22.5) + .5);
            var arr = new string[] { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };
            return arr[(val % 16)];
        }
    }

}


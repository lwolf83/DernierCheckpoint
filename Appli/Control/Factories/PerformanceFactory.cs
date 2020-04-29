using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public static class PerformanceFactory
    {
        public static Performance Create(string city, DateTime startTime)
        {
            Performance currentPerformance = new Performance()
                                            { 
                                                City = city,
                                                StartTime = startTime
                                            };

            return currentPerformance;
        }
    }
}

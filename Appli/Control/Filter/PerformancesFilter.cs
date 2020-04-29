using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCircus.Control.Filter
{
    public static class PerformancesFilter
    {
        public static List<Performance> FilterAfter(List<Performance> performances, DateTime datetime)
        {
            List<Performance> performancesResult = performances.Where(p => p.StartTime >= datetime).ToList();
            return performancesResult;
        }
        public static List<Performance> FilterBefore(List<Performance> performances, DateTime datetime)
        {
            List<Performance> performancesResult = performances.Where(p => p.StartTime <= datetime).ToList();
            return performancesResult;
        }

    }
}

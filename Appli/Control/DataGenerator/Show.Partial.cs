using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public partial class Show
    {
        public void GeneratePerformance()
        {
            Performances = new List<Performance>();

            DateTime currentdate = StartDate;
            while(currentdate < EndDate)
            {
                Performance currentPerformance = PerformanceFactory.Create("City 1", currentdate);
                currentdate = currentdate.AddDays(1);
                Performances.Add(currentPerformance);
            }

        }

    }
}

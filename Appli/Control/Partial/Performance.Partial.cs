using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCircus
{
    public partial class Performance
    {
        public Show GetShow()
        {
            var context = new WildCircusContext();
            List<Performance> performances = context.Performances.ToList();
            Show show = context.Shows.Where(x => x.Performances.Contains(this)).FirstOrDefault();
            return show;
        }
    }
}

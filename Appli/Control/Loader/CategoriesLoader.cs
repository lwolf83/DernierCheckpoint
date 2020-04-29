using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCircus
{
    public class CategoriesLoader
    {
        public static Category Get(string cat)
        {
            var context = new WildCircusContext();
            Category currentCategory = context.Categories.Where(x => x.Name == cat).FirstOrDefault();
            return currentCategory;
        }

    }
}

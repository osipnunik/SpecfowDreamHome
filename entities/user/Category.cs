using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.entities.user
{
    class Category
    {
        public string name { get; set; }
        //public List<string> names { get; set; }
        public List<Subcategory> Subcategories = new List<Subcategory>();
        public List<Product> Products { get; set; }

        public bool HasSubcategory { get; set; }

        public void SetSubcategories(List<Subcategory> subs)
        {
            if (subs.Count == 0)
            {
                HasSubcategory = false;
                Products = new List<Product>();
            } else { HasSubcategory = true; }
            this.Subcategories = subs;
        }
        public void AddSubcategories(Subcategory sub)
        {
            Subcategories.Add(sub);
        }
    }
}

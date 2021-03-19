using System.Collections.Generic;

namespace SpecFlowDreanLotteryHome.entities.user
{
    public class Subcategory
    {
        public string name { get; set; }
        public List<Product> Products { get; set; }
    }
}
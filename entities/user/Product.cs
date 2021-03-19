namespace SpecFlowDreanLotteryHome.entities.user
{
    public class Product
    {
        public string CategoryName { get; set; }
        public string SubcategoryName { get; set; }
        public string ImgHref { get; set; }
        public string Title { get; set; }
        public string NonDiscountPrice { get; set; }
        public string OldPrice { get; set; }
        public string NewPrice { get; set; }
        public string DiscountOff { get; set; }
         
        public override bool Equals(object obj)
        {
            return CategoryName.Equals(((Product)obj).CategoryName) && SubcategoryName.Equals(((Product)obj).SubcategoryName)
                && /*ImgHref.Equals(((Product)obj).ImgHref) &&*/ Title.Equals(((Product)obj).Title)
                && (NonDiscountPrice.Equals(((Product)obj).NonDiscountPrice)? true: (OldPrice.Equals(((Product)obj).OldPrice)
                && NewPrice.Equals(((Product)obj).NewPrice) && DiscountOff.Equals((((Product)obj).DiscountOff)))  );

        }
        public override string ToString()
        {
            return "title: " + this.Title + " CategoryName: " + this.CategoryName + " SubcategoryName: " + this.SubcategoryName
                + " NonDiscountPrice: "+NonDiscountPrice+ " NewPrice: "+NewPrice;
        }
    }
}
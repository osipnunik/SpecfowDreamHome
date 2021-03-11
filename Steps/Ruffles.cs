using System.Collections.Generic;

namespace SpecFlowDreanLotteryHome.Steps
{
    public class Ruffles
    {
        public bool active { get; set; }
        public int defaultTickets { get; set; }
        public bool isActiveDiscount { get; set; }
        public bool isDiscountRates { get; set; }
        public bool isClosed { get; set; }
        public bool isPopular { get; set; }
        public bool isTrending { get; set; }
        public bool isDeleted { get; set; }
        public List<string> creditsRates { get; set; }
        public bool isCreditsActive { get; set; }
        public List<string> discountRates { get; set; }
        public List<string> name { get; set; }
        public int ticketPrice { get; set; }
        public string endsAt { get; set; }
        public string property { get; set; }
        public int __v { get; set; }
    }
}
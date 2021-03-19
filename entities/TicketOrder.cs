using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.entities
{
    class TicketOrder
    {
        public string Competiotion { get; set; }
        public string Product { get; set; }
        public string NumberOfTicket { get; set; }
        public string DrawDate { get; set; }
                
        public override bool Equals(object obj)
        {
            return Competiotion.Equals(((TicketOrder)obj).Competiotion) && Product.Equals(((TicketOrder)obj).Product) 
                && NumberOfTicket.Equals(((TicketOrder)obj).NumberOfTicket);
        }
        public override string ToString()
        {
            return this.Competiotion + " " + this.Product + " " + this.NumberOfTicket + " " + this.DrawDate;
        }
    }
       
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class TradeViolationAttributesModel
    {
        public Guid TradeViolationAttributesId { get; set; }
        [DisplayName("Violation Date")]
        public string ViolationDate { get; set; }
        [DisplayName("Sell Ticket Number")]
        public string SellTicketNumber { get; set; }
        [DisplayName("Buy Ticket Number")]
        public string BuyTicketNumber { get; set; }
        [DisplayName("Trade Type")]
        public string TradeType { get; set; }
        [DisplayName("Sell Member Name")]
        public string SellMemberName { get; set; }
        [DisplayName("Sell Client Name")]
        public string SellClientName { get; set; }
        [DisplayName("Ware House")]
        public string WareHouse { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Buy Member Name")]
        public string BuyMemberName { get; set; }
        [DisplayName("Buy Client Name")]
        public string BuyClientName { get; set; }
        [DisplayName("Sell Representative Name")]
        public string SellRepresentativeName { get; set; }
        [DisplayName("Buy Representative Name")]
        public string BuyRepresentativeName { get; set; }
        [DisplayName("Trade Price")]
        public double TradePrice { get; set; }
        [DisplayName("Production Year")]
        public int ProductionYear { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Further Explanation")]
        public string FurtherExplanation { get; set; }
        [DisplayName("Reason for Cancellation")]
        public string CancellationReason { get; set; }
        [DisplayName("Trade Symbol")]
        public string Symbol { get; set; }
    }
}

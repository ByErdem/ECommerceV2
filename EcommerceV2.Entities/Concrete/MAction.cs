﻿using ECommerceV2.Shared.Entities.Abstract;
using ECommerceV2.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceV2.Entities.Concrete
{
    public class MAction : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public int StockId { get; set; }
        public decimal Amount { get; set; }
        public string? StockName { get; set; }
        public string? Category { get; set; }
        public EUnit Unit { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public bool AppliedDiscount { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Amount * UnitPrice;
            }

            set { }
        }
        public EActionType ActionType { get; set; }
        public MStock? Stock { get; set; }
        public MUser? User { get; set; }
        public ICollection<MCommissionRate>? CommissionRates { get; set; }
    }
}

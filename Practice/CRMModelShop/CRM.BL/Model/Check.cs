﻿using System;
using System.Collections.Generic;

namespace CRM.BL.Model
{
    public class Check
    {
        public Check() { }

        public int CheckId { get; set; }
        public DateTime Created { get; set; }


        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }


        public override string ToString() => $"№{CheckId} от {Created.ToString("dd.MM.yyyy hh:mm:ss")}";
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Models
{
    public class BasketModel
    {
        public string UserName { get; set; }
        public List<BasktetItemExtendedModel> Items { get; set; } = new List<BasktetItemExtendedModel>();
        public decimal TotalPrice { get; set; }
    }
}

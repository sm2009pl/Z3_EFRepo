using System;
using System.Collections.Generic;

namespace Z3_RE_EF.Models
{
    public partial class OrderSubtotals
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}

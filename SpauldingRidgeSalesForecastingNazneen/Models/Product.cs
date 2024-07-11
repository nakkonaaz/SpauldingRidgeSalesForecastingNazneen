using System;
using System.Collections.Generic;

namespace SpauldingRidgeSalesForecastingNazneen.Models;

public partial class Product
{
    public string OrderId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string SubCategory { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public double Sales { get; set; }

    public byte Quantity { get; set; }

    public double Discount { get; set; }

    public double? Profit { get; set; }
}

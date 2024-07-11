using System;
using System.Collections.Generic;

namespace SpauldingRidgeSalesForecastingNazneen.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public DateOnly ShipDate { get; set; }

    public string ShipMode { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string Segment { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public int? PostalCode { get; set; }

    public string Region { get; set; } = null!;
}

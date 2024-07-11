namespace SpauldingRidgeSalesForecastingNazneen.ViewModels
{
    public class SalesViewModel
    {
        public string State { get; set; }
        public double TotalSales { get; set; }
    }

    public class SalesQueryViewModel
    {
        public int Year { get; set; }
        public double TotalSales { get; set; }
        public List<SalesViewModel> SalesData { get; set; } = new List<SalesViewModel>();
    }
}

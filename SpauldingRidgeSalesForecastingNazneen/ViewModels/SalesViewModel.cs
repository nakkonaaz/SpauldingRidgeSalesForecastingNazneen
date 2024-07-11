namespace SpauldingRidgeSalesForecastingNazneen.ViewModels
{
    public class SalesViewModel
    {
        public string State { get; set; }
        public double TotalSales { get; set; }
        public double IncrementedSales { get; set; }
    }

    public class SalesQueryViewModel
    {
        public int Year { get; set; }
        public double TotalSales { get; set; }
        public double Percentage { get; set; }
        public double TotalIncrementedSales { get; set; }
        public List<SalesViewModel> SalesData { get; set; } = new List<SalesViewModel>();
    }
}

namespace SpauldingRidgeSalesForecastingNazneen.ViewModels
{
    public class SalesChartViewModel
    {
        public int Year { get; set; }
        public List<SalesViewModel> SalesData { get; set; } = new();
    }
}

namespace DapperCase.Dtos
{
    public class DashboardDto
    {
        public double TotalRevenue { get; set; }
        public double TotalProfit { get; set; }
        public int TotalOrders { get; set; }
        public int TotalCustomers { get; set; }
        public double AverageBasket { get; set; }

        public List<string> MixedChartLabels { get; set; } = new();
        public List<double> MixedRevenueValues { get; set; } = new();
        public List<double> MixedProfitValues { get; set; } = new();

        public string TopCustomer { get; set; } = "";
        public string TopOrder { get; set; } = "";

        public List<string> RevenueChartLabels { get; set; } = new();
        public List<double> RevenueChartValues { get; set; } = new();

        public List<string> ProfitChartLabels { get; set; } = new();
        public List<double> ProfitChartValues { get; set; } = new();

        public List<TopCustomerRow> TopCustomers { get; set; } = new();
        public List<TopOrderRow> TopOrders { get; set; } = new();
    }

    public class TopCustomerRow
    {
        public string customer_id { get; set; } = "";
        public double total_revenue { get; set; }
        public double total_profit { get; set; }
        public int order_count { get; set; }
    }

    public class TopOrderRow
    {
        public string order_id { get; set; } = "";
        public string customer_id { get; set; } = "";
        public double revenue { get; set; }
        public double profit { get; set; }
    }
}
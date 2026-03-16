using Dapper;
using DapperCase.Context;
using DapperCase.Dtos;

namespace DapperCase.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly DapperContext _context;

        public DashboardService(DapperContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            using var connection = _context.CreateConnection();

            var model = new DashboardDto();

            model.TotalRevenue = await connection.ExecuteScalarAsync<double>(
                "SELECT ISNULL(SUM(revenue),0) FROM dbo.SalesImport");

            model.TotalProfit = await connection.ExecuteScalarAsync<double>(
                "SELECT ISNULL(SUM(profit),0) FROM dbo.SalesImport");

            model.TotalOrders = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM dbo.SalesImport");

            model.TotalCustomers = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(DISTINCT customer_id) FROM dbo.SalesImport");

            model.AverageBasket = await connection.ExecuteScalarAsync<double>(
                "SELECT ISNULL(AVG(revenue),0) FROM dbo.SalesImport");

            model.TopCustomer = await connection.ExecuteScalarAsync<string>(
                @"SELECT TOP 1 customer_id
                  FROM dbo.SalesImport
                  GROUP BY customer_id
                  ORDER BY SUM(revenue) DESC") ?? "";

            model.TopOrder = await connection.ExecuteScalarAsync<string>(
                @"SELECT TOP 1 order_id
                  FROM dbo.SalesImport
                  ORDER BY revenue DESC") ?? "";

            var revenueChart = await connection.QueryAsync<(string label, double total)>(
                @"SELECT TOP 6
                    customer_id AS label,
                    SUM(revenue) AS total
                  FROM dbo.SalesImport
                  GROUP BY customer_id
                  ORDER BY SUM(revenue) DESC");

            model.RevenueChartLabels = revenueChart.Select(x => x.label).ToList();
            model.RevenueChartValues = revenueChart.Select(x => x.total).ToList();

            var profitChart = await connection.QueryAsync<(string label, double total)>(
                @"SELECT TOP 6
                    customer_id AS label,
                    SUM(profit) AS total
                  FROM dbo.SalesImport
                  GROUP BY customer_id
                  ORDER BY SUM(profit) DESC");

            model.ProfitChartLabels = profitChart.Select(x => x.label).ToList();
            model.ProfitChartValues = profitChart.Select(x => x.total).ToList();

            var topCustomers = await connection.QueryAsync<TopCustomerRow>(
                @"SELECT TOP 5
                    customer_id,
                    SUM(revenue) AS total_revenue,
                    SUM(profit) AS total_profit,
                    COUNT(*) AS order_count
                  FROM dbo.SalesImport
                  GROUP BY customer_id
                  ORDER BY SUM(revenue) DESC");

            model.TopCustomers = topCustomers.ToList();

            var topOrders = await connection.QueryAsync<TopOrderRow>(
                @"SELECT TOP 5
                    order_id,
                    customer_id,
                    revenue,
                    profit
                  FROM dbo.SalesImport
                  ORDER BY revenue DESC");

            model.TopOrders = topOrders.ToList();
            var mixedChartData = await connection.QueryAsync<(string label, double revenue, double profit)>(
    @"SELECT TOP 10
        order_id AS label,
        revenue,
        profit
      FROM dbo.SalesImport
      ORDER BY order_date DESC");

            model.MixedChartLabels = mixedChartData.Select(x => x.label).ToList();
            model.MixedRevenueValues = mixedChartData.Select(x => x.revenue).ToList();
            model.MixedProfitValues = mixedChartData.Select(x => x.profit).ToList();


            return model;
        }
    }
}
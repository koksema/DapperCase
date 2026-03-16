using Dapper;
using DapperCase.Context;
using DapperCase.Dtos;

namespace DapperCase.Services
{
    public class SalesService : ISalesService
    {
        private readonly DapperContext _context;

        public SalesService(DapperContext context)
        {
            _context = context;
        }
        async Task<SalesPageDto> ISalesService.GetPagedSales(int page, int pageSize)
        {
            using var connection = _context.CreateConnection();

            var totalCount = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM dbo.SalesImport");

            var query = @"SELECT 
                            order_id,
                            order_date,
                            customer_id,
                            quantity,
                            revenue,
                            profit
                          FROM dbo.SalesImport
                          ORDER BY order_date DESC
                          OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var values = await connection.QueryAsync<SalesDto>(query, new
            {
                Offset = (page - 1) * pageSize,
                PageSize = pageSize
            });

            return new SalesPageDto
            {
                Sales = values.ToList(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };
        }
    }
}
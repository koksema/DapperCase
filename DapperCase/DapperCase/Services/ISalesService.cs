using DapperCase.Dtos;

namespace DapperCase.Services
{
    public interface ISalesService
    {
        Task<SalesPageDto> GetPagedSales(int page, int pageSize);
    }
}
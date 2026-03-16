using DapperCase.Dtos;

namespace DapperCase.Services
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}
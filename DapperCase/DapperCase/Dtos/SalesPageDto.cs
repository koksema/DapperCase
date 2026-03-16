namespace DapperCase.Dtos
{
    public class SalesPageDto
    {
        public List<SalesDto> Sales { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}

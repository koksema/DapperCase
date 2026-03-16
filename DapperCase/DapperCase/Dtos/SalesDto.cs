namespace DapperCase.Dtos
{
    public class SalesDto
    {
        public string order_id { get; set; } = "";
        public DateTime order_date { get; set; }
        public string customer_id { get; set; } = "";
        public int quantity { get; set; }
        public double revenue { get; set; }
        public double profit { get; set; }
    }
}
namespace RM.ApiDotNet6.Application.DTOs
{
    public class PurchaseDetailDTO
    {
        public int Id { get; set; }
        public string Person { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}

namespace RM.ApiDotNet6.Application.DTOs
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public string CodErp { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
    }
}

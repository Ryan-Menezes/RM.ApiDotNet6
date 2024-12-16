namespace RM.ApiDotNet6.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CodErp { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}

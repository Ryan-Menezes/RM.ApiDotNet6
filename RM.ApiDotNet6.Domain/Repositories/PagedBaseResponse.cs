namespace RM.ApiDotNet6.Domain.Repositories
{
    public class PagedBaseResponse<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }
    }
}

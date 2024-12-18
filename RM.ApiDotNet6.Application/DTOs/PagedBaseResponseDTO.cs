namespace RM.ApiDotNet6.Application.DTOs
{
    public class PagedBaseResponseDTO<T>
    {
        public List<T> Data { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalRegisters { get; private set; }

        public PagedBaseResponseDTO(List<T> data, int totalPages, int totalRegisters)
        {
            Data = data;
            TotalPages = totalPages;
            TotalRegisters = totalRegisters;
        }
    }
}

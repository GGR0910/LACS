namespace LACS_API.DTO
{
    public class Pagination : BaseRequestDTO
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }

    }
}

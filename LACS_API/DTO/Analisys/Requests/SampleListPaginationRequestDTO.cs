namespace LACS_API.DTO.Analisys.Requests
{
    public class SampleListPaginationRequestDTO : Pagination
    {
        public string? RequesterId { get; set; }
        public int? SampleTypeId { get; set; }
        public int? SamplePhisicalStateId { get; set; }
        public bool? Analized { get; set; }
    }
}

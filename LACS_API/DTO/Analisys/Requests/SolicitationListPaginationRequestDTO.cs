namespace LACS_API.DTO.Analisys.Requests
{
    public class SolicitationListPaginationRequestDTO : Pagination
    {
        public string? RequesterId { get; set; }
        public int? SolicitationTypeId { get; set; }
        public int? AnalisysTypeId { get; set; }
        public bool? ResultsDelivered { get; set; }
    }
}

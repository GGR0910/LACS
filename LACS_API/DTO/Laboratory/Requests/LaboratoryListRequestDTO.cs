namespace LACS_API.DTO
{
    public class LaboratoryListRequestDTO : Pagination
    {
        public string? Name { get; set; }
        public string? Document { get; set; }
        public string? DepartmentName { get; set; }
        public string? CountryName { get; set; }
    }
}

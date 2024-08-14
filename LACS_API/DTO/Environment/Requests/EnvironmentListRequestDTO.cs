namespace LACS_API.DTO
{
    public class EnvironmentListRequestDTO : Pagination
    {
        public string? Name { get; set; }
        public string? Document { get; set; }
        public string? DepartmentName { get; set; }
        public string? CountryName { get; set; }
    }
}

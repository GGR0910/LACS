using System.ComponentModel.DataAnnotations;

namespace LACS_API.DTO
{
    public class UserPaginationListRequest : Pagination
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public string? DepartamentName { get; set; }

    }
}

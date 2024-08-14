namespace LACS_API.DTO
{
    public class RegisterEnvironmentRequestDTO
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string LaboratoryAdress { get; set; }
        public string LaboratoryContactInfo { get; set; }
        public string LaboratoryEmail { get; set; }
        public string DepartmentName { get; set; }
        public string CountryName { get; set; }
        public string UserUserName { get; set; }
        public string UserEmail { get; set; }
    }
}

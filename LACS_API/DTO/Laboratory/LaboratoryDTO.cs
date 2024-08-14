using Laboratory = Domain.Entities.Laboratory;

namespace LACS_API.DTO
{
    public class LaboratoryDTO
    {
        public LaboratoryDTO(Laboratory environment) 
        {
            Id = environment.Id;
            Name = environment.Name;
            Document = environment.ResponsibleDocument;
            LaboratoryAdress = environment.LaboratoryAdress;
            LaboratoryContactInfo = environment.LaboratoryContactInfo;
            LaboratoryEmail = environment.LaboratoryEmail;
            DepartmentName = environment.DepartmentName;
            CountryName = environment.CountryName;
            ResponsibleName = environment.ResponsibleName;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string LaboratoryAdress { get; set; }
        public string LaboratoryContactInfo { get; set; }
        public string LaboratoryEmail { get; set; }
        public string DepartmentName { get; set; }
        public string CountryName { get; set; }
        public string ResponsibleName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Laboratory : BaseEntity
    {
        public Laboratory()
        {
            
        }

        public Laboratory(string loggedUserId, string name, string document, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string departamentName, string countryName, string responsibleName) : base(loggedUserId)
        {
            Name = name;
            ResponsibleDocument = document;
            LaboratoryAdress = laboratoryAdress;
            LaboratoryContactInfo = laboratoryContactInfo;
            LaboratoryEmail = laboratoryEmail;
            DepartmentName = departamentName;
            CountryName = countryName;
            ResponsibleName = responsibleName;
        }

        public string Name { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsibleDocument { get; set; }
        public string LaboratoryAdress { get; set; }
        public string LaboratoryContactInfo { get; set; }
        public string LaboratoryEmail { get; set; }
        public string DepartmentName { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<Analisys> Analisys { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public void Edit(string name, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string departamentName, string countryName, string loggedUserId)
        {
            Name = name;
            LaboratoryAdress = laboratoryAdress;
            LaboratoryContactInfo = laboratoryContactInfo;
            LaboratoryEmail = laboratoryEmail;
            DepartmentName = departamentName;
            CountryName = countryName;
            Update(loggedUserId);
        }

        public void Delete(string loggedUserId)
        {
            Deleted = true;
            Update(loggedUserId);
        }
    }
}

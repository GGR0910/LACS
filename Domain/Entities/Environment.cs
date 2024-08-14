using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Environment : BaseEntity
    {
        public Environment()
        {
            
        }

        public Environment(string loggedUserId, string name, string document, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string departamentName, string countryName, string responsibleName) : base(loggedUserId)
        {
            Name = name;
            Document = document;
            LaboratoryAdress = laboratoryAdress;
            LaboratoryContactInfo = laboratoryContactInfo;
            LaboratoryEmail = laboratoryEmail;
            DepartmentName = departamentName;
            CountryName = countryName;
            ResponsibleName = responsibleName;
        }

        public string Name { get; set; }
        public string Document { get; set; }
        public string LaboratoryAdress { get; set; }
        public string LaboratoryContactInfo { get; set; }
        public string LaboratoryEmail { get; set; }
        public string DepartmentName { get; set; }
        public string CountryName { get; set; }
        public string ResponsibleName { get; set; }
        public virtual IEnumerable<Solicitation> Solicitations { get; set; }
        public virtual IEnumerable<Analisys> Analisys { get; set; }

        public void Edit(string name, string document, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string departamentName, string countryName, string responsibleName, string loggedUserId)
        {
            Name = name;
            Document = document;
            LaboratoryAdress = laboratoryAdress;
            LaboratoryContactInfo = laboratoryContactInfo;
            LaboratoryEmail = laboratoryEmail;
            DepartmentName = departamentName;
            CountryName = countryName;
            ResponsibleName = responsibleName;
            Update(loggedUserId);
        }

        public void Delete(string loggedUserId)
        {
            Deleted = true;
            Update(loggedUserId);
        }
    }
}

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

        public Laboratory(string name, string document, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string countryName, string responsibleName, string laboratoryDocument) : base(null)
        {
            Name = name;
            ResponsibleDocument = document;
            LaboratoryAdress = laboratoryAdress;
            LaboratoryContactInfo = laboratoryContactInfo;
            LaboratoryEmail = laboratoryEmail;
            CountryName = countryName;
            ResponsibleName = responsibleName;
            LaboratoryDocument = laboratoryDocument;
            PersonlizedEndpoint = name.Replace(" ","-") + "-" + countryName.Replace(" ","-");
        }

        public string Name { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsibleDocument { get; set; }
        public string LaboratoryDocument { get; set; }
        public string LaboratoryAdress { get; set; }
        public string LaboratoryContactInfo { get; set; }
        public string LaboratoryEmail { get; set; }
        public string CountryName { get; set; }
        public string DefaultPassword { get; set; }
        public string DefaultDepartamentName { get; set; }
        //When acess the link, the user will see the lab info and available analisys
        public string PersonlizedEndpoint { get; set; }
        public virtual ICollection<Analisys> Analisys { get; set; }
        public virtual ICollection<UserLaboratory> UserLaboratories { get; set; }

        public void Edit(string name, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string countryName, string? loggedUserId)
        {
            Name = name;
            LaboratoryAdress = laboratoryAdress;
            LaboratoryContactInfo = laboratoryContactInfo;
            LaboratoryEmail = laboratoryEmail;
            CountryName = countryName;
            Update(loggedUserId);
        }
    }
}

using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserLaboratory : BaseEntity
    {
        public UserLaboratory()
        {

        }
        public UserLaboratory(string? creatorUserLaboratoryId, int roleId, string userId, string laboratoryId, bool isCurrent, string sectorName, string labUserName) : base(creatorUserLaboratoryId)
        {
            RoleId = roleId;
            UserId = userId;
            LaboratoryId = laboratoryId;
            IsCurrent = isCurrent;
            SectorName = sectorName;
            LabUserName = labUserName;
        }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string LaboratoryId { get; set; }
        public virtual Laboratory Laboratory { get; set; }
        public bool IsCurrent { get; set; }
        public string? SectorName { get; set; }
        public string LabUserName { get; set; }
        public bool CanOperate { get { return RoleId == (int)RolesEnum.Admin || RoleId == (int)RolesEnum.Analist; } }
        public bool IsAdmin { get { return RoleId == (int)RolesEnum.Admin; } }

        #region Base entity Data
        public ICollection<Analisys> AnalisysCreatedBy { get; set; }
        public ICollection<Analisys> AnalisysUpdatedBy { get; set; }
        public ICollection<FormAnswer> FormAnswerCreatedBy { get; set;}
        public ICollection<FormAnswer> FormAnswerUpdatedBy { get; set; }
        public ICollection<FormSubmit> FormSubmitCreatedBy { get; set; }
        public ICollection<FormSubmit> FormSubmitUpdatedBy { get; set; }
        public ICollection<Form> FormCreatedBy { get; set; }
        public ICollection<Form> FormUpdatedBy { get; set; }
        public ICollection<FormQuestion> FormQuestionCreatedBy { get; set; }
        public ICollection<FormQuestion> FormQuestionUpdatedBy { get; set; }
        public ICollection<FormQuestionOption> FormQuestionOptionCreatedBy { get; set; }
        public ICollection<FormQuestionOption> FormQuestionOptionUpdatedBy { get; set; }
        public ICollection<FormSection> FormSectionCreatedBy { get; set; }
        public ICollection<FormSection> FormSectionUpdatedBy { get; set; }
        public ICollection<RequesterNotes> RequesterNotesCreatedBy { get; set; }
        public ICollection<RequesterNotes> RequesterNotesUpdatedBy { get; set; }
        public ICollection<Laboratory> LaboratoriesCreatedBy { get; set; }
        public ICollection<Laboratory> LaboratoriesUpdatedBy { get; set; }
        public ICollection<User> UsersCreatedBy { get; set; }
        public ICollection<User> UsersUpdatedBy { get; set; }
        public ICollection<Sample> SamplesCreatedBy { get; set; }
        public ICollection<Sample> SamplesUpdatedBy { get; set; }
        public ICollection<Solicitation> SolicitationsCreatedBy { get; set; }
        public ICollection<Solicitation> SolicitationsUpdatedBy { get; set; }
        public ICollection<UserLaboratory> UserLaboratoriesCreatedBy { get; set; }
        public ICollection<UserLaboratory> UserLaboratoriesUpdatedBy { get; set; }
        public ICollection<UserInteraction> UserInteractionsCreatedBy { get; set; }
        public ICollection<UserInteraction> UserInteractionsUpdatedBy { get; set; }
        public ICollection<AnalystAnalisysResponsible> AnalystAnalisysResponsiblesCreatedBy { get; set; }
        public ICollection<AnalystAnalisysResponsible> AnalystAnalisysResponsiblesUpdatedBy { get; set; }
        public ICollection<AnalisysForm> AnalisysFormCreatedBy { get; set; }
        public ICollection<AnalisysForm> AnalisysFormUpdatedBy { get; set; }

        #endregion

        public void Edit(string userName, int roleId, string departamentName, string userLaboratoryId)
        {
            RoleId = roleId;
            LabUserName = userName;
            SectorName = departamentName;
            UpdatedAt = DateTime.Now;
            Update(userLaboratoryId);
        }
    }
}

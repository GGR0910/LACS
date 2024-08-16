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
        public UserLaboratory(string? creatorUserLaboratoryId, int roleId, string userId, string laboratoryId) : base(creatorUserLaboratoryId)
        {
            RoleId = roleId;
            UserId = userId;
            LaboratoryId = laboratoryId;
        }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string LaboratoryId { get; set; }
        public virtual Laboratory Laboratory { get; set; }
        public virtual User CurrentLaboratory { get; set; }
        public bool CanOperate { get { return RoleId == (int)RolesEnum.Admin || RoleId == (int)RolesEnum.Analist; } }
        public bool IsAdmin { get { return RoleId == (int)RolesEnum.Admin; } }

        #region Base entity Data
        public ICollection<Analisys> AnalisysCreatedBy { get; set; }
        public ICollection<Analisys> AnalisysUpdatedBy { get; set; }
        public ICollection<AnalisysFormAnswer> AnalisysFormAnswerCreatedBy { get; set;}
        public ICollection<AnalisysFormAnswer> AnalisysFormAnswerUpdatedBy { get; set; }
        public ICollection<AnalisysFormSubmit> AnalisysFormSubmitCreatedBy { get; set; }
        public ICollection<AnalisysFormSubmit> AnalisysFormSubmitUpdatedBy { get; set; }
        public ICollection<AnalisysForm> AnalisysFormCreatedBy { get; set; }
        public ICollection<AnalisysForm> AnalisysFormUpdatedBy { get; set; }
        public ICollection<AnalisysFormQuestion> AnalisysFormQuestionCreatedBy { get; set; }
        public ICollection<AnalisysFormQuestion> AnalisysFormQuestionUpdatedBy { get; set; }
        public ICollection<AnalisysFormQuestionOption> AnalisysFormQuestionOptionCreatedBy { get; set; }
        public ICollection<AnalisysFormQuestionOption> AnalisysFormQuestionOptionUpdatedBy { get; set; }
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

        #endregion

        public void Delete(string currentUserLaboratoryId)
        {
            Deleted = true;
            Update(currentUserLaboratoryId);
        }

        public void UnDelete(string currentUserLaboratoryId)
        {
            Deleted = false;
            Update(currentUserLaboratoryId);
        }
    }
}

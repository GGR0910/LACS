using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Solicitation : BaseEntity
    {
        public Solicitation()
        {
            
        }
        public Solicitation(string requesterId, int solicitationTypeId, string samplesDescription, string analysisGoalDescription,
            int analisysTypeId, string? desiredMagnefication, bool needsRecobriment, string? recobrimentMaterial, string? specialPrecautions
            , DateTime desiredDeadLine, string deliveryLocation, bool desireToAccompanyAnalisys, string? observations) : base(requesterId) 
        {
            RequesterId = requesterId;
            SoliciationTypeId = solicitationTypeId;
            SamplesDescription = samplesDescription;
            AnalysisGoalDescription = analysisGoalDescription;
            AnalisysTypeId = analisysTypeId;
            DesiredMagnefication = desiredMagnefication;
            NeedsRecobriment = needsRecobriment;
            RecobrimentMaterial = recobrimentMaterial;
            SpecialPrecautions = specialPrecautions;
            DesiredDeadline = desiredDeadLine;
            DeliveryLocation = deliveryLocation;
            DesireToAccompanyAnalysis = desireToAccompanyAnalisys;
            Observations = observations;
            Samples = new List<Sample>();
            ResultsDelivered = false;
        }
        //Basic solicitation information
        public string RequesterId { get; set; }
        public virtual User Requester { get; set; }
        public int SoliciationTypeId { get; set; }
        public virtual SolicitationType SolicitationType { get; set; }
        public string SamplesDescription { get; set; }
        public string AnalysisGoalDescription { get; set; }
   
        public string? DesiredMagnefication { get; set; }
        public bool NeedsRecobriment { get; set; }
        public string? RecobrimentMaterial { get; set; }
        public string? SpecialPrecautions { get; set; }
        public DateTime DesiredDeadline { get; set; }
        public string DeliveryLocation { get; set; }
        public bool DesireToAccompanyAnalysis { get; set; }
        public string? Observations { get; set; }
        public DateTime? SamplesReceivedDate { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool ResultsDelivered { get; set; }
        public int SampleAmount { get { return Samples.Count(); } }
        public virtual ICollection<Sample> Samples { get; set; }

        //Specific solicitation information
        public int AnalisysTypeId { get; set; }
        public virtual AnalisysType AnalisysType { get; set; }
    }
}

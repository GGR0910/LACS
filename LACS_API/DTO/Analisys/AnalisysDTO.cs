using Domain.Entities;

namespace LACS_API.DTO
{
    public class AnalisysDTO
    {
        public AnalisysDTO(Analisys analisys)
        {
            Id = analisys.Id;
            Name = analisys.Name;
            Description = analisys.Description;
            AmountDonePerDay = analisys.AmountDonePerDay;
            SampleDeliverObservations = analisys.SampleDeliverObservations;
            AnalistsNames = analisys.AnalistsNames;
            AllowWatching = analisys.AllowWatching;
            Laboratory = new LaboratoryDTO(analisys.Laboratory);
            CreatedAt = analisys.CreatedAt;
            UpdatedAt = analisys.UpdatedAt;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountDonePerDay { get; set; }
        public string SampleDeliverObservations { get; set; }
        public string AnalistsNames { get; set; }
        public bool AllowWatching { get; set; }
        public string LaboratoryId { get; set; }
        public virtual LaboratoryDTO Laboratory { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

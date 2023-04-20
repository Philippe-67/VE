using System.ComponentModel.DataAnnotations;

namespace VE.Models
{
    public class Interventions
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Prix { get; set; }
        public ICollection<Reparation_Intervention>? ReparationInterventions { get; set; }
    }
}

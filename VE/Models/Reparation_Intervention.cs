using System.ComponentModel.DataAnnotations;

namespace VE.Models
{
    public class Reparation_Intervention
    {
        [Key]
        public int Id { get; set; }
        public Reparations Reparation { get; set; }
        public string? TypeIntervention { get; set; }
        public Interventions Intervention { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace VE.Models
{
    public class Reparation_Intervention
    {
        [Key]
        public int Id { get; set; }
        public string? TypeIntervention { get; set; }
    }
}

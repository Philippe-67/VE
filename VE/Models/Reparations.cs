using System.ComponentModel.DataAnnotations;

namespace VE.Models
{
    public class Reparations
    {
        [Key]
        public int ReparationId { get; set; }
        public DateTime DatePriseEnCharge { get; set; }
        public DateTime? DateDelivrance { get; set; }

        // Clé étrangère pour la voiture associée à la réparation
        public int VoituresId { get; set; }
        public Voitures? Voiture { get; set; }
        public ICollection<Reparation_Intervention>? ReparationInterventions { get; set; }
    }
}



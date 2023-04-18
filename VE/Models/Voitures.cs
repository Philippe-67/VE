using System.ComponentModel.DataAnnotations;

namespace VE.Models
{
    public class Voitures
    {
        [Key]
        public int VoituresId { get; set; }
        public DateTime DateAchat { get; set; }
        public string Marque { get; set; }
        public string Finition { get; set; }
        public string Modele { get; set; }
        [Range(0, int.MaxValue)]
        public int Annee { get; set; }
        public DateTime DateVente { get; set; }
        public float PrixAchat { get; set; }
        public float PrixVente { get; set; }
        public bool VoituresExists { get; set; }
        // Liste des réparations associées à la voiture
        public ICollection<Reparations>? Reparations { get; set; }
    }
}

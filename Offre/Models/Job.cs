using System.ComponentModel;

namespace Offre.Models
{
    public class Job
    {
        public int Id { get; set; }

        [DisplayName("Le nom de loffre")]
        public string JobTitle { get; set; }
        
        [DisplayName("Description de loffre")]
        public string JobContent { get; set; }
        
        [DisplayName("Image de loffre")]
        public string JobImage { get; set; }

        [DisplayName("Le Catégorie")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
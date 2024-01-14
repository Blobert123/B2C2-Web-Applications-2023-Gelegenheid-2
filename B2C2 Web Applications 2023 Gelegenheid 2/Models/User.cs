using System.ComponentModel.DataAnnotations;

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Password { get; set; }

        public ICollection<CollectionItem> CollectionItems { get; set; }
    }
}

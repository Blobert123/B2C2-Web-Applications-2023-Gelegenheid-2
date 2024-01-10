using System.ComponentModel.DataAnnotations;

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Models
{
    public class CollectionName
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int AdminId { get; set; }

        public Admin? Admin { get; set; }
    }
}

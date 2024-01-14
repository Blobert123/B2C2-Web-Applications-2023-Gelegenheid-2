using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Models
{
    public class CollectionItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public float Price { get; set; }

        public int CollectionNameId { get; set; }

        public CollectionName? CollectionName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}

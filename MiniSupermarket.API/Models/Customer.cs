using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Address { get; set; }

        public int RewardPoints { get; set; } = 0;

        [MaxLength(50)]
        public string MembershipRank { get; set; } = "Chuẩn";
    }
}
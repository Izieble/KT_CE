using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UE03_Eventmanagement_Backend._01_DB_Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string Location { get; set; }

        [StringLength(50)]
        [Required]
        public string Floor { get; set; }

        // Navigation property (if needed)
        public ICollection<Booking>? Bookings { get; set; }
    }

    public class LVA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string Leader { get; set; }

        [StringLength(255)]
        [Required]
        public string Type { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [StringLength(255)]
        [Required]
        public string Rhythm { get; set; }

        // Navigation property (if needed)
        public ICollection<Booking>? Bookings { get; set; }
    }

    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int LvaId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        // Navigation properties
        [InverseProperty("Bookings")]
        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }

        [InverseProperty("Bookings")]
        [ForeignKey(nameof(LvaId))]
        public LVA LVA { get; set; }
    }
}

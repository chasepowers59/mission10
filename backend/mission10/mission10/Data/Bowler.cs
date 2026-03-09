using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mission10.Data
{
    [Table("Bowlers")]
    public class Bowler
    {
        [Key]
        [Column("BowlerID")]
        public int BowlerID { get; set; }

        [Column("BowlerFirstName")]
        public string BowlerFirstName { get; set; } = null!;

        [Column("BowlerMiddleInit")]
        public string? BowlerMiddleInit { get; set; }

        [Column("BowlerLastName")]
        public string BowlerLastName { get; set; } = null!;

        [Column("BowlerAddress")]
        public string? BowlerAddress { get; set; }

        [Column("BowlerCity")]
        public string? BowlerCity { get; set; }

        [Column("BowlerState")]
        public string? BowlerState { get; set; }

        [Column("BowlerZip")]
        public string? BowlerZip { get; set; }

        [Column("BowlerPhoneNumber")]
        public string? BowlerPhoneNumber { get; set; }

        [Column("TeamID")]
        public int? TeamID { get; set; }

        public Team? Team { get; set; }
    }
}
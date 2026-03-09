using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mission10.Data
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        [Column("TeamID")]
        public int TeamID { get; set; }

        [Column("TeamName")]
        public string TeamName { get; set; } = null!;

        public List<Bowler> Bowlers { get; set; } = new();
    }
}
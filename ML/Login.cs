using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ML;

public class Login
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(User))]
    public int User_id { get; set; }

    public int Extension { get; set; }

    public int TipoMov { get; set; }

    public DateTime Fecha { get; set; }

    public User User { get; set; }
}
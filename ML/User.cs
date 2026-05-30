using System.ComponentModel.DataAnnotations;

namespace ML;

public class User
{
    [Key]
    public int User_id { get; set; }

    public string Login { get; set; } = string.Empty;

    public string Nombres { get; set; } = string.Empty;

    public string ApellidoPaterno { get; set; } = string.Empty;

    public string ApellidoMaterno { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public int TipoUser { get; set; }

    public int Status { get; set; }

    public DateTime fCreate { get; set; }

    public int IDArea { get; set; }

    public DateTime? LastLoginAttempt { get; set; }
}


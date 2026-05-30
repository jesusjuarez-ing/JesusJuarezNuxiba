using System.ComponentModel.DataAnnotations;

namespace ML;

public class Area
{
    [Key]
    public int IDArea { get; set; }

    public string AreaName { get; set; } = string.Empty;

    public int StatusArea { get; set; }

    public DateTime CreateDate { get; set; }
}
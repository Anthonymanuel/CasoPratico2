using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class FilmText
{
    public int FilmId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CasoPratico2Models.Models;

public class Language :ClaseBase
{
    public int LanguageId { get; set; }

    public string Name { get; set; } = string.Empty;
}

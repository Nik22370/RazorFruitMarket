using System.ComponentModel.DataAnnotations;

namespace Fruitmarket;

public record Address([MaxLength(255)] string Street, [MaxLength(255)] string StreetNumber);
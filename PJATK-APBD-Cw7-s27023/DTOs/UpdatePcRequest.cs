using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw7_s27023.DTOs;

public record UpdatePcRequest(
    [MaxLength(50), Required]
    string Name,
    [Required]
    double Weight,
    [Required]
    int Warranty,
    [Required]
    DateTime CreatedAt,
    [Required]
    int Stock
);
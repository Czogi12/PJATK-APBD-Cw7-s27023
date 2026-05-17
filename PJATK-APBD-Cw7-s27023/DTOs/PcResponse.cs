namespace PJATK_APBD_Cw7_s27023.DTOs;

public record PcResponse(
    int Id,
    string Name,
    double Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
    );
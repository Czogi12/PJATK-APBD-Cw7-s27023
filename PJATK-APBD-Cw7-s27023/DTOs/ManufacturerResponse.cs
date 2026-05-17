namespace PJATK_APBD_Cw7_s27023.DTOs;

public record ManufacturerResponse(
    int Id,
    string Abbreviation,
    string FullName,
    DateOnly FoundationDate
);
namespace PJATK_APBD_Cw7_s27023.DTOs;

public record ComponentResponse(
    string Code,
    string Name,
    string Description,
    ManufacturerResponse Manufacturer,
    ComponentTypeResponse Type
);
namespace PJATK_APBD_Cw7_s27023.Models;

public class Component
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }
    public ICollection<PCComponent> PCComponents { get; set; } = [];
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    public ComponentType ComponentType { get; set; } = null!;
}
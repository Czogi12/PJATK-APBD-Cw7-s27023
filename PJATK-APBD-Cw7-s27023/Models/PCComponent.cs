namespace PJATK_APBD_Cw7_s27023.Models;

public class PCComponent
{
    public int PCId { get; set; }
    public string ComponentCode { get; set; }
    public int Amount { get; set; }
    public Component Component { get; set; } = null!;
    public PC Pc { get; set; } = null!;
}
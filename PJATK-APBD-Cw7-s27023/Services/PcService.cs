using PJATK_APBD_Cw7_s27023.DTOs;
using PJATK_APBD_Cw7_s27023.Models;

namespace PJATK_APBD_Cw7_s27023.Services;

public class PcService : IPcService
{
    public Task<IEnumerable<PcResponse>> GetAll(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PCComponent>> GetAllComponents(int pcId, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
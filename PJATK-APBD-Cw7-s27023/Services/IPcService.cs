using PJATK_APBD_Cw7_s27023.DTOs;

namespace PJATK_APBD_Cw7_s27023.Services;

public interface IPcService
{
    public Task<IEnumerable<PcResponse>> GetAll(CancellationToken token);
    public Task<PcWithComponentsResponse?> GetAllComponents(int pcId, CancellationToken token);
    Task<PcResponse> Create(CreatePcRequest request, CancellationToken token);
    Task<bool> Update(int pcId, UpdatePcRequest request, CancellationToken token);
    Task<bool> Delete(int pcId, CancellationToken token);
}
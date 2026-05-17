using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s27023.DTOs;
using PJATK_APBD_Cw7_s27023.Infrastructure;
using PJATK_APBD_Cw7_s27023.Models;

namespace PJATK_APBD_Cw7_s27023.Services;

public class PcService(DatabaseContext ctx) : IPcService
{
    public async Task<IEnumerable<PcResponse>> GetAll(CancellationToken token)
    {
        return await ctx.PCs
            .AsNoTracking()
            .Select(pc => new PcResponse(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock))
            .ToListAsync(token);
    }

    public async Task<PcWithComponentsResponse?> GetAllComponents(int pcId, CancellationToken token)
    {
        return await ctx.PCs
            .AsNoTracking()
            .Where(pc => pc.Id == pcId)
            .Select(pc => new PcWithComponentsResponse(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.PCComponents.Select(pcc => new PcComponentItemResponse(
                    pcc.Amount,
                    new ComponentResponse(
                        pcc.Component.Code,
                        pcc.Component.Name,
                        pcc.Component.Description,
                        new ManufacturerResponse(
                            pcc.Component.ComponentManufacturer.Id,
                            pcc.Component.ComponentManufacturer.Abbreviation,
                            pcc.Component.ComponentManufacturer.FullName,
                            pcc.Component.ComponentManufacturer.FoundationDate),
                        new ComponentTypeResponse(
                            pcc.Component.ComponentType.Id,
                            pcc.Component.ComponentType.Abbreviation,
                            pcc.Component.ComponentType.Name))))
                .ToList()))
            .FirstOrDefaultAsync(token);
    }

    public async Task<PcResponse> Create(CreatePcRequest request, CancellationToken token)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.PCs.Add(pc);
        await ctx.SaveChangesAsync(token);

        return new PcResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock);
    }

    public async Task<bool> Update(int pcId, UpdatePcRequest request, CancellationToken token)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(p => p.Id == pcId, token);
        if (pc is null) return false;

        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;

        await ctx.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> Delete(int pcId, CancellationToken token)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(p => p.Id == pcId, token);
        if (pc is null) return false;

        ctx.PCs.Remove(pc);
        await ctx.SaveChangesAsync(token);
        return true;
    }
}
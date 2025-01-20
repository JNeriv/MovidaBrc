using Microsoft.EntityFrameworkCore;
using MovidaBrc.Data;
using MovidaBrcSharedLibrary.Contracts;
using MovidaBrcSharedLibrary.Models;
using MovidaBrcSharedLibrary.Responses;

namespace MovidaBrc.Repositories
{
    public class FiestaRepository : IFiesta
    {
        private readonly AppDbContext appDbContext;

        public FiestaRepository(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddFiesta(Fiesta model)
        {
            if (model is null)
                return new ServiceResponse(false, "La fiesta está vacía");
                var (flag, message) = await CheckName(model.NombreFiesta);
            if (flag)
            {
                appDbContext.Fiestas.Add(model);
                await Commit();
                return new ServiceResponse(true, "Fiesta guardada");
            }
            return new ServiceResponse(flag, message);
        }

        public async Task<List<Fiesta>> GetAllFiestas()
        {
                return await appDbContext.Fiestas.OrderBy(f => f.FechaRealizacionFiesta).ToListAsync();
        }

        private async Task<ServiceResponse> CheckName(string name)
        {
            var fiesta = await appDbContext.Fiestas.FirstOrDefaultAsync(x => x.NombreFiesta.ToLower()!.Equals(name.ToLower()));
            return fiesta is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "La fiesta ya existe");
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}

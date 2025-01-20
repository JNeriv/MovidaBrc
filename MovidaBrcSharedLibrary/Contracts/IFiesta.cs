using MovidaBrcSharedLibrary.Models;
using MovidaBrcSharedLibrary.Responses;

namespace MovidaBrcSharedLibrary.Contracts
{
    public interface IFiesta
    {
        Task<List<Fiesta>> GetAllFiestas();
        Task<ServiceResponse> AddFiesta(Fiesta model);

    }
}

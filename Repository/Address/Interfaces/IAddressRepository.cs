using AddressService.Request.Address;
using AddressService.Response.Address;
using Microsoft.AspNetCore.Mvc;

namespace AddressService.Repository.Address.Interfaces
{
    public interface IAddressRepository
    {
        Task DeleteAsync(int id);
        Task PutAsync(AddressRequest address);
        Task PostAsync(AddressRequest address);
        Task<List<AddressResponse>> GetAllAsync();
        Task<AddressResponse> GetAsync(int id);
    }
}

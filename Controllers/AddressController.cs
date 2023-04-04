using AddressService.Repository.Address.Interfaces;
using AddressService.Request.Address;
using AddressService.Response.Address;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AddressService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddressResponse>>> GetAll()
        {
            return Ok(await _addressRepository.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<AddressResponse>> Get(int id)
        {
            return Ok(await _addressRepository.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddressRequest address)
        {
            await _addressRepository.PostAsync(address);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AddressRequest address)
        {
            await _addressRepository.PutAsync(address);

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _addressRepository.DeleteAsync(id);

            return Ok();
        }
    }
}
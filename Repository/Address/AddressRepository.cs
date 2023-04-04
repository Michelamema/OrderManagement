using AddressService.Data;
using AddressService.Repository.Address.Interfaces;
using AddressService.Request.Address;
using AddressService.Response.Address;
using Microsoft.EntityFrameworkCore;
using AddressService.Response.User;

namespace AddressService.Repository.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ILogger _logger;
        private readonly DataContext _dbContext;

        public AddressRepository(ILogger<AddressRepository> logger, DataContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _dbContext.Address.Where(address => address.Id == id).FirstOrDefaultAsync();

            if (address == null)
                throw new Exception("Does not exist address with id " + id);

            await _dbContext.Address.Where(address => address.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<AddressResponse>> GetAllAsync()
        {
            var addresses = await _dbContext.Address.ToListAsync();

            var response = new List<AddressResponse>();

            foreach (var address in addresses)
            {
                response.Add(AddressMap(address));
            }

            return response;
        }

        public async Task<AddressResponse> GetAsync(int id)
        {
            var address = await _dbContext.Address.Where(address => address.Id == id).FirstOrDefaultAsync();

            if (address == null)
            {
                _logger.LogInformation($"No Record found for Addresses with id: {id}");

                return null; //For frontend
            }

            var response = AddressMap(address);

            return response;
        }

        public async Task PostAsync(AddressRequest addressRequest)
        {
            var address = new Entities.Address 
            { 
                City = addressRequest.City ?? "", //TODO: for exercise sake I've not implemented a validation on the api gateway checking that the request has the expected values populated
                Code = addressRequest.Code ?? "", 
                Country = addressRequest.Country ?? "", 
                Number = addressRequest.Number ?? "", 
                Predefined = addressRequest.Predefined, 
                Street = addressRequest.Street ?? "",
                UserId = addressRequest.UserId, 
                ZipCode = addressRequest.ZipCode ?? "", 
                Description = addressRequest.Description, 
            };

            await _dbContext.AddAsync(address);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutAsync(AddressRequest addressRequest)
        {
            if (addressRequest == null)
                throw new Exception("Body null");

            var address = await _dbContext.Address.Where(address => address.Id == addressRequest.Id).FirstOrDefaultAsync();

            address.Id = addressRequest.Id;
            address.City = addressRequest.City ?? ""; //TODO: for exercise sake I've not implemented a validation on the api gateway checking that the request has the expected values populated
            address.Code = addressRequest.Code ?? "";
            address.Country = addressRequest.Country ?? "";
            address.Number = addressRequest.Number ?? "";
            address.Predefined = addressRequest.Predefined;
            address.Street = addressRequest.Street ?? "";
            address.UserId = addressRequest.UserId;
            address.ZipCode = addressRequest.ZipCode ?? "";
            address.Description = addressRequest.Description;

            await _dbContext.SaveChangesAsync();
        }

        #region private

        private static AddressResponse AddressMap(Entities.Address address)
        {
            UserResponse user = new UserResponse();
            if (address.User != null)
                 user = new UserResponse
                {
                    Id = address.User.Id,
                    Code = address.User.Code,
                    Company = address.User.Company,
                    FiscalCode = address.User.FiscalCode,
                    Name = address.User.Name,
                    Surname = address.User.Surname,
                    UserType = address.User.UserType,
                    VATCode = address.User.VATCode
                };

            var response = new AddressResponse
            {
                Id = address.Id,
                City = address.City,
                Code = address.Code,
                Country = address.Country,
                Description = address.Description,
                Number = address.Number,
                Predefined = address.Predefined,
                Street = address.Street,
                ZipCode = address.ZipCode,
                User = user
            };

            return response;
        }

        #endregion
    }
}

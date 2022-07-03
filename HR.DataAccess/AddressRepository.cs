using HR.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess
{
    public class AddressRepository : IGenericRepository<Address>
    {
        private readonly AppDbContext _dbcontext;
        public AddressRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Address> Create(Address address)
        {
            await _dbcontext.Addresses.AddAsync(address);
            await _dbcontext.SaveChangesAsync();
            return address;
        }

        public async Task<bool> Delete(int id)
        {
            var address = await _dbcontext.Addresses.FindAsync(id);
            if (address != null)
            {
                _dbcontext.Addresses.Remove(address);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<Address> Get(int id)
        {
            return await _dbcontext.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _dbcontext.Addresses.ToListAsync();
        }


        public async Task<Address> Update(int id, Address address)
        {
            var updatedAddress = _dbcontext.Addresses.Attach(address);
            updatedAddress.State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return address;
        }

    }
}

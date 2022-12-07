using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Contracts
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Cliente>> getCustomers();
        public Task<int> createCustomers(Cliente dataCliente);

     
    }
}

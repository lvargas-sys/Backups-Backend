using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Contracts
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Cliente>> getCustomers();
        public Task<IEnumerable<Cliente>> getCustomerIdCliente(int id_cliente);
        public Task<bool> createCustomers(Cliente dataCliente);

     
    }
}

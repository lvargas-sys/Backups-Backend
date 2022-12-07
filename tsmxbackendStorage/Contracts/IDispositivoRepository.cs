using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Contracts
{
    public interface IDispositivoRepository 
    {
        public Task<IEnumerable<Dispositivo>> getDevices();
        public Task<bool> createDevice(Dispositivo dataDispositivo);
      


    }
}

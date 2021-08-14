using Domain.Models.Interfaces;

namespace Service.Interfaces
{
    public interface IPowerPoleService
    {
        void AddPowerPole(string address, string latitude, string powerWire, string streetLight);
        void ValidateModelDataAnnotations(IPowerPole powerPole);

    }
}

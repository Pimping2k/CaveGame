using ServiceLocatorRelated;
using Unity.Cinemachine;

namespace Interfaces
{
    public interface ICameraService : IService
    {
        public CinemachineCamera CurrentCamera { get; }
    }
}
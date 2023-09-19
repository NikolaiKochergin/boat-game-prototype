using Source.Scripts.Data;

namespace Source.Scripts.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}
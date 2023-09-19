using Source.Scripts.Data;

namespace Source.Scripts.Services.PersistentProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}
using System.Collections.Generic;
using Source.Scripts.Services.PersistentProgress;

namespace Source.Scripts.Services.Factory
{
    public interface IGameFactory : IService
    {
        IEnumerable<ISavedProgressReader> ProgressReaders { get; }
        IEnumerable<ISavedProgress> ProgressWriters { get; }
        void CleanUp();
    }
}
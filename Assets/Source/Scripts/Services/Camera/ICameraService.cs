using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Source.Scripts.Services.Camera
{
    public interface ICameraService : IService
    {
        UniTaskVoid SetTrackPoint(Transform transform);
    }
}
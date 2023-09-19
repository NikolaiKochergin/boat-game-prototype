using UnityEngine;

namespace Source.Scripts.Services.Camera
{
    public interface ICameraService : IService
    {
        void SetTrackPoint(Transform transform);
    }
}
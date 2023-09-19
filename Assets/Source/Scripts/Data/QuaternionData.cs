using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class QuaternionData
    {
        public float X, Y, Z, W;
        
        public QuaternionData(float x, float y, float z, float w) =>
            (X, Y, Z, W) = (x, y, z, w);
    }
}
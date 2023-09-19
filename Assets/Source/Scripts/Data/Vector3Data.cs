using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class Vector3Data
    {
        public float X, Y, Z;

        public Vector3Data(float x, float y, float z) => 
            (X, Y, Z) = (x, y, z);
    }
}
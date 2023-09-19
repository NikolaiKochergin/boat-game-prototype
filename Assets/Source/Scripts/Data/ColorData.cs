using System;

namespace Source.Scripts.Data
{
    [Serializable]
    public class ColorData
    {
        public float R, G, B, A;

        public ColorData(float r, float g, float b, float a) =>
            (R, G, B, A) = (r, g, b, a);
    }
}
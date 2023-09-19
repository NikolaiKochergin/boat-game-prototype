using System;
using UnityEngine;

namespace Source.Scripts.Data
{
    public static class DataExtensions
    {
        public static Vector3Data AsDataVector(this Vector3 vector) =>
            new Vector3Data(vector.x, vector.y, vector.z);

        public static Vector3 AsUnityVector(this Vector3Data vector3Data) =>
            new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);

        public static QuaternionData AsDataQuaternion(this Quaternion quaternion) =>
            new QuaternionData(quaternion.x, quaternion.y, quaternion.z, quaternion.w);

        public static Quaternion AsUnityQuaternion(this QuaternionData quaternionData) =>
            new Quaternion(quaternionData.X, quaternionData.Y, quaternionData.Z, quaternionData.W);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static ColorData AsDataColor(this Color color) => 
            new ColorData(color.r, color.g, color.b, color.a);

        public static Color AsUnityColor(this ColorData colorData) =>
            new Color(colorData.R, colorData.G, colorData.B, colorData.A);

        public static TimeSpanData AsDataTimeSpan(this TimeSpan timeSpan) => 
            new TimeSpanData(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

        public static TimeSpan AsTimeSpan(this TimeSpanData timeSpanData) => 
            new TimeSpan(timeSpanData.Hours, timeSpanData.Minutes, timeSpanData.Seconds);

        public static string ToEncrypt(this string str)
        {
            char[] characters = str.ToCharArray();

            for (int i = 0; i < characters.Length - 1; i += 2)
                (characters[i], characters[i + 1]) = (characters[i + 1], characters[i]);

            return new string(characters);
        }

        public static string ToDecrypt(this string str)
        {
            char[] characters = str.ToCharArray();

            for (int i = 0; i < characters.Length - 1; i += 2)
                (characters[i], characters[i + 1]) = (characters[i + 1], characters[i]);

            return new string(characters);
        }
    }
}
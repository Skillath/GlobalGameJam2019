using GGJ2019.Core.Models;

namespace UnityEngine
{
    public static class VectorExtensionMethods
    {
        public static Vector3 ToVector3(this Vector vector) => new Vector3(vector.X, vector.Y, vector.Z);

        public static Vector ToVector(this Vector3 vector) => new Vector(vector.x, vector.y, vector.z);
    }
}

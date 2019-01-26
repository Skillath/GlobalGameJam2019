namespace GGJ2019.Core.Models
{
    public struct Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector(float x = 0, float y = 0, float z = 0) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator +(Vector one, Vector two) => new Vector(one.X + two.X, one.Y + two.Y, one.Z + two.Z);

        public static Vector operator -(Vector one, Vector two) => new Vector(one.X - two.X, one.Y - two.Y, one.Z - two.Z);

        public static Vector operator *(Vector one, float n) => new Vector(one.X * n, one.Y * n, one.Z * n);

        public static Vector operator /(Vector one, float n) => new Vector(one.X / n, one.Y / n, one.Z / n);

        public static bool operator ==(Vector one, Vector two) => one.X == two.X && one.Y == two.Y && one.Z == two.Z;

        public static bool operator !=(Vector one, Vector two) => !(one == two);

        public override string ToString() => $"({X}, {Y}, {Z})";

        public override bool Equals(object obj)
        {
            if (!(obj is Vector))
            {
                return false;
            }

            var vector = (Vector)obj;
            return X == vector.X &&
                   Y == vector.Y &&
                   Z == vector.Z;
        }

        public override int GetHashCode()
        {
            var hashCode = -307843816;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Z.GetHashCode();
            return hashCode;
        }
    }
}

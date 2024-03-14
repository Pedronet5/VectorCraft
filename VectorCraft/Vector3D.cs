namespace VectorCraft
{
    public class Vector3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Create a vector with given components
        public static Vector3D Create(double x, double y, double z)
        {
            return new Vector3D(x, y, z);
        }

        // Reverse/negate a vector
        public Vector3D Negate()
        {
            return new Vector3D(-X, -Y, -Z);
        }

        // Addition of two vectors
        public Vector3D Add(Vector3D v)
        {
            return new Vector3D(X + v.X, Y + v.Y, Z + v.Z);
        }

        // Subtraction of two vectors
        public Vector3D Subtract(Vector3D v)
        {
            return new Vector3D(X - v.X, Y - v.Y, Z - v.Z);
        }

        // Multiplication of a vector with a scalar
        public Vector3D Multiply(double scalar)
        {
            return new Vector3D(X * scalar, Y * scalar, Z * scalar);
        }

        // Division of a vector by a scalar
        public Vector3D Divide(double scalar)
        {
            if (Math.Abs(scalar) < double.Epsilon)
                throw new DivideByZeroException("Cannot divide by zero.");
            return new Vector3D(X / scalar, Y / scalar, Z / scalar);
        }

        // Dot product of two vectors
        public double DotProduct(Vector3D v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        // Cross product of two vectors
        public Vector3D CrossProduct(Vector3D v)
        {
            return new Vector3D(
                Y * v.Z - Z * v.Y,
                Z * v.X - X * v.Z,
                X * v.Y - Y * v.X);
        }

        // Length of a vector
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        // Angle between two vectors (in radians)
        public double AngleBetween(Vector3D v)
        {
            double dotProduct = DotProduct(v);
            double lengthProduct = Length() * v.Length();
            return Math.Acos(dotProduct / lengthProduct);
        }

        // Equality check for vectors
        public bool Equals(Vector3D v)
        {
            return Math.Abs(X - v.X) < double.Epsilon &&
                   Math.Abs(Y - v.Y) < double.Epsilon &&
                   Math.Abs(Z - v.Z) < double.Epsilon;
        }

        // Hash code for the vector
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}

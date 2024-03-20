//Decide on the following aspects and write down the reasons for your decisions:
//▪ Do you implement the 3D vector as a class or as a struct?
//I implemented Vector3D as a class because it allows for more flexibility(e.g., inheritance, reference semantics) and aligns better with the typical use case of a vector library.

//▪ Should a vector be immutable after it has been constructed or should it be possible to change the value of the components afterwards?
//The vector is immutable after construction to maintain consistency and prevent unexpected changes.

//▪ How do check if two vectors are equal or unequal? Do you overload the operators for equality and inequality or not?
//I overloaded the equality operator (==) to compare vectors based on their components.

//▪ How do you compute the hashcode of a vector?
//I combine the values X, Y, Z using a HashCode.Combine and this function return a hash of the combination

namespace VectorCraft
{
    public class Vector3D : IVector3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Vector3D(){}
        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Create a vector with given components
        public Vector3D Create(double x, double y, double z)
        {
            return new Vector3D(x, y, z);
        }

        // Reverse/negate a vector
        public Vector3D Negate(Vector3D vector)
        {
            return new Vector3D(-vector.X, -vector.Y, -vector.Z);
        }

        // Addition of two vectors
        public Vector3D Add(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(Math.Round(vector1.X + vector2.X, 2), 
                                Math.Round(vector1.Y + vector2.Y, 2), 
                                Math.Round(vector1.Z + vector2.Z, 2));
        }

        // Subtraction of two vectors
        public Vector3D Subtract(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(Math.Round(vector1.X - vector2.X, 2), 
                                Math.Round(vector1.Y - vector2.Y, 2), 
                                Math.Round(vector1.Z - vector2.Z, 2));
        }

        // Multiplication of a vector with a scalar
        public Vector3D Multiply(Vector3D vector, double scalar)
        {
            return new Vector3D(Math.Round(vector.X * scalar, 2), 
                                Math.Round(vector.Y * scalar, 2), 
                                Math.Round(vector.Z * scalar, 2));
        }

        // Division of a vector by a scalar
        public Vector3D Divide(Vector3D vector, double scalar)
        {
            if (Math.Abs(scalar) < double.Epsilon)
                throw new DivideByZeroException("Cannot divide by zero.");

            return new Vector3D(Math.Round(vector.X / scalar, 2), 
                                Math.Round(vector.Y / scalar, 2), 
                                Math.Round(vector.Z / scalar, 2));
        }

        // Dot product of two vectors
        public double DotProduct(Vector3D vector1, Vector3D vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        // Cross product of two vectors
        public Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(
                Math.Round(vector1.Y * vector2.Z - vector1.Z * vector2.Y, 2),
                Math.Round(vector1.Z * vector2.X - vector1.X * vector2.Z, 2),
                Math.Round(vector1.X * vector2.Y - vector1.Y * vector2.X, 2));
        }

        // Length of a vector
        public double Length(Vector3D vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z);
        }

        // Angle between two vectors (in radians)
        public double AngleBetween(Vector3D vector1, Vector3D vector2)
        {
            double dotProduct = DotProduct(vector1, vector2);
            double lengthProduct = Length(vector1) * Length(vector2);
            return Math.Acos(dotProduct / lengthProduct);
        }

        // Equality check for vectors
        public bool Equals(Vector3D vector1, Vector3D vector2)
        {
            return Math.Abs(vector1.X - vector2.X) < double.Epsilon &&
                   Math.Abs(vector1.Y - vector2.Y) < double.Epsilon &&
                   Math.Abs(vector1.Z - vector2.Z) < double.Epsilon;
        }

        // Hash code for the vector
        public int GetHashCode(Vector3D vector)
        {
            return HashCode.Combine(vector.X, vector.Y, vector.Z);
        }
    }
}

﻿//Decide on the following aspects and write down the reasons for your decisions:
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
            return new Vector3D(Math.Round(X + v.X, 2), Math.Round(Y + v.Y, 2), Math.Round(Z + v.Z, 2));
        }

        // Subtraction of two vectors
        public Vector3D Subtract(Vector3D v)
        {
            return new Vector3D(Math.Round(X - v.X, 2), Math.Round(Y - v.Y, 2), Math.Round(Z - v.Z, 2));
        }

        // Multiplication of a vector with a scalar
        public Vector3D Multiply(double scalar)
        {
            return new Vector3D(Math.Round(X * scalar, 2), Math.Round(Y * scalar, 2), Math.Round(Z * scalar, 2));
        }

        // Division of a vector by a scalar
        public Vector3D Divide(double scalar)
        {
            if (Math.Abs(scalar) < double.Epsilon)
                throw new DivideByZeroException("Cannot divide by zero.");

            return new Vector3D(Math.Round(X / scalar, 2), Math.Round(Y / scalar, 2), Math.Round(Z / scalar, 2));
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
                Math.Round(Y * v.Z - Z * v.Y, 2),
                Math.Round(Z * v.X - X * v.Z, 2),
                Math.Round(X * v.Y - Y * v.X, 2));
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

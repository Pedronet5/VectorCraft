namespace VectorCraft
{
    public interface IVector3D
    {
        Vector3D Create(double x, double y, double z);
        Vector3D Negate(Vector3D vector);
        Vector3D Add(Vector3D vector1, Vector3D vector2);
        Vector3D Subtract(Vector3D vector1, Vector3D vector2);
        Vector3D Multiply(Vector3D vector, double scalar);
        Vector3D Divide(Vector3D vector, double scalar);
        double DotProduct(Vector3D vector1, Vector3D vector2);
        Vector3D CrossProduct(Vector3D vector1, Vector3D vector2);
        double Length(Vector3D vector);
        double AngleBetween(Vector3D vector1, Vector3D vector2);
        bool Equals(Vector3D vector1, Vector3D vector2);
        int GetHashCode(Vector3D vector);
    }
}
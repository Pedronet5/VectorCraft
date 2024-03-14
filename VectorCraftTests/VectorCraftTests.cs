namespace VectorCraft.Tests
{
    [TestClass]
    public class VectorCraftTests
    {
        [TestMethod]
        public void TestVectorAddition()
        {
            // Arrange
            var vector1 = new Vector3D(1, 2, 3);
            var vector2 = new Vector3D(4, 5, 6);

            // Act
            var result = vector1.Add(vector2);

            // Assert
            Assert.AreEqual(5, result.X);
            Assert.AreEqual(7, result.Y);
            Assert.AreEqual(9, result.Z);
        }

        [TestMethod]
        public void TestVectorSubtraction()
        {
            // Arrange
            var vector1 = new Vector3D(4, 5, 6);
            var vector2 = new Vector3D(1, 2, 3);

            // Act
            var result = vector1.Subtract(vector2);

            // Assert
            Assert.AreEqual(3, result.X);
            Assert.AreEqual(3, result.Y);
            Assert.AreEqual(3, result.Z);
        }

        [TestMethod]
        public void TestVectorCrossProduct()
        {
            // Arrange
            var vector1 = new Vector3D(1, 0, 0);
            var vector2 = new Vector3D(0, 1, 0);

            // Act
            var result = vector1.CrossProduct(vector2);

            // Assert
            Assert.AreEqual(0, result.X);
            Assert.AreEqual(0, result.Y);
            Assert.AreEqual(1, result.Z);
        }

        [TestMethod]
        public void TestVectorLength()
        {
            // Arrange
            var vector = new Vector3D(3, 4, 12);

            // Act
            var length = vector.Length();

            // Assert
            Assert.AreEqual(13, length, 1e-6); // Using epsilon for floating-point comparison
        }

        [TestMethod]
        public void TestVectorDotProduct()
        {
            // Arrange
            var vector1 = new Vector3D(1, 2, 3);
            var vector2 = new Vector3D(4, 5, 6);

            // Act
            var dotProduct = vector1.DotProduct(vector2);

            // Assert
            Assert.AreEqual(32, dotProduct);
        }

        [TestMethod]
        public void TestVectorScalarMultiplication()
        {
            // Arrange
            var vector = new Vector3D(2, 3, 4);
            var scalar = 5;

            // Act
            var result = vector.Multiply(scalar);

            // Assert
            Assert.AreEqual(10, result.X);
            Assert.AreEqual(15, result.Y);
            Assert.AreEqual(20, result.Z);
        }

        [TestMethod]
        public void TestVectorAngleBetween()
        {
            // Arrange
            var vector1 = new Vector3D(1, 0, 0);
            var vector2 = new Vector3D(0, 1, 0);

            // Act
            var angle = vector1.AngleBetween(vector2);

            // Assert
            Assert.AreEqual(Math.PI / 2, angle, 1e-6); // Using epsilon for floating-point comparison
        }


        [TestMethod]
        public void TestVectorEquality()
        {
            // Arrange
            var vector1 = new Vector3D(2, 3, 4);
            var vector2 = new Vector3D(2, 3, 4);

            // Act
            var areEqual = vector1.Equals(vector2);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestVectorHashCode()
        {
            // Arrange
            var vector1 = new Vector3D(2, 3, 4);
            var vector2 = new Vector3D(2, 3, 4);

            // Act
            var hashCode1 = vector1.GetHashCode();
            var hashCode2 = vector2.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }
    }
}
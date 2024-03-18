namespace VectorCraft.Tests
{
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VectorCraftTests
    {
        public static IEnumerable<object[]> GetAdditionTestData()
        {
            yield return new object[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 5.0, 7.0, 9.0 };
            yield return new object[] { -1.0, 2.0, -3.0, 4.0, -5.0, 6.0, 3.0, -3.0, 3.0 };
        }

        public static IEnumerable<object[]> GetSubtractionTestData()
        {
            yield return new object[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, -3.0, -3.0, -3.0 };
            yield return new object[] { -1.0, 2.0, -3.0, 4.0, -5.0, 6.0, -5.0, 7.0, -9.0 };
        }


        [DataTestMethod]
        [DynamicData(nameof(GetAdditionTestData), DynamicDataSourceType.Method)]
        public void TestVectorAddition(
            double x1,
            double y1,
            double z1,
            double x2,
            double y2,
            double z2,
            double expectedX,
            double expectedY,
            double expectedZ)
        {
            // Arrange
            var vector1 = new Vector3D(x1, y1, z1);
            var vector2 = new Vector3D(x2, y2, z2);

            // Act
            var result = vector1.Add(vector2);

            // Assert
            Assert.AreEqual(expectedX, result.X, 1e-6);
            Assert.AreEqual(expectedY, result.Y, 1e-6);
            Assert.AreEqual(expectedZ, result.Z, 1e-6);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetSubtractionTestData), DynamicDataSourceType.Method)]
        public void TestVectorSubtraction(
            double x1,
            double y1,
            double z1,
            double x2,
            double y2,
            double z2,
            double expectedX,
            double expectedY,
            double expectedZ)
        {
            // Arrange
            var vector1 = new Vector3D(x1, y1, z1);
            var vector2 = new Vector3D(x2, y2, z2);

            // Act
            var result = vector1.Subtract(vector2);

            // Assert
            Assert.AreEqual(expectedX, result.X, 1e-6); // Using epsilon for floating-point comparison
            Assert.AreEqual(expectedY, result.Y, 1e-6); // Using epsilon for floating-point comparison
            Assert.AreEqual(expectedZ, result.Z, 1e-6); // Using epsilon for floating-point comparison
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

        [TestMethod]
        public void Divide_ByNonZeroScalar_ReturnsCorrectResult()
        {
            // Arrange
            var vector = new Vector3D(3, 6, 9);
            double scalar = 2;

            // Act
            var result = vector.Divide(scalar);

            // Assert
            Assert.AreEqual(1.5, result.X, 0.01); // Tolerance for rounding
            Assert.AreEqual(3, result.Y, 0.01);
            Assert.AreEqual(4.5, result.Z, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ByZero_ThrowsException()
        {
            // Arrange
            var vector = new Vector3D(1, 2, 3);
            double scalar = 0;

            // Act
            var result = vector.Divide(scalar);

            // Assert (Exception is expected)
        }

        [TestMethod]
        public void Create_ReturnsVectorWithGivenComponents()
        {
            // Arrange
            double x = 1.5;
            double y = 2.0;
            double z = -3.7;

            // Act
            var result = Vector3D.Create(x, y, z);

            // Assert
            Assert.AreEqual(x, result.X, 0.01); // Tolerance for rounding
            Assert.AreEqual(y, result.Y, 0.01);
            Assert.AreEqual(z, result.Z, 0.01);
        }

        [TestMethod]
        public void Negate_ReturnsNegatedVector()
        {
            // Arrange
            var vector = new Vector3D(2, -4, 6);

            // Act
            var result = vector.Negate();

            // Assert
            Assert.AreEqual(-2, result.X, 0.01); // Tolerance for rounding
            Assert.AreEqual(4, result.Y, 0.01);
            Assert.AreEqual(-6, result.Z, 0.01);
        }
    }
}
using System;
using Xunit;
using MatrixWork;

namespace MatrixWorkTest
{
    public class MatrixTests
    {
        [Fact]
        public void Add_TwoMatrices_ReturnsCorrectResult()
        {
            // Arrange
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            var matrixB = new Matrix(2, 2, new double[,] { { 1, 1 }, { 1, 1 } });
            var expectedMatrix = new Matrix(2, 2, new double[,] { { 2, 3 }, { 4, 5 } });

            // Act
            var result = matrixA.Add(matrixB);

            // Assert
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void Multiply_TwoMatrices_ReturnsCorrectResult()
        {
            // Arrange
            var matrixA = new Matrix(2, 3, new double[,] { { 1, 0, 2 }, { 0, 3, 0 } });
            var matrixB = new Matrix(3, 2, new double[,] { { 0, 1 }, { 2, 0 }, { 1, 3 } });
            var expectedMatrix = new Matrix(2, 2, new double[,] { { 2, 7 }, { 6, 0 } });

            // Act
            var result = matrixA.Multiply(matrixB);

            // Assert
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void Multiply_MatrixByScalar_ReturnsCorrectResult()
        {
            // Arrange
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            var expectedMatrix = new Matrix(2, 2, new double[,] { { 2, 4 }, { 6, 8 } });

            // Act
            var result = matrixA.Multiply(2);

            // Assert
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void Transpose_Matrix_ReturnsCorrectResult()
        {
            // Arrange
            var matrixA = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            var expectedMatrix = new Matrix(3, 2, new double[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } });

            // Act
            var result = matrixA.Transpose();

            // Assert
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void ToString_MatrixTest_ReturnsCorrectString()
        {
            // Arrange
            var matrix = new Matrix(3, 3, new double[,] { { 1, 0, 2 }, { 0, 3, 0 }, { 4, 0, 5 } });
            var expectedString = "1\t0\t2\n0\t3\t0\n4\t0\t5";

            // Act
            var result = matrix.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }

        [Fact]
        public void Add_DifferentDimensions_ThrowsException()
        {
            // Arrange
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            var matrixB = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });

            // Act & Assert
            Assert.Throws<ArgumentException>(() => matrixA.Add(matrixB));
        }

        [Fact]
        public void Multiply_IncompatibleMatrices_ThrowsException()
        {
            // Arrange
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            var matrixB = new Matrix(3, 2, new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });

            // Act & Assert
            Assert.Throws<ArgumentException>(() => matrixA.Multiply(matrixB));
        }
    }
}
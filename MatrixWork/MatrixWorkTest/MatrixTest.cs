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

        /*add negative tests*/
        [Fact]
        public void Instantiate_InvalidDimensions_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Matrix(-1, 2, new double[,] { { 1, 2 }, { 3, 4 } }));
        }

        [Fact]
        public void Multiply_MatrixByZero_ReturnsZeroMatrix()
        {
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            var expectedMatrix = new Matrix(2, 2, new double[,] { { 0, 0 }, { 0, 0 } });
            var result = matrixA.Multiply(0);
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void Add_WithNullMatrix_ThrowsException()
        {
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            Assert.Throws<ArgumentNullException>(() => matrixA.Add(null));
        }

        [Fact]
        public void Multiply_WithNullMatrix_ThrowsException()
        {
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            Assert.Throws<ArgumentNullException>(() => matrixA.Multiply(null));
        }


        [Fact]
        public void Equals_WithNullMatrix_ReturnsFalse()
        {
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            Assert.False(matrixA.Equals(null));
        }

        [Fact]
        public void Multiply_MatrixByNegativeScalar_ReturnsCorrectResult()
        {
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            var expectedMatrix = new Matrix(2, 2, new double[,] { { -1, -2 }, { -3, -4 } });
            var result = matrixA.Multiply(-1);
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void Instantiate_InvalidDataLess_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Matrix(2, 2, new double[,] { { 1 } }));
        }

        [Fact]
        public void Instantiate_InvalidDataMore_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Matrix(2, 2, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } }));
        }

        [Fact]
        public void Equals_DifferentDimensions_ReturnsFalse()
        {
            // Arrange
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            var matrixB = new Matrix(2, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            // Act & Assert
            Assert.False(matrixA.Equals(matrixB));
        }

        [Fact]
        public void Multiply_IncompatibleDimensions2_ThrowsException()
        {
            // Arrange
            var matrixA = new Matrix(3, 3, new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            var matrixB = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });
            // Act & Assert
            Assert.Throws<ArgumentException>(() => matrixA.Multiply(matrixB));
        }

        /*negative test*/
        [Fact]
        public void Indexer_AccessOutOfBounds_ThrowsException()
        {
            // Arrange
            var matrix = new Matrix(2, 2, new double[,] { { 1, 2 }, { 3, 4 } });

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => matrix[2, 2]);
        }

        /* add test */
        [Fact]
        public void Add_TwoSparseMatrices_ReturnsSparseMatrix()
        {
            // Arrange
            var matrixA = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } });
            var matrixB = new Matrix(3, 3, new double[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } });
            var expectedMatrix = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            // Act
            var result = matrixA.Add(matrixB);
            // Assert
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void Multiply_TwoSparseMatrices_ReturnsSparseMatrix()
        {
            // Arrange
            var matrixA = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } });
            var matrixB = new Matrix(3, 3, new double[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } });
            var expectedMatrix = new Matrix(3, 3, new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } });
            // Act
            var result = matrixA.Multiply(matrixB);
            // Assert
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void Multiply_SparseMatrixByZero_ReturnsZeroMatrix()
        {
            // Arrange
            var matrixA = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            var expectedMatrix = new Matrix(3, 3, new double[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } });
            // Act
            var result = matrixA.Multiply(0);
            // Assert
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void Transpose_SparseMatrix_ReturnsSparseMatrix()
        {
            // Arrange
            var matrixA = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            var expectedMatrix = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            // Act
            var result = matrixA.Transpose();
            // Assert
            Assert.True(expectedMatrix.Equals(result));
        }

        [Fact]
        public void Add_DifferentSizeSparseMatrices_ThrowsException()
        {            
            // Arrange
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 0 }, { 0, 1 } });
            var matrixB = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            // Act & Assert
            Assert.Throws<ArgumentException>(() => matrixA.Add(matrixB));
        }

        [Fact]
        public void Multiply_IncompatibleSparseMatrices_ThrowsException()
        {
            // Arrange
            var matrixA = new Matrix(2, 2, new double[,] { { 1, 0 }, { 0, 1 } });
            var matrixB = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            // Act & Assert
            Assert.Throws<ArgumentException>(() => matrixA.Multiply(matrixB));
        }

        [Fact]
        public void Multiply_SparseMatrixByNonZeroScalar_ReturnsSparseMatrix()
        {
            // Arrange
            var matrixA = new Matrix(3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            var expectedMatrix = new Matrix(3, 3, new double[,] { { 2, 0, 0 }, { 0, 2, 0 }, { 0, 0, 2 } });
            // Act
            var result = matrixA.Multiply(2);
            // Assert
            Assert.True(expectedMatrix.Equals(result));
        }
    }
}
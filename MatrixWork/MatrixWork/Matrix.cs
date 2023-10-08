namespace MatrixWork
{
    public class Matrix : IMatrix
    {
        private int _rows;
        private int _cols;
        private double[,] _elements;

        public Matrix(int rows, int cols, double[,] initialData)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Matrix dimensions should be greater than 0.");

            _rows = rows;
            _cols = cols;
            _elements = initialData ?? new double[rows, cols];
        }

        public int Rows
        {
            get => _rows;
            set => _rows = value;
        }

        public int Cols
        {
            get => _cols;
            set => _cols = value;
        }

        public double this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= _rows || j < 0 || j >= _cols)
                    throw new IndexOutOfRangeException();
                return _elements[i, j];
            }
            set
            {
                if (i < 0 || i >= _rows || j < 0 || j >= _cols)
                    throw new IndexOutOfRangeException();
                _elements[i, j] = value;
            }
        }

        public Matrix Add(Matrix other)
        {
            if (_rows != other._rows || _cols != other._cols)
                throw new ArgumentException("Matrix dimensions do not match for addition.");

            var resultData = new double[_rows, _cols];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    resultData[i, j] = _elements[i, j] + other._elements[i, j];
                }
            }

            return new Matrix(_rows, _cols, resultData);
        }

        public Matrix Multiply(Matrix other)
        {
            if (_cols != other._rows)
                throw new ArgumentException("Matrix dimensions do not match for multiplication.");

            var resultData = new double[_rows, other._cols];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < other._cols; j++)
                {
                    resultData[i, j] = 0;
                    for (int k = 0; k < _cols; k++)
                    {
                        resultData[i, j] += _elements[i, k] * other._elements[k, j];
                    }
                }
            }

            return new Matrix(_rows, other._cols, resultData);
        }

        public IMatrix Add(IMatrix other)
        {
            if (other is Matrix matrix)
                return Add(matrix);
            throw new NotImplementedException("The provided matrix type is not supported.");
        }

        public IMatrix Multiply(IMatrix other)
        {
            if (other is Matrix matrix)
                return Multiply(matrix);
            throw new NotImplementedException("The provided matrix type is not supported.");
        }

        public IMatrix Multiply(double scalar)
        {
            var resultData = new double[_rows, _cols];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    resultData[i, j] = _elements[i, j] * scalar;
                }
            }

            return new Matrix(_rows, _cols, resultData);
        }

        public IMatrix Transpose()
        {
            var resultData = new double[_cols, _rows];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    resultData[j, i] = _elements[i, j];
                }
            }

            return new Matrix(_cols, _rows, resultData);
        }

        public bool Equals(IMatrix other)
        {
            if (other is Matrix matrix)
            {
                if (_rows != matrix._rows || _cols != matrix._cols)
                    return false;

                for (int i = 0; i < _rows; i++)
                {
                    for (int j = 0; j < _cols; j++)
                    {
                        if (_elements[i, j] != matrix._elements[i, j])
                            return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    sb.Append(_elements[i, j]);
                    if (j < _cols - 1)
                        sb.Append("\t");
                }

                if (i < _rows - 1)
                    sb.AppendLine();
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IMatrix);
        }

        public override int GetHashCode()
        {
            return _elements.GetHashCode();
        }
    }
}
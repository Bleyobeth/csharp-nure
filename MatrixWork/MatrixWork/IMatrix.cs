namespace MatrixWork
{
    /*
     * Set of instruments, where will be used for Matrix operations
     */
    public interface IMatrix
    {
        int Rows { get; set; }
        int Cols { get; set; }

        double this[int i, int j] { get; set; }

        IMatrix Add(IMatrix other);
        IMatrix Multiply(IMatrix other);
        IMatrix Multiply(double scalar);
        IMatrix Transpose();
       
    }
}
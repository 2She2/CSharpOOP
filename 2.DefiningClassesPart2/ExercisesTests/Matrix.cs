// 08. Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

// 09. Implement an indexer this[row, col] to access the inner matrix cells.

// 10. Implement the operators + and - (addition and subtraction of matrices of the same size)
//     and * for matrix multiplication. Throw an exception when the operation cannot be performed.
//     Implement the true operator (check for non-zero elements).


namespace Exercises
{
    using System;
    using System.Text;

    /// <summary>
    /// Holds matrix of numbers
    /// </summary>
    /// <typeparam name="T">Parameters type</typeparam>
    class Matrix<T> // Implement the following interfaces, so only numbers can be used
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>
    {
        private T[,] matrix;

        /// <summary>
        /// Initialize matrix with given size
        /// </summary>
        /// <param name="rows">Rows of the matrix</param>
        /// <param name="cols">Cols of the matrix</param>
        public Matrix(int rows, int cols)
        {
            // Minimum allowed size of the matrix is 1
            if (rows < 1 || cols < 1)
            {
                throw new ArgumentException("Matrix size must be 1 or grether!");
            }

            matrix = new T[rows, cols];
        }

        /// <summary>
        /// Indexator. Access matrix elements by row and col
        /// </summary>
        /// <param name="row">Row of matrix</param>
        /// <param name="col">Col of matrix</param>
        /// <returns>Elements at [row, col] position</returns>
        public T this[int row, int col]
        {
            get { return this.matrix[row, col]; }
            set
            {
                this.matrix[row, col] = value;
            }
        }

        /// <summary>
        /// Get count of rows
        /// </summary>
        public int GetRows
        {
            get { return matrix.GetLength(0); }
        }

        /// <summary>
        /// Get count of cols
        /// </summary>
        public int GetCols
        {
            get { return matrix.GetLength(1); }
        }

        /// <summary>
        /// Sum two matrices
        /// </summary>
        /// <param name="firstMatrix">First matrix to sum</param>
        /// <param name="secondMatrix">Second matrix to sum</param>
        /// <returns>Sum of matrices</returns>
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            // Check if matrices have the same size
            CheckMatricesSize(firstMatrix, secondMatrix);
            // Variable where the two matrices will be summed
            Matrix<T> sum = new Matrix<T>(firstMatrix.GetRows, secondMatrix.GetCols);

            // Iterate through the matrices and sum their values
            for (int row = 0; row < sum.GetRows; row++)
            {
                for (int col = 0; col < sum.GetCols; col++)
                {
                    // Use try catch block, in case where the user put some variable which is not a number
                    try
                    {
                        // "dynamic" allows us to use operator '+'
                        sum[row, col] = (dynamic)firstMatrix[row, col] + secondMatrix[row, col];
                    }
                    catch (ArithmeticException ex)
                    {
                        Console.Error.WriteLine("Operation '+' not allowed!" + ex.Message);
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Operation '+' not allowed!" + ex.Message);
                        throw;
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Subtract two matrices
        /// </summary>
        /// <param name="firstMatrix">Matrix to subtract from</param>
        /// <param name="secondMatrix">Matrix to subtract</param>
        /// <returns>Subtraction of matrices</returns>
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            // Check if matrices have the same size
            CheckMatricesSize(firstMatrix, secondMatrix);
            // Variable where the two matrices will be subtracted
            Matrix<T> division = new Matrix<T>(firstMatrix.GetRows, secondMatrix.GetCols);

            // Iterate through the matrices and subtract their values
            for (int row = 0; row < division.GetRows; row++)
            {
                for (int col = 0; col < division.GetCols; col++)
                {
                    // Use try catch block, in case where the user put some variable which is not a number
                    try
                    {
                        // "dynamic" allows us to use operator '-'
                        division[row, col] = (dynamic)firstMatrix[row, col] - secondMatrix[row, col];
                    }
                    catch (ArithmeticException ex)
                    {
                        Console.Error.WriteLine("Operation '-' not allowed!" + ex.Message);
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Operation '-' not allowed!" + ex.Message);
                        throw;
                    }
                }
            }

            return division;
        }

        /// <summary>
        /// Multiply two matrices
        /// </summary>
        /// <param name="firstMatrix">First matrix to multiply</param>
        /// <param name="secondMatrix">Second matrix to multiply</param>
        /// <returns>Product of mitrices</returns>
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            // Check if matrices have the same size
            CheckMatricesSize(firstMatrix, secondMatrix);
            // Variable where the two matrices will be multiplied
            Matrix<T> product = new Matrix<T>(firstMatrix.GetRows, secondMatrix.GetCols);

            // Iterate through the matrices and multiply their values
            for (int row = 0; row < product.GetRows; row++)
            {
                for (int col = 0; col < product.GetCols; col++)
                {
                    // Use try catch block, in case where the user put some variable which is not a number
                    try
                    {
                        // "dynamic" allows us to use operator '*'
                        product[row, col] = (dynamic)firstMatrix[row, col] * secondMatrix[row, col];
                    }
                    catch (ArithmeticException ex)
                    {
                        Console.Error.WriteLine("Operation '*' not allowed!" + ex.Message);
                        throw;
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Operation '*' not allowed!" + ex.Message);
                        throw;
                    }
                }
            }

            return product;
        }

        /// <summary>
        /// Check if some of the values of in the matrix is different from the default value
        /// </summary>
        /// <param name="matrix">Mtrix to check</param>
        /// <returns>true if matrix have non-zero elements</returns>
        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.GetRows; row++)
            {
                for (int col = 0; col < matrix.GetCols; col++)
                {
                    if ((dynamic)matrix[row, col] != default(T))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.GetRows; row++)
            {
                for (int col = 0; col < matrix.GetCols; col++)
                {
                    if ((dynamic)matrix[row, col] == default(T))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check if two matrices have the same size
        /// </summary>
        /// <param name="firstMatrix">First matrix</param>
        /// <param name="secondMatrix">Second Matrices</param>
        private static void CheckMatricesSize(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.GetRows != secondMatrix.GetRows || firstMatrix.GetCols != secondMatrix.GetCols)
            {
                throw new ArgumentException("Matrices must have the same size!");
            }
        }

        /// <summary>
        /// Set all values in the matrix to a string
        /// </summary>
        /// <returns>Return all values as a string</returns>
        public override string ToString()
        {
            StringBuilder matrixValues = new StringBuilder();

            for (int row = 0; row < this.GetRows; row++)
            {
                for (int col = 0; col < this.GetCols; col++)
                {
                    matrixValues.Append(this[row, col]);

                    if (col < this.GetCols - 1)
                    {
                        matrixValues.Append(", ");
                    }
                }

                if (row < this.GetRows - 1)
                {
                    matrixValues.AppendLine();
                }
            }

            return matrixValues.ToString();
        }
    }
}

namespace DeterminantCalculator;


public class DeterminantMethods
{
    /**
     * method calculates the determinant of a given matrix passed in
     */
    public static int determinantCalc(Matrix matrix)
    {   //anything larger than a 2x2 matrix
        if (matrix.getSize() > 2)
        {   //sum variable for the determinant
            int sum = 0;
            //calls zeroPriority to find if there is a row or column with more zeros present then the rest
            int[] zero_results = zeroPriority(matrix);
            //zero lane is a column
            if (zero_results[0] == 1)
            {
                //for loop moves through the zero column along each index
                for (int i = 0; i < matrix.getSize(); i++)
                {
                    //any index in the zero column that is 0 can be skipped, as it will ultimately evaluate to 0 
                    if (matrix.getMatrix()[i, zero_results[1]] != 0)
                    {
                        //lines 24 through 32 initialize the new matrix whose determinant will then be taken recursively and added to the sum variable
                        //the new matrix is made up of the indexes in the matrix minus any indexes present in the current coordinate's(i, zero_results[1]) row or column
                        int[,] nextMatrix = new int[matrix.getSize() - 1,matrix.getSize() - 1];
                        int y = 0;
                        for (int j = 0; j < matrix.getSize(); j++)
                        {
                            //ensures that the value is not in the current coordinates column
                            if (j != zero_results[1])
                            {
                                int x = 0;
                                for (int k = 0; k < matrix.getSize(); k++)
                                {   
                                    //ensures that the value is not in the current coordinates row
                                    if (k != i)
                                    {
                                        //value is added to the new matrix
                                        nextMatrix[x, y] = matrix.getMatrix()[k, j];
                                        x++;
                                    }
                                }
                                y++;
                            }
                        }
                        //determinant formula: (-1) ^ i + j * a(at i,j) * det M(i,j) is applied here
                         sum += (int)(Math.Pow(-1, (i + 1) + (zero_results[1] + 1)) * matrix.getMatrix()[i, zero_results[1]] * determinantCalc(new Matrix(nextMatrix)));
                    }
                }
                return sum;
            }
            //zero lane is a row
            else
            {
                for (int i = 0; i < matrix.getSize(); i++)
                {
                    //any index in the zero row that is zero can be skipped as it will ultimately evaluate to zero
                    if (matrix.getMatrix()[zero_results[1], i] != 0)
                    {
                        //lines 61 through 78 initialize the new matrix whose determinant will then be taken recursively and added to the sum variable
                        //the new matrix is made up of the indexes in the matrix minus any indexes present in the current coordinate's(zero_result[1], i) row or column
                        int[,] nextMatrix = new int[matrix.getSize() - 1, matrix.getSize() - 1];
                        int x = 0;
                        for (int j = 0; j < matrix.getSize(); j++)
                        {
                            //ensures that the value is not in the current coordinates row
                            if (j != zero_results[1])
                            {
                                int y = 0;
                                for (int k = 0; k < matrix.getSize(); k++)
                                {
                                    //ensures that the value is not in the current coordinates column
                                    if (k != i)
                                    {
                                        //value is added to the new matrix
                                        nextMatrix[x, y] = matrix.getMatrix()[j, k];
                                        y++;
                                    }
                                }
                                x++;
                            }
                        }
                        //determinant formula: (-1) ^ i + j * a(at i,j) * det M(i,j) is applied here
                        sum += (int)(Math.Pow(-1, (i +1) + (zero_results[1] + 1)) * matrix.getMatrix()[zero_results[1], i] * determinantCalc(new Matrix(nextMatrix)));
                    }
                }
                return sum;
            }
        }//2x2 matrix
        else
        {
            int a = matrix.getMatrix()[0, 0];
            int b = matrix.getMatrix()[1, 0];
            int c = matrix.getMatrix()[0, 1];
            int d = matrix.getMatrix()[1, 1];
            /**
             * given the matrix A: | a  b |
             *                     | c  d |
             *
             * the determinant of the given matrix can be calculated using the formula: det A = (a * d) - (b * c)
             */
            return (a * d) - (b * c);
        }

        return 0;
    }
    
    /**
     * zeroPriority method attempts to find either a row or column that contains the most zeros as to lessen the amount of mathmatical work to do later.
     * a array with 2 indexes is returned.
     *
     * the first index of the array tells the program whether the zero lane is a column (zeros[0] == 1) or...
     * the zero lane is a row (zeros[0] == 0).
     *
     * the second index of the zeros array indicates the number index the row or column can be found in.
     *
     * if there is no particular row or column with a larger amount of zeros than the rest, the default values {0,0} are returned in the array,
     * instructing the program to calculate the determinant across the first row.
     */
    private static int[] zeroPriority(Matrix matrix)
    {
        int[] zeros = new int[2];
        int[] rowZeroCount = new int[matrix.getSize()];
        int[] columnZeroCount = new int[matrix.getSize()];
        for (int i = 0; i < matrix.getSize(); i++)
        {
            for (int j = 0; j < matrix.getSize(); j++)
            {
                if (matrix.getMatrix()[i, j] == 0)
                {
                    rowZeroCount[i]++;
                }

                if (matrix.getMatrix()[j, i] == 0)
                {
                    columnZeroCount[i]++;
                }
            }
        }

        int highestZeroIndexR = 0, highestZeroIndexC = 0;
        for (int i = 1; i < matrix.getSize(); i++)
        {
            if (rowZeroCount[highestZeroIndexR] < rowZeroCount[i])
            {
                highestZeroIndexR = i;
            }

            if (columnZeroCount[highestZeroIndexC] < columnZeroCount[i])
            {
                highestZeroIndexC = i;
            }
        }

        if (columnZeroCount[highestZeroIndexC] > rowZeroCount[highestZeroIndexR])
        {
            zeros[0] = 1;
            zeros[1] = highestZeroIndexC;
        }
        else
        {
            zeros[0] = 0;
            zeros[1] = highestZeroIndexR;
        }
        return zeros;
    }
    
}
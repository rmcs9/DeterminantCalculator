namespace DeterminantCalculator;


public class Start
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Matrix determinant calculator!");
        Console.WriteLine("When entering data for ALL rows of the matrix, please ensure that each entry is seperated by 1 comma and NO whitespaces");
        Console.WriteLine("Example: 21,42,0,5,6");
        Console.WriteLine("On the Line below please enter the integers contained in row 1 of the matrix to begin!");

        string[] lines = Console.ReadLine().Split(',');
        Console.WriteLine("");
        int size = line.Length;

        Matrix matrix = new Matrix(size);
        matrix.AddLine(line);

        for (int i = 1; i < size; i++)
        {
            Console.WriteLine("Please enter row " + (matrix.getRowNumber() + 1) + ":");
            Console.WriteLine("");
            string[] lineArr = Console.ReadLine().Split(',');
            Console.WriteLine("");
            while (lineArr.Length != size)
            {
                if (lineArr.Length > size)
                {
                    Console.WriteLine("too many numbers inputted in this row. Excess numbers: " + (lineArr.Length - size));
                    Console.WriteLine("please enter the row again now:");
                    Console.WriteLine("");
                    lineArr = Console.ReadLine().Split(',');
                }
                else
                {
                    Console.WriteLine("too few numbers inputted in this row. Missing numbers: " + (size - lineArr.Length));
                    Console.WriteLine("please enter the row again now:");
                    Console.WriteLine("");
                    lineArr = Console.ReadLine().Split(',');
                }
            }
            
            matrix.AddLine(lineArr);
            if ((i + 1) != size)
            {
                Console.WriteLine("updated matrix: ");
                matrix.matrixPrint();
            }
        }
        
        Console.WriteLine("Matrix successfuly loaded:");
        matrix.matrixPrint();

        int matrixDeterminant = DeterminantMethods.determinantCalc(matrix);
        Console.WriteLine("Matrix determinant = " + matrixDeterminant);
    }
}

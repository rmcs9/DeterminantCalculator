namespace DeterminantCalculator;

public class Matrix
{
    private int rowNumber = 0;

    private int[,] matrix;

    private int size;

    public Matrix(int size)
    {
        this.matrix = new int[size, size];
        this.size = size;
    }
    
    public void AddLine(string[] lineTokens)
    {
        
        for (int i = 0; i < this.size; i++)
        {
            int value;
            if (int.TryParse(lineTokens[i], out value))
            {
                if (value >= 1000)
                {
                    Console.WriteLine("four digit numbers are not supported by this program. please enter a new number:");
                    if (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("entry is not a valid number, please enter a valid number into console:");
                        string newNum = Console.ReadLine();
                        while (!int.TryParse(newNum, out value))
                        {
                            Console.WriteLine("number is not valid, please try again");
                            newNum = Console.ReadLine();
                        }
                    }
                }
                this.matrix[rowNumber, i] = value;
            }
            else
            {
                Console.WriteLine(lineTokens[i] + " at position " + i + " is not a valid number, please enter a valid number into console:");
                string newNum = Console.ReadLine();
                while (!int.TryParse(newNum, out value))
                {
                    Console.WriteLine("number is not valid, please try again");
                    newNum = Console.ReadLine();
                }
                
                if (value >= 1000)
                {
                    Console.WriteLine("four digit numbers are not supported by this program. please enter a new number:");
                    if (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("entry is not a valid number, please enter a valid number into console:");
                        string newnewNum = Console.ReadLine();
                        while (!int.TryParse(newnewNum, out value))
                        {
                            Console.WriteLine("number is not valid, please try again");
                            newnewNum = Console.ReadLine();
                        }
                    }
                }

                this.matrix[rowNumber, i] = value;
            }
        }
        rowNumber++;
    }

    public int getRowNumber()
    {
        return this.rowNumber;
    }

    public void matrixPrint()
    {
        for (int i = 0; i < rowNumber; i++)
        {
            string line = "| ";
            for (int j = 0; j < size; j++)
            {
                if (this.matrix[i, j].ToString().ToCharArray().Length == 3)
                {
                    line += matrix[i, j] + " ";
                }
                else if (this.matrix[i, j].ToString().ToCharArray().Length == 2)
                {
                    line += " " + matrix[i, j] + " ";
                }
                else
                {
                    line += " " + matrix[i, j] + "  ";
                }

                
            }

            line += "|";
            Console.WriteLine(line);
        }
    }
}
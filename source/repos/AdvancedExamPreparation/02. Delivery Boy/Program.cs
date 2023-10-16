
string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
int rows = int.Parse(input[0]);
int cols = int.Parse(input[1]);

bool isLate = false;
bool hasSuccessfulDelivery = false;

char[,] matrix = new char[rows,cols];
int currentRow = 0;
int currentCol= 0;
int startRow =  0;
int startCol = 0;

for (int i = 0; i < rows; i++)
{
    char[] data = Console.ReadLine().ToCharArray();

    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = data[j];

        if (matrix[i,j]=='B')
        {
            currentRow = i;
            startRow = i;

            currentCol = j;
            startCol = j;
        }
    }
}

string command=Console.ReadLine();

while (isLate != true && hasSuccessfulDelivery != true)
{
    int furtherRow;
    int furtherCol;

    switch (command)
    {
        case "up":
            furtherRow = currentRow - 1;
            furtherCol = currentCol ;
            if (IsInside(matrix, furtherRow, furtherCol))
            {
                if (GotThePizza(furtherRow, furtherCol, matrix))
                {
                    matrix[furtherRow, furtherCol] = 'R';
                    matrix[currentRow, currentCol] = '.';
                    currentRow = furtherRow;
                    currentCol=furtherCol;

                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }
                else if(HasObsticle(matrix, furtherRow, furtherCol))
                {
                    break;
                }
                else if(HasReachAddress(matrix, furtherRow, furtherCol))
                {
                    hasSuccessfulDelivery = true;
                    matrix[furtherRow, furtherCol] = 'P';
                    matrix[currentRow, currentCol] = '.';
                    matrix[startRow, startCol] = 'B';

                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
                else
                {
                    matrix[furtherRow, furtherCol] = 'B';
                    if (matrix[currentRow, currentCol] != 'R')
                    {
                        matrix[currentRow, currentCol] = '.';
                    }                    
                    currentCol = furtherCol;
                    currentRow = furtherRow;
                }

            }
            else
            {
                isLate=true;
            }

            break;
        case "down":
            furtherRow = currentRow + 1;
            furtherCol = currentCol;
            if (IsInside(matrix, furtherRow, furtherCol))
            {
                if (GotThePizza(furtherRow, furtherCol, matrix))
                {
                    matrix[furtherRow, furtherCol] = 'R';
                    matrix[currentRow, currentCol] = '.';
                    currentRow = furtherRow;
                    currentCol = furtherCol;

                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }
                else if (HasObsticle(matrix, furtherRow, furtherCol))
                {
                    break;
                }
                else if (HasReachAddress(matrix, furtherRow, furtherCol))
                {
                    hasSuccessfulDelivery = true;
                    matrix[furtherRow, furtherCol] = 'P';
                    matrix[currentRow, currentCol] = '.';
                    matrix[startRow, startCol] = 'B';

                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
                else
                {
                    matrix[furtherRow, furtherCol] = 'B';
                    if (matrix[currentRow, currentCol] != 'R')
                    {
                        matrix[currentRow, currentCol] = '.';
                    }
                    currentCol = furtherCol;
                    currentRow = furtherRow;
                }

            }
            else
            {
                isLate = true;
            }

            break;
        case "left":
            furtherRow = currentRow ;
            furtherCol = currentCol - 1;
            if (IsInside(matrix, furtherRow, furtherCol))
            {
                if (GotThePizza(furtherRow, furtherCol, matrix))
                {
                    matrix[furtherRow, furtherCol] = 'R';
                    matrix[currentRow, currentCol] = '.';
                    currentRow = furtherRow;
                    currentCol = furtherCol;

                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }
                else if (HasObsticle(matrix, furtherRow, furtherCol))
                {
                    break;
                }
                else if (HasReachAddress(matrix, furtherRow, furtherCol))
                {
                    hasSuccessfulDelivery = true;
                    matrix[furtherRow, furtherCol] = 'P';
                    matrix[currentRow, currentCol] = '.';
                    matrix[startRow, startCol] = 'B';

                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
                else
                {
                    matrix[furtherRow, furtherCol] = 'B';
                    if (matrix[currentRow, currentCol] != 'R')
                    {
                        matrix[currentRow, currentCol] = '.';
                    }
                    currentCol = furtherCol;
                    currentRow = furtherRow;
                }

            }
            else
            {
                isLate = true;
            }

            break;
            case "right":
            furtherRow = currentRow ;
            furtherCol = currentCol + 1;
            if (IsInside(matrix, furtherRow, furtherCol))
            {
                if (GotThePizza(furtherRow, furtherCol, matrix))
                {
                    matrix[furtherRow, furtherCol] = 'R';
                    matrix[currentRow, currentCol] = '.';
                    currentRow = furtherRow;
                    currentCol = furtherCol;

                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }
                else if (HasObsticle(matrix, furtherRow, furtherCol))
                {
                    break;
                }
                else if (HasReachAddress(matrix, furtherRow, furtherCol))
                {
                    hasSuccessfulDelivery = true;
                    matrix[furtherRow, furtherCol] = 'P';
                    matrix[currentRow, currentCol] = '.';
                    matrix[startRow, startCol] = 'B';

                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    break;
                }
                else
                {
                    matrix[furtherRow, furtherCol] = 'B';
                    if (matrix[currentRow, currentCol] != 'R')
                    {
                        matrix[currentRow, currentCol] = '.';
                    }
                    currentCol = furtherCol;
                    currentRow = furtherRow;
                }

            }
            else
            {
                isLate = true;
            }

            break;
        default:
            break;
    }

    command = Console.ReadLine();
}

if (isLate)
{

    Console.WriteLine("The delivery is late. Order is canceled.");
    matrix[startRow, startCol] = ' ';
}
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        
        Console.Write(matrix[i,j]);
    }

    Console.WriteLine(  );
}

bool HasReachAddress(char[,] matrix, int furtherRow, int furtherCol)
{
    if (matrix[furtherRow, furtherCol] == 'A')
    {
        return true;
    }
    return false;
}

bool HasObsticle(char[,] matrix, int furtherRow, int furtherCol)
{
    if (matrix[furtherRow, furtherCol] == '*')
    {
        return true;
    }
    return false;
}

bool IsInside(char[,] matrix, int furtherRow, int furtherCol)
{
    if (furtherRow<0 || furtherRow >= matrix.GetLength(0) || furtherCol <0 || furtherCol>= matrix.GetLength(1))
    {
        return false;
    }
    return true;
}

bool GotThePizza(int furtherRow, int furtherCol, char[,] matrix)
{
    if (matrix[furtherRow, furtherCol] == 'P')
    {
        return true;
    }
    return false;
}
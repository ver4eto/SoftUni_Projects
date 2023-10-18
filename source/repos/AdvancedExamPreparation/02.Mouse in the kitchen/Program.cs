using System.Text;
using System.Timers;

int[] matrixInput = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int rows = matrixInput[0];
int cols = matrixInput[1];

bool hasEatAllCheese = false;
bool isTrapped=false;
bool isOut=false;

char[][] matrix = new char[rows][];

int currentRowPosition = 0;
int currentColumnPosition = 0;

for (int i = 0; i < rows; i++)
{
    char[] input = Console.ReadLine().ToCharArray();
    for (int j = 0; j < cols; j++)
    {
        matrix[i] = input;
        if (matrix[i][j] == 'M')
        {
            currentRowPosition = i;
            currentColumnPosition = j;
        }
    }
}

string command = Console.ReadLine();

while (command != "danger" && hasEatAllCheese == false && isTrapped==false && isOut==false)
{
    int furtherRow;
    int furtherColumn;

    switch (command)
    {
        case "up":
            furtherRow = currentRowPosition - 1;
            furtherColumn = currentColumnPosition;
            if (IsInside(furtherRow, furtherColumn, matrix, rows, cols))
            {
                if (HasCheese(matrix, furtherRow, furtherColumn))
                {
                    matrix[furtherRow][furtherColumn] = 'M';
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    currentColumnPosition = furtherColumn;
                    currentRowPosition = furtherRow;
                    if (ThisIsLastCheese(matrix))
                    {
                        hasEatAllCheese = true;
                        break;
                    }
                }
                else if(IsTrapped(matrix, furtherRow, furtherColumn))
                {
                    isTrapped = true;
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    matrix[furtherRow][furtherColumn] = 'M';
                    currentRowPosition = furtherRow;
                    currentColumnPosition= furtherColumn;
                }
                else if (HasWall(furtherRow, furtherColumn, matrix))
                {
                    break;
                }
                else
                {
                    matrix[furtherRow][furtherColumn] = 'M';
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    currentColumnPosition = furtherColumn;
                    currentRowPosition = furtherRow;

                }

            }
            else
            {
                isOut = true;
                break;
            }
            break;

        case "down":
            furtherRow = currentRowPosition + 1;
            furtherColumn = currentColumnPosition;
            if (IsInside(furtherRow, furtherColumn, matrix, rows, cols))
            {
                if (HasCheese(matrix, furtherRow, furtherColumn))
                {
                    matrix[furtherRow][furtherColumn] = 'M';
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    currentColumnPosition = furtherColumn;
                    currentRowPosition = furtherRow;
                    if (ThisIsLastCheese(matrix))
                    {
                        hasEatAllCheese = true;
                        break;
                    }
                }
                else if (IsTrapped(matrix, furtherRow, furtherColumn))
                {
                    isTrapped = true;
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    matrix[furtherRow][furtherColumn] = 'M';
                    currentRowPosition = furtherRow;
                    currentColumnPosition = furtherColumn;
                }
                else if (HasWall(furtherRow, furtherColumn, matrix))
                {
                    break;
                }
                else
                {
                    matrix[furtherRow][furtherColumn] = 'M';
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    currentColumnPosition = furtherColumn;
                    currentRowPosition = furtherRow;

                }

            }
            else
            {
                isOut = true;
                break;
            }
            break;

        case "right":
            furtherRow = currentRowPosition;
            furtherColumn = currentColumnPosition + 1;
            if (IsInside(furtherRow, furtherColumn, matrix, rows, cols))
            {
                if (HasCheese(matrix, furtherRow, furtherColumn))
                {
                    matrix[furtherRow][furtherColumn] = 'M';
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    currentColumnPosition = furtherColumn;
                    currentRowPosition = furtherRow;
                    if (ThisIsLastCheese(matrix))
                    {
                        hasEatAllCheese = true;
                        break;
                    }
                }
                else if (IsTrapped(matrix, furtherRow, furtherColumn))
                {
                    isTrapped = true;
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    matrix[furtherRow][furtherColumn] = 'M';
                    currentRowPosition = furtherRow;
                    currentColumnPosition = furtherColumn;
                }
                else if (HasWall(furtherRow, furtherColumn, matrix))
                {
                    break;
                }
                else 
                {
                    matrix[furtherRow][furtherColumn] = 'M';
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    currentColumnPosition = furtherColumn;
                    currentRowPosition = furtherRow;

                }

            }
            else
            {
                isOut = true;
                break;
            }
            break;

        case "left":
            furtherRow = currentRowPosition;
            furtherColumn = currentColumnPosition - 1;
            if (IsInside(furtherRow, furtherColumn, matrix, rows, cols))
            {
                if (HasCheese(matrix, furtherRow, furtherColumn))
                {
                    matrix[furtherRow][furtherColumn] = 'M';
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    currentColumnPosition = furtherColumn;
                    currentRowPosition = furtherRow;
                    if (ThisIsLastCheese(matrix))
                    {
                        hasEatAllCheese = true;
                        break;
                    }
                }
                else if (IsTrapped(matrix, furtherRow, furtherColumn))
                {
                    isTrapped = true;
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    matrix[furtherRow][furtherColumn] = 'M';
                    currentRowPosition = furtherRow;
                    currentColumnPosition = furtherColumn;
                }
                else if (HasWall(furtherRow, furtherColumn, matrix))
                {
                    break;
                }
                else
                {
                    matrix[furtherRow][furtherColumn] = 'M';
                    matrix[currentRowPosition][currentColumnPosition] = '*';
                    currentColumnPosition = furtherColumn;
                    currentRowPosition = furtherRow;

                }

            }
            else
            {
                isOut = true;
                break;
            }
            break;

        default:
            break;
    }

    command = Console.ReadLine();
}

StringBuilder result = new StringBuilder();

if (isOut)
{
    result.AppendLine("No more cheese for tonight!");
}
else if (isTrapped)
{
    result.AppendLine("Mouse is trapped!");

}
else if (hasEatAllCheese)
{
    result.AppendLine("Happy mouse! All the cheese is eaten, good night!");
}
else if (!hasEatAllCheese)
{
    result.AppendLine("Mouse will come back later!");
}

foreach (var row in matrix)
{
    foreach (var col in row)
    {
        result.Append(col);
    }
    result.AppendLine();
}

Console.WriteLine(result.ToString().TrimEnd());

bool HasWall(int furtherRow, int furtherColumn, char[][] matrix)
{
    if (matrix[furtherRow][furtherColumn] == '@')
    {
        return true;
    }
    return false;
}

bool IsTrapped(char[][] matrix, int furtherRow, int furtherColumn)
{
   if (matrix[furtherRow][furtherColumn] == 'T')
    {
        return true;
    }
   return false;
}

bool ThisIsLastCheese(char[][] matrix)
{
    foreach (var row in matrix)
    {
        if (row.Contains('C'))
        {
            return false;
        }
    }
    return true;
}

bool HasCheese(char[][] matrix, int furtherRow, int furtherColumn)
{
    if (matrix[furtherRow][furtherColumn] == 'C')
    {
        return true;
    }
    return false;
}

bool IsInside(int furtherRow, int furtherColumn, char[][] matrix,int row, int cols)
{
    if (furtherRow < 0 || furtherRow >= row
        || furtherColumn < 0 || furtherColumn >= cols)
    {
        return false;
    }
    return true;
}
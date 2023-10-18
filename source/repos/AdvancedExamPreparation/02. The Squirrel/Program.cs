using System.ComponentModel.Design;
using System.Text;

int lenght = int.Parse(Console.ReadLine());
string[] commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

int startRow = 0;
int startCol = 0;

char[,] matrix = new char[lenght,lenght];

int colletedHazelnutCount= 0;

for (int i = 0; i < lenght; i++)
{
    char[] input = Console.ReadLine().ToCharArray();
   for (int j = 0; j < input.Length; j++)
    {
        matrix[i,j] = input[j];
        if (input[j]=='s')
        {
            startRow = i;
            startCol = j;
        }
    }
}

bool isOut = false;
bool isTrapped = false;
bool hasFoundHaselnuts = false;

int count = 0;
while (isOut == false && count<commands.Length)
{
    string command = commands[count];

        switch (command)
        {
            case "up":
                if (IsOutOfField(matrix, startRow - 1) == false)
                {
                    matrix[startRow, startCol] = '*';
                    startRow -= 1;

                    if (IsTrapped(matrix, startRow, startCol))
                    {
                        isTrapped = true;
                        matrix[startRow, startCol] = '*';
                        break;
                    }
                    else if (FoundHazelnut(matrix, startRow, startCol))
                    {
                        colletedHazelnutCount++;
                        hasFoundHaselnuts = true;
                    }
                }
                else
                {
                    isOut = true;
                    break;
                }
                break;
            case "down":
                if (IsOutOfField(matrix, startRow + 1) == false)
                {
                    matrix[startRow, startCol] = '*';
                    startRow += 1;

                    if (IsTrapped(matrix, startRow, startCol))
                    {
                        isTrapped = true;
                        matrix[startRow, startCol] = '*';
                        break;
                    }
                    else if (FoundHazelnut(matrix, startRow, startCol))
                    {
                        colletedHazelnutCount++;
                        hasFoundHaselnuts = true;
                    }
                }
                else
                {
                    isOut = true;
                    break;
                }
                break;
            case "left":
                if (IsOutOfField(matrix, startCol - 1) == false)
                {
                    matrix[startRow, startCol] = '*';
                    startCol -= 1;

                    if (IsTrapped(matrix, startRow, startCol))
                    {
                        isTrapped = true;
                        matrix[startRow, startCol] = '*';
                        break;
                    }
                    else if (FoundHazelnut(matrix, startRow, startCol))
                    {
                        colletedHazelnutCount++;
                        hasFoundHaselnuts = true;
                    }
                }
                else
                {
                    isOut = true;
                    break;
                }
                break;
            case "right":
                if (IsOutOfField(matrix, startCol + 1) == false)
                {
                    matrix[startRow, startCol] = '*';
                    startCol += 1;

                    if (IsTrapped(matrix, startRow, startCol))
                    {
                        isTrapped = true;
                        matrix[startRow, startCol] = '*';
                        break;
                    }
                    else if (FoundHazelnut(matrix, startRow, startCol))
                    {
                        colletedHazelnutCount++;
                        hasFoundHaselnuts = true;
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

    count++;
}

StringBuilder sb= new StringBuilder();

if (isOut)
{
    sb.AppendLine("The squirrel is out of the field.");
}
else if (isTrapped)
{
    sb.AppendLine("Unfortunately, the squirrel stepped on a trap...");
    
}
else if (hasFoundHaselnuts)
{
    if (colletedHazelnutCount >= 3)
    {
    sb.AppendLine("Good job! You have collected all hazelnuts!");
    }
    else { sb.AppendLine("There are more hazelnuts to collect."); }
}

sb.AppendLine($"Hazelnuts collected: {colletedHazelnutCount}");

Console.WriteLine(sb.ToString().TrimEnd());

bool FoundHazelnut(char[,] matrix, int startRow, int startCol)
{
    if (matrix[startRow, startCol] == 'h')
    {
        return true;
    }
    return false;
}

bool IsTrapped(char[,] matrix, int startRow, int startCol)
{
    if (matrix[startRow, startCol]=='t')
    {
        return true;
    }
    return false;
}

bool IsOutOfField(char[,] matrix, int v)
{
   if (v <0 || v >= matrix.GetLength(0))
    {
        return true;
    }
   return false;
}
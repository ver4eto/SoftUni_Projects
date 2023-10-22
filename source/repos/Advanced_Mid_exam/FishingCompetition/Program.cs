using System.Runtime.CompilerServices;
using System.Text;

int size = int.Parse(Console.ReadLine());

char[,]field = new char[size,size];

bool hasSink = false;

int fieshCollected = 0;
int startRow = 0;
int startCol = 0;

for (int i = 0; i < size; i++)
{
    char[] input = Console.ReadLine().ToCharArray();
    for (int j = 0; j < input.Length; j++)
    {
        field[i,j] = input[j];
        if (field[i,j] == 'S')
        {
            startRow = i;
            startCol=j;
        }
    }
}

string command = Console.ReadLine();

while (command != "collect the nets" && hasSink==false)
{
    switch (command)
    {
        case "up":
            if(IsInside(startRow -1, size))
            {
                if(MoveToFishPassage(startRow-1, startCol, field))
                {
                    int currentAmountFish = int.Parse((field[startRow-1, startCol]).ToString());
                    fieshCollected += currentAmountFish;
                    field[startRow, startCol] = '-';
                    startRow--;
                    field[startRow, startCol] = 'S';
                }
                else if (HasWhirpool(field[startRow-1, startCol]))
                {
                    startRow--;
                    hasSink = true;
                    fieshCollected = 0;
                }
                else
                {
                    field[startRow, startCol] = '-';
                    startRow--;
                    field[startRow, startCol] = 'S';
                }
            }
            else
            {
                startRow = size - 1;

                field[0, startCol] = '-';
                if (HasWhirpool(field[startRow, startCol]))
                {
                    hasSink = true;
                    fieshCollected = 0;
                }
                else if(MoveToFishPassage(startRow, startCol, field))
                {
                    int currentAmountFish = int.Parse((field[startRow , startCol]).ToString());
                    fieshCollected += currentAmountFish;
                  
                }
                
                field[startRow, startCol] = 'S';

            }
            break;

        case "down":
            if (IsInside(startRow + 1, size))
            {
                if (MoveToFishPassage(startRow + 1, startCol, field))
                {
                    int currentAmountFish = int.Parse((field[startRow + 1, startCol]).ToString());
                    fieshCollected += currentAmountFish;
                    field[startRow, startCol] = '-';
                    startRow++;
                    field[startRow, startCol] = 'S';
                }
                else if (HasWhirpool(field[startRow + 1, startCol]))
                {
                    startRow++;
                    hasSink = true;
                    fieshCollected = 0;
                }
                else
                {
                    field[startRow, startCol] = '-';
                    startRow++;
                    field[startRow, startCol] = 'S';
                }
            }
            else
            {
                startRow = 0;

                field[size-1, startCol] = '-';
                if (HasWhirpool(field[startRow, startCol]))
                {
                    hasSink = true;
                    fieshCollected = 0;
                }
                else if (MoveToFishPassage(startRow, startCol, field))
                {
                    int currentAmountFish = int.Parse((field[startRow, startCol]).ToString());
                    fieshCollected += currentAmountFish;
                   
                }

                field[startRow, startCol] = 'S';

            }
            break;

        case "left":
            if (IsInside(startCol - 1, size))
            {
                if (MoveToFishPassage(startRow , startCol - 1, field))
                {
                    int currentAmountFish = int.Parse((field[startRow, startCol - 1]).ToString());
                    fieshCollected += currentAmountFish;
                    field[startRow, startCol] = '-';
                    startCol--;
                    field[startRow, startCol] = 'S';
                }
                else if (HasWhirpool(field[startRow , startCol - 1]))
                {
                    startCol--;
                    hasSink = true;
                    fieshCollected = 0;
                }
                else
                {
                    field[startRow, startCol] = '-';
                    startCol--;
                    field[startRow, startCol] = 'S';
                }
            }
            else
            {
                startCol = size -1;

                field[startRow, 0] = '-';
                if (HasWhirpool(field[startRow, startCol]))
                {
                    hasSink = true;
                    fieshCollected = 0;
                }
                else if (MoveToFishPassage(startRow, startCol, field))
                {
                    int currentAmountFish = int.Parse((field[startRow, startCol]).ToString());
                    fieshCollected += currentAmountFish;

                }

                field[startRow, startCol] = 'S';


            }
            break; 

        case "right":
            if (IsInside(startCol + 1, size))
            {
                if (MoveToFishPassage(startRow, startCol + 1, field))
                {
                    int currentAmountFish = int.Parse((field[startRow, startCol + 1]).ToString());
                    fieshCollected += currentAmountFish;
                    field[startRow, startCol] = '-';
                    startCol++;
                    field[startRow, startCol] = 'S';
                }
                else if (HasWhirpool(field[startRow, startCol + 1]))
                {
                    startCol++;
                    hasSink = true;
                    fieshCollected = 0;
                }
                else
                {
                    field[startRow, startCol] = '-';
                    startCol++;
                    field[startRow, startCol] = 'S';
                }
            }
            else
            {
                startCol = 0;

                field[startRow, size-1] = '-';
                if (HasWhirpool(field[startRow, startCol]))
                {
                    hasSink = true;
                    fieshCollected = 0;
                }
                else if (MoveToFishPassage(startRow, startCol, field))
                {
                    int currentAmountFish = int.Parse((field[startRow, startCol]).ToString());
                    fieshCollected += currentAmountFish;

                }

                field[startRow, startCol] = 'S';

            }
            break;
        default:
            break;
    }

    command=Console.ReadLine();
}

StringBuilder sb = new StringBuilder();
if (hasSink)
{
    sb.AppendLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{startRow},{startCol}]");
}
else if (fieshCollected >= 20)
{
    sb.AppendLine($"Success! You managed to reach the quota! ");
}
else if (fieshCollected < 20)
{
    sb.AppendLine($"You didn't catch enough fish and didn't reach the quota! You need {20-fieshCollected} tons of fish more.");
}

if (fieshCollected > 0)
{
    sb.AppendLine($"Amount of fish caught: {fieshCollected} tons.");
}

if (hasSink == false)
{
    for (int i = 0; i < size; i++)
    {
       for (int j = 0; j < size; j++)
        {
            sb.Append(field[i,j]);
        }
       sb.AppendLine();
    }
}

Console.WriteLine(sb.ToString().TrimEnd());

bool HasWhirpool(char v)
{
    if (v == 'W')
    {
        return true;
    }
    return false;
}

bool MoveToFishPassage(int v, int startCol, char[,] field)
{
    if (Char.IsDigit(field[v, startCol]))
    {
        return true;
    }
    return false;
}

bool IsInside(int v, int size)
{
    if (v<0 || v >= size)
    {
        return false;
    }
    return true;
}
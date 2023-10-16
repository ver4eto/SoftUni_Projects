using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class StartUp
{
   public static void Main()
    {

        int countOfInput = int.Parse(Console.ReadLine());
        char[,] field = new char[countOfInput, countOfInput];
        int startRow = 0;
        int startCol = 0;

        int countPollinatedFlowers = 0;
        int minimumPollinatedFlowersNeeded = 5;

        for (int i = 0; i < countOfInput; i++)
        {
            char[] input = Console.ReadLine().ToCharArray();
            for (int j = 0; j < countOfInput; j++)
            {
                if (input[j] == 'B')
                {
                    startRow = i;
                    startCol = j;
                }
                field[i, j] = input[j];
            }
        }

        string command = string.Empty;
        bool isOutOfField= false;

        while ((command = Console.ReadLine()) != "End" && !isOutOfField)
        {
            switch (command)
            {
                case "up":
                    if (!IsOutOfField(startRow-1, startCol, field))
                    {
                        countPollinatedFlowers=MoveUp(startRow, startCol, field, countPollinatedFlowers);
                    }
                    else
                    {
                        isOutOfField = true;
                        Console.WriteLine("The bee got lost!");
                       
                    }
                    break;
                case "down":
                    if (!IsOutOfField(startRow + 1, startCol, field))
                    {
                        countPollinatedFlowers= MoveDown(startRow, startCol, field, countPollinatedFlowers);

                    }
                    else
                    {
                        isOutOfField = true;
                        Console.WriteLine("The bee got lost!");

                    }
                    break;
                case "left":
                    if (!IsOutOfField(startRow , startCol - 1, field))
                    {
                        countPollinatedFlowers= MoveLeft(startRow, startCol, field, countPollinatedFlowers);

                    }
                    else
                    {
                        isOutOfField = true;
                        Console.WriteLine("The bee got lost!");

                    }
                    break;
                case "right":
                    if (!IsOutOfField(startRow , startCol + 1, field))
                    {
                        countPollinatedFlowers= MoveRight(startRow, startCol, field, countPollinatedFlowers);

                    }
                    
                        else
                        {
                            isOutOfField = true;
                            Console.WriteLine("The bee got lost!");

                        }
                    
                    break;
            }
        }

        //Console.WriteLine();
        if (countPollinatedFlowers < minimumPollinatedFlowersNeeded)
        {
            Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {minimumPollinatedFlowersNeeded - countPollinatedFlowers} flowers more");
        }
        else
        {
            Console.WriteLine($"Great job, the bee managed to pollinate {countPollinatedFlowers} flowers!");
        }

        StringBuilder matrix = new StringBuilder();

        foreach (var row in field)
        {
            //foreach (var col in row)
            //{
            //    matrix.Append(col.Tochar());
            //}
            matrix.AppendLine(row.ToString());
        }
    }

    private static int MoveRight(int startRow, int startCol, char[,] field, int countPollinatedFlowers)
    {        
            field[startRow, startCol] = '.';

            if (HasFlower(startRow, startCol + 1, field))
            {
                countPollinatedFlowers++;
                startCol++;
                field[startRow, startCol] = 'B';

            }
            else if (HasBonus(startRow, startCol + 1, field))
            {
                MoveLeft(startRow, startCol + 1, field, countPollinatedFlowers);
            }
            else
            {
                startCol++;
                field[startRow, startCol] = 'B';
            }
       return countPollinatedFlowers;
    }

    private static int  MoveLeft(int startRow, int startCol, char[,] field, int countFlowers)
    {        
            field[startRow, startCol] = '.';

            if (HasFlower(startRow, startCol - 1, field))
            {
                countFlowers++;
                startCol--;
                field[startRow, startCol] = 'B';

            }
            else if (HasBonus(startRow, startCol - 1, field))
            {
                MoveLeft(startRow, startCol -1, field, countFlowers);
            }
            else
            {
                startCol--;
                field[startRow, startCol] = 'B';
            }
        return countFlowers;
    }

    private static int  MoveDown(int startRow, int startCol, char[,] field, int countPollinatedFlowers)
    {
       
            field[startRow, startCol] = '.';

            if (HasFlower(startRow + 1, startCol, field))
            {
                countPollinatedFlowers++;
                startRow++;
                field[startRow, startCol] = 'B';

            }
            else if (HasBonus(startRow + 1, startCol, field))
            {
                MoveDown(startRow + 1, startCol, field, countPollinatedFlowers);
            }
            else
            {
                startRow++;
                field[startRow, startCol] = 'B';
            }

        return countPollinatedFlowers;
    }

    private static int MoveUp(int startRow, int startCol,char[,] field,int countFlowers)
    {
      
            field[startRow, startCol] = '.';

            if (HasFlower(startRow-1, startCol, field))
            {
                countFlowers++;
                startRow--;
                field[startRow, startCol] = 'B';

            }
            else if (HasBonus(startRow-1,startCol, field))
            {
                MoveUp(startRow-1, startCol, field, countFlowers);
            }
            else 
            {
                startRow--;
                field[startRow, startCol] = 'B';
            }
        return countFlowers;
    }

   

    private static bool HasBonus(int v, int startCol, char[,] field)
    {
        if (field[v, startCol] == 'O')
        {
            return true;
        }
        return false;
    }

    private static bool HasFlower(int v, int startCol, char[,] field)
    {
        if (field[v, startCol] == 'f')
        {
            return true;
        }
        return false;
    }

    private static bool IsOutOfField(int v, int startCol, char[,] field)
    {
        if (v<0 || startCol <0 || v>=field.GetLength(0) || startCol>=field.GetLength(1))
        {
            return true;
        }
        return false;   
    }
}
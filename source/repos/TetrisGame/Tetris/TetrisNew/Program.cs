using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace TetrisNew
{

    class Program
    {
        //Settings
        
        static int TetrisRows = 30;
        static int TetrisCols = 20;
        static int InfoCols = 10;
        static int ConsoleRows = 1 + TetrisRows + 1;
        static int ConsoleCols = 1 + TetrisCols + 1 + InfoCols + 1;
        static List<bool[,]> TetrisFigures = new List<bool[,]>()
        {
            new bool [,]
            {
                { true,true,true,true }
            }, //----           
            new bool [,]
            {
            { true,true},
            { true,true}
            }, //O
            new bool [,]
            {
            { false,true,false},
            { true,true,true}
            }, //T
            new bool [,]
            {
            { false,true,true},
            { true,true,false}
            }, //S
            new bool [,]
            {
                { true,true,false},
                { false,true,true}
            }, //Z
            new bool [,]
            {
            { true,false,false},
            { true,true,true}
            }, //J
            new bool [,]
            {
            { false,false,true},
            { true,true,true}
            }, //L
        };
        static string ScoreFileName = "scores.txt";
        static int[] ScoresPerLines = { 0, 40, 100, 300, 1200 };

        //State

        static int Score = 0;
        static int HighScore = 0;
        static int Level = 1;
        static int Frame = 0;
        static int FramesToMoveFigure = 16;
        // static int CurrentFigureIndex = 2;
        static bool[,] CurrentFigure = TetrisFigures[2];
        static int CurrentFigureRow = 0;
        static int CurrentFigureCol = 0;
        static bool[,] TetrisField = new bool[TetrisRows, TetrisCols];
        static Random Random = new Random();
        static void Main(string[] args)
        {
            if (File.Exists(ScoreFileName))
            {
                var allScores = File.ReadAllLines(ScoreFileName);
                foreach (var score in allScores)
                {
                    var match = Regex.Match(score, @" => (?<score>[0-9]+)");
                    HighScore = Math.Max(HighScore, int.Parse(match.Groups["score"].Value));
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Title = "Tetris V1.0";
            Console.WindowHeight = ConsoleRows + 1;
            Console.WindowWidth = ConsoleCols;
            Console.BufferHeight = ConsoleRows + 1;
            Console.BufferWidth = ConsoleCols;
            Console.CursorVisible = false;
            CurrentFigure = TetrisFigures[Random.Next(0, TetrisFigures.Count)];
            //Write("Vera", 5, 5);

            while (true)
            {
                Frame++;
                UpdateLevel();
                //Read user input
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        //Environment.Exit(0);
                        return;
                    }
                    if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                    {
                        if (CurrentFigureCol >= 1)
                        {
                            CurrentFigureCol--;
                        }
                    }
                    if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                    {
                        if (CurrentFigureCol < TetrisCols - CurrentFigure.GetLength(1))
                        {
                            CurrentFigureCol++;
                        }
                       
                    }
                    if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                    {
                        Frame = 1;
                        Score += Level;
                        CurrentFigureRow++;
                       
                      
                    }
                    if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                    {
                        RotateCurrentFigure();
                    }

                }
                //Update the game state
                if (Frame % (FramesToMoveFigure-Level) == 0)
                {
                    CurrentFigureRow++;
                    Frame = 0;
                }
                if (Collision(CurrentFigure))
                {
                    AddCurrentFigureToTetrisField();

                    int lines = CheckForFullLines();
                    Score += ScoresPerLines[lines] * Level;

                    CurrentFigure = TetrisFigures[Random.Next(0, TetrisFigures.Count)];
                    CurrentFigureRow = 0;
                    CurrentFigureCol = 0;

                    if (Collision(CurrentFigure))
                    {
                        File.AppendAllLines(ScoreFileName, new List<string>
                        {
                            $"[{DateTime.Now.ToString()} {Environment.UserName} => {Score}]"
                        });
                        var scoreToString = Score.ToString();
                        scoreToString += new string(' ', 8 - scoreToString.Length);
                        Write("╔══════════╗", 5, 5);
                        Write("║ Game     ║", 6, 5);
                        Write("║  over!   ║", 7, 5);
                        Write($"║ {scoreToString} ║", 8, 5);
                        Write("╚══════════╝", 9, 5);
                        Thread.Sleep(100000);
                        Environment.Exit(0);
                    }
                }
                //redraw UI
                DrawBorder();
                DrawInfo();

                DrawTetrisField();
                DrawCurrentFigure();

                Thread.Sleep(40);

            }

        }

        private static void UpdateLevel()
        {
            if (Score<=0)
            {
                Level = 1;
                return;
            }
            Level = (int)Math.Log10(Score) - 1;
            if (Level < 1)
            {
                Level = 1;
            }
            if (Level>10)
            {
                Level = 10;
            }
        }

        static void RotateCurrentFigure()
        {
            var newFigure = new bool[CurrentFigure.GetLength(1),CurrentFigure.GetLength(0)];

            for (int row = 0; row < CurrentFigure.GetLength(0); row++)
            {
                for (int col = 0; col < CurrentFigure.GetLength(1); col++)
                {
                    newFigure[col, CurrentFigure.GetLength(0) - row-1] = CurrentFigure[row, col];
                }
            }
            if (!Collision(newFigure))
            {
                CurrentFigure = newFigure;

            }
        }

        static int CheckForFullLines()
        {
            int lines = 0;


            for (int row = 0; row < TetrisField.GetLength(0); row++)
            {
                bool rowIsFull = true;
                for (int col = 0; col < TetrisField.GetLength(1); col++)
                {
                    if (TetrisField[row, col] == false)
                    {
                        rowIsFull = false;
                        break;
                    }
                }

                if (rowIsFull)
                {
                    for (int rowToMove = row; rowToMove >= 1; rowToMove--)
                    {
                        for (int col = 0; col < TetrisField.GetLength(1); col++)
                        {
                            TetrisField[rowToMove, col] = TetrisField[rowToMove - 1, col];
                        }
                    }

                    lines++;
                }

            }

            return lines;
        }

        static void AddCurrentFigureToTetrisField()
        {
            for (int row = 0; row < CurrentFigure.GetLength(0); row++)
            {
                for (int col = 0; col < CurrentFigure.GetLength(1); col++)
                {
                    if (CurrentFigure[row, col])
                    {
                        TetrisField[CurrentFigureRow + row, CurrentFigureCol + col] = true;

                    }
                }
            }

        }

        static bool Collision(bool [,] figure)
        {
            if (CurrentFigureCol > TetrisCols - figure.GetLength(1))
            {
                return true;
            }

            if (CurrentFigureRow + figure.GetLength(0) == TetrisRows)
            {
                return true;
            }

            for (int row = 0; row < figure.GetLength(0); row++)
            {
                for (int col = 0; col < figure.GetLength(1); col++)
                {
                    if (figure[row, col] &&
                        TetrisField[CurrentFigureRow + row + 1, CurrentFigureCol + col])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void DrawTetrisField()
        {
            for (int row = 0; row < TetrisField.GetLength(0); row++)
            {
                string line = "";
                for (int col = 0; col < TetrisField.GetLength(1); col++)
                {
                    
                    if (TetrisField[row, col])
                    {
                        line += "*";
                    }
                    else
                    {
                        line += " ";
                    }

                }
                Write(line, row + 1, 1);
            }

        }

        static void DrawInfo()
        {
            if (Score > HighScore)
            {
                HighScore = Score;
            }
            Write("Level:", 1, 3 + TetrisCols);
            Write(Level.ToString(), 2, 3 + TetrisCols);
            Write("Score:", 4, 3 + TetrisCols);
            Write(Score.ToString(), 5, 3 + TetrisCols);
            Write("Best:", 7, 3 + TetrisCols);
            Write(HighScore.ToString(), 8, 3 + TetrisCols);
            Write("Frame:", 10, 3 + TetrisCols);
            Write(Frame.ToString()+ " / " +(FramesToMoveFigure-Level).ToString(), 11, 3 + TetrisCols);
            Write("Position:", 13, 3 + TetrisCols);
            Write($"{CurrentFigureRow}, {CurrentFigureCol}", 14, 3 + TetrisCols);
            Write("Keys:", 16, 3 + TetrisCols);
            Write($"  ^", 17, 3 + TetrisCols);
            Write($" < >", 18, 3 + TetrisCols);
            Write($"  v ", 19, 3 + TetrisCols);
        }

        static void DrawBorder()
        {
            Console.SetCursorPosition(0, 0);
            string line = "╔";
            line += new string('═', TetrisCols);

            /*for (int i = 0; i < TetrisCols; i++)
            {
                line += "═";
            }*/

            line += "╦";

            for (int i = 0; i < InfoCols; i++)
            {
                line += "═";
            }
            line += "╗";

            Console.WriteLine(line);

            for (int i = 0; i < TetrisRows; i++)
            {
                string middleLine = "║";
                middleLine += new string(' ', TetrisCols);
                middleLine += "║";
                middleLine += new string(' ', InfoCols);
                middleLine += "║";
                Console.Write(middleLine);
            }

            string endLine = "╚";

            endLine += new string('═', TetrisCols);
            endLine += "╩";
            endLine += new string('═', InfoCols);
            endLine += "╝";

            Console.WriteLine(endLine);
        }

        static void DrawCurrentFigure()
        {

            for (int row = 0; row < CurrentFigure.GetLength(0); row++)
            {
               
                for (int col = 0; col < CurrentFigure.GetLength(1); col++)
                {
                    if (CurrentFigure[row, col])
                    {
                        Write("*", row + 1 + CurrentFigureRow, 1 + CurrentFigureCol+col);
                    }
                    
                }
                
            }

        }
        static void Write(string text, int row, int col)
        {

            Console.SetCursorPosition(col, row);
            Console.WriteLine(text);

        }
    }
}

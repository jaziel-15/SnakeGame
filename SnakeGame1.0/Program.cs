using System;
using System.Threading;

namespace SnakeGame1._0
{
    internal class Program
    {
        static int width = 20;
        static int height = 20;
        static int score = 0;
        static bool gameOver = false;
        static Random random = new Random();

        static int snakeX;
        static int snakeY;
        static int fruitX;
        static int fruitY;
        static int[] tailX = new int[100];
        static int[] tailY = new int[100];
        static int taillenght = 0;
        static int speed = 10;
        static int direction = 0;

        static void Main(string[] args)
        {
            Console.Title = "SnakeGame 1.0";
            Console.CursorVisible = false;

            InitializeGame();

            while (!gameOver)
            {
                if (Console.KeyAvailable)
                {
                    HandleKeypress(Console.ReadKey(true).Key);
                }

                MoveSnake();

                if (CheckCollision())
                {
                    gameOver = true;
                }

                Draw();

                Thread.Sleep(1000/speed);
            }

            Console.SetCursorPosition(width / 2 - 5, height / 2);
            Console.WriteLine("Game over! tu puntuaje es de:" + score + ".");
            Console.WriteLine("");
        }

        static void InitializeGame()
        {
            snakeX = width / 2;
            snakeY = height / 2;

            fruitX = random.Next(1, width - 1);
            fruitY = random.Next(1, height - 1);

            score = 0;
            direction = 0;
        }

        static void Draw()
        {
            Console.Clear();

            for (int i = 0; i < width + 1; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("#");
                    }

                    else if (j == width -1)
                    {
                        Console.Write("#");
                    }

                    else if (j == snakeX && i == snakeY)
                    {
                        Console.Write("O");
                    }

                    else if (j == fruitX && i == fruitY)
                    {
                        Console.Write("f");
                    }

                    else
                    {
                        bool tailbit = false;

                        for (int k = 0; k < taillenght; k++)
                        {
                            if (tailX[k] == j && tailY[k] == i)
                            {
                                tailbit = true;
                                break;
                            }
                        }

                        if (tailbit)
                        {
                            Console.Write("o");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                  

                }
            }

            Console.WriteLine();
            Console.WriteLine("Score: {0}", score);
        }

        static void HandleKeypress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (direction != 2)
                    {
                        direction = 0;
                    }
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (direction != 3)
                    {
                        direction = 1;
                    }
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (direction != 0)
                    {
                        direction = 2;
                    }
                    break;

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (direction != 1)
                    {
                        direction = 3;
                    }
                    break;
                case ConsoleKey.Escape:
                    gameOver = true;
                    break;
            }
        }

    }


}

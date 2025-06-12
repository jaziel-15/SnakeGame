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
    }
}

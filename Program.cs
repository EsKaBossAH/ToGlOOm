using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        public static int HEIGHT = 20, WIDTH = 24;
        //public const int WALL = 1, EMPTY = 0;
        public static char[,] map = new char[HEIGHT, WIDTH];
        public static int speed = 300;
        public static int[] a = new int[2];
        static void Main(string[] args)
        {
            Console.SetWindowSize(WIDTH + 1, HEIGHT + 1);
            int ballX = WIDTH, ballY = HEIGHT, arilgah = 0, nemeh=0;
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (i == 0 || j == 0 || i == HEIGHT - 1 || j == WIDTH - 1)
                    {
                        map[i, j] = '1';// 1 - saad, hana
                    }
                    else if (i == j && i > 3 && i < 6)
                    {
                        map[i, j] = '3';
                    }
                    else
                        map[i, j] = ' ';
                }

            }
            speed = 300;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            int x = WIDTH / 2, y = HEIGHT - 2, x0 = WIDTH / 2, y0 = HEIGHT - 2, b_x = 1, b_y = 1, b_x0 = 1, b_y0 = 1;
            Console.CursorVisible = false;
            int[] move = new int[2];
            move[0] = 1;
            move[1] = 1;
            string table = "222222";
            string table0 = "      ";
            Console.SetCursorPosition(x, y);
            Console.Write(table0);
            Console.SetCursorPosition(x, y);
            Console.Write(table);
            char[] tab = new char[6];
            tab = table.ToCharArray();
            for (int i = x0 ; i < x0 + 6; i++)
            {
                map[y0, i] = '2';
            }
            while (true)
            {
                Thread.Sleep(100);
                move = bump(move, map, b_x, b_y);
                if (move[0] == 0 && move[1] == 0)
                {
                    return;
                }
                Console.SetCursorPosition(b_x0, b_y0);
                Console.Write(' ');
                b_x += move[0];
                b_y += move[1];
                Console.SetCursorPosition(b_x, b_y);
                Console.Write('$');
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            x = x - 1;
                            arilgah = 5;
                            nemeh = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            x = x + 1;
                            arilgah = 0;
                            nemeh = 6;
                            break;
                        case ConsoleKey.Escape:
                            Console.WriteLine("pause");
                            Console.ReadKey(true);
                            break;
                        //return;
                    }
                    //Thread.Sleep(10);
                    if (x < WIDTH - 7 && x > 1)
                    {
                        Console.SetCursorPosition(x0, y0);
                        Console.Write("      ");
                        Console.SetCursorPosition(x, y);
                        Console.Write("222222");
                        map[y0, x0 + nemeh] = '2';
                        map[y0, x0 + arilgah] = ' ';
                    }

                    x0 = x; y0 = y;
                }
                b_x0 = b_x;
                b_y0 = b_y;
            }
        }
        public static int[] bump(int[] move, char[,] map, int posX, int posY)
        {
            if (posY == HEIGHT - 2)
            {
                Console.Write("game over");
                Console.ReadKey(true);
                int[] a = new int[2];
                return a;
            }
            if (map[posY, posX + move[0]] != ' ')
            {
                map = checkBump(map, posX + move[0], posY);
                move[0] = -1 * move[0];
                if (map[posY + move[1], posX] != ' ')
                {
                    map = checkBump(map, posX, posY + move[1]);
                    move[1] = -1 * move[1];
                }
            }
            else if (map[posY + move[1], posX] != ' ')
            {
                map = checkBump(map, posX, posY + move[1]);
                move[1] = -1 * move[1];
                if (map[posY, posX + move[0]] != ' ')
                {
                    map = checkBump(map, posX + move[0], posY);
                    move[1] = -1 * move[1];
                }
            }
            else if (map[posY + move[1], posX + move[0]] != ' ')
            {
                map = checkBump(map, posX + move[0], posY + move[1]);
                move[0] = -1 * move[0];
                move[1] = -1 * move[1];
            }
            return move;
        }
        static char[,] checkBump(char[,] map, int posX, int posY)
        {
            if (map[posY, posX] == '3')
            {
                map[posY, posX] = ' ';
                Console.SetCursorPosition(posX, posY);
                Console.Write(' ');
                return map;
            }
            else if (map[posY, posX] == '2')
            {
                return map;
            }
        }

    }
    
}

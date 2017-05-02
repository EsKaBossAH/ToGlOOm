using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BreakBalll
{
    class Bump
    {
        private Map map;
        private Ball ball;
        private Table table;
        private Display dis;
        
        private int[] move = new int[2];
        private int HEIGHT, WIDTH;
        private int blockNum = 0;
        public Bump(String start)
        {
            map = new Map();
            HEIGHT = map.BODY.GetLength(0);
            WIDTH = map.BODY.GetLength(1);
            blockNum = map.Block.BlockNum;
            ball = new Ball(WIDTH, HEIGHT);
            table = new Table(WIDTH , HEIGHT, WIDTH);
            dis = new Display();
            dis.drawMap(map.BODY);
            for (int i = 0; i < table.BODY.Length; i++)
            {
                map.BODY[table.YPOS, i + table.XPOS] = table.BODY[i];
            }
            map.BODY[ball.Ypos, ball.Xpos] = ball.Body;
            dis.drawTable(table.XPOS, table.YPOS);
            dis.drawBall(ball.Xpos, ball.Ypos);
            move[0] = 1;
            move[1] = -1;
            ehleh();
            Console.ReadKey();
        }

        public void ehleh()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {

                }
                move = cbump(move, map.BODY, ball.Xpos, ball.Ypos);
                dis.clearBall(ball.OLDLOC[0], ball.OLDLOC[1]);
                ball.Move(move[0], move[1]);
                map.BallMove(ball.OLDLOC[0], ball.OLDLOC[1], ball.Xpos, ball.Ypos, ball.Body);
                Thread.Sleep(100);
                dis.drawBall(ball.Xpos, ball.Ypos);
            }
        }
        public int[] cbump(int[] move, char[,] map, int posX, int posY)
        {
            if (posY == map.GetLength(1) - 2 && posX > 0 && posX < map.GetLength(0) - 2)
            {
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
        private char[,] checkBump(char[,] map, int posX, int posY)
        {
            if (map[posY, posX] == '3')
            {
                map[posY, posX] = ' ';
                return map;
            }
            else if (map[posY, posX] == '*')
            {
                return map;
            }
            else
                return map;
        }
    }
}

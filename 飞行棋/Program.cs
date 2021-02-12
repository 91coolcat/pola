using System;

namespace 飞行棋
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = true; string[] gamenames = new string[2];int[] ditu = new int[100];string[] ditus = new string[100];
            Gametou();
            Console.WriteLine("输入玩家a的id");
            gamenames[0] = Console.ReadLine();
            while (gamenames[0] == "")
            {
                Console.WriteLine("玩家id不能为空");
                gamenames[0] = Console.ReadLine();
            }
            Console.WriteLine("输入玩家b的id");
            while (gamenames[0] == gamenames[1] || gamenames[1] == "")
            {
                if (gamenames[0] == gamenames[1])
                {
                    Console.WriteLine("玩家b与玩家a的id不能相同");
                    gamenames[1] = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("玩家id不能为空");
                    gamenames[1] = Console.ReadLine();
                }
            }
            Playditu(ref ditu,ref ditus);
        }
        public static void Gametou()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("***");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("飞行棋");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("***");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("************");
        }//游戏头
        public static void Playditus(int a,out int[] b)
        {
            int[] pan = { 6, 23, 40, 55, 69, 83 };//幸运轮盘
            int[] lei = { 5, 13, 17, 38, 50, 64, 80, 94 };//地雷
            int[] pause = { 9, 27, 60, 93 };//暂停
            int[] csm = { 20, 25, 45, 63, 72, 88, 90 };//隧道
            switch (a)
            {
                case 0:
                    b = pan;
                    break;
                case 1:
                    b = lei;
                    break;
                case 2:
                    b = pause;
                    break;
                default:
                    b = csm;
                    break;
            }
        }//地图摆放数据
        public static void Playditu(ref int[] vis,ref string[] vv)
        {
            int[] vs = new int[1];
            for(int i=0; i<4; i++)
            {
                Playditus(i,out vs);
                for (int j = 0; j < vs.Length; j++)
                {
                    int a = vs[j];
                    vis[a] = i + 1;
                }
            }
            for (int i = 0; i <vis.Length;  i++)
            {
                switch (vis[i])
                {
                    case 0:vv[i] = "□";
                        break;
                    case 1:vv[i] = "◎";
                        break;
                    case 2:vv[i] = "△";
                        break;
                }
            }
        }//初始化地数据
    }
}

using System;

namespace 飞行棋
{
    class Program
    {
        public static int[] ditu = new int[100];public static int q = 0;
        public static string[] gamenames = new string[2];
        public static int[] playpos = { 0, 0 };
        static void Main(string[] args)
        {
            Gametou(); playgame(); hditu();
            while (playpos[0] < 100 && playpos[1] < 100)
            {
                play(0, ref playpos[0], ref playpos[1]);
                if (playpos[0] > 99 || playpos[1] > 99) break;
                play(1, ref playpos[1], ref playpos[0]);
            }
            Console.Clear();
            if (playpos[0] >= 100) Console.WriteLine("玩家{0}无耻的赢了玩家{1}", gamenames[0], gamenames[1]);
            else Console.WriteLine("玩家{0}无耻的赢了玩家{1}", gamenames[1], gamenames[0]);
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
        }//游戏头s
        public static void playgame()
        {
            Console.WriteLine("输入玩家a的id");
            gamenames[0] = Console.ReadLine();
            while (gamenames[0] == "")
            {
                Console.WriteLine("玩家id不能为空");
                gamenames[0] = Console.ReadLine();
            }
            Console.WriteLine("输入玩家b的id");
            gamenames[1] = Console.ReadLine();
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
        }//进入界面
        public static void Playditus()
        {
            for (int i = 0; i < ditu.Length; i++)
            {
                if (ditu[i] >= 5) ditu[i] = 0;
            }
            int[] pan = { 6, 23, 40, 55, 69, 83 };//幸运轮盘
            for (int i = 0; i < pan.Length; i++) ditu[pan[i]] = 1;
            int[] lei = { 5, 13, 17, 38, 50, 64, 80, 94 };//地雷
            for (int i = 0; i < lei.Length; i++) ditu[lei[i]] = 2;
            int[] pause = { 9, 27, 60, 93 };//暂停
            for (int i = 0; i < pause.Length; i++) ditu[pause[i]] = 3;
            int[] csm = { 20, 25, 45, 63, 72, 88, 90 };//隧道
            for (int i = 0; i < csm.Length; i++) ditu[csm[i]] = 4;
            ditu[playpos[0]] = 5;
            if (ditu[playpos[1]] == 5) ditu[playpos[1]] = 7;
            else ditu[playpos[1]] = 6;
        }//地图摆放数据
        public static void playditu(int a)
        {
            switch (ditu[a])
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("□");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("◎");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("▲");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("☆");
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("卍");
                    break;
                case 5:
                case 6:
                case 7:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (ditu[a] == 5) Console.Write("A");
                    else if (ditu[a] == 6) Console.Write("B");
                    else Console.Write("<>");
                    break;
            }

        } //画地图的工具
        public static void hditu()
        {
            Playditus(); Console.WriteLine("图例  幸运轮盘◎   地雷▲   暂停☆   隧道卍");
            for (int i = 0; i < 30; i++) playditu(i); Console.WriteLine();//第一横行
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }
                playditu(i); Console.WriteLine();
            }//第一竖行
            for (int i = 65; i > 35; i--) playditu(i); Console.WriteLine();//第二横行
            for (int i = 65; i < 70; i++) { playditu(i); Console.WriteLine(); }//第二竖行
            for (int i = 70; i < 100; i++) playditu(i); Console.WriteLine();//结尾
        }//画地图
        public static void play(int a, ref int b, ref int c)
        {
            Console.Clear(); hditu();
            Console.WriteLine("玩家{0}按下任意键开始游戏", gamenames[a]);
            Console.ReadKey(false);
            Random r = new Random(); int namber = r.Next(1, 7);
            Console.WriteLine("玩家{0}摇到了{1}\n按下任意键继续", gamenames[a], namber); b += namber;
            if (b > 99) return;
            Console.ReadKey(false);
            if (b == c) { Console.WriteLine("玩家{0}踩到了玩家{1}，玩家{1}后退六格", gamenames[a], gamenames[1 - a]); c -= 6; if (c < 0) c = 0; }
            else if (ditu[b - namber] == 0)
            {
                Console.WriteLine("无事发生"); Console.ReadKey(false); return;
            }
            else if (ditu[b - namber] == 1)
            {
                Console.WriteLine("玩家{0}踩到了幸运方块\n输入1与玩家{1}交换位置\n输入2轰炸玩家{1}，使对方退六格子", gamenames[a], gamenames[1 - a]);
                while (true)
                {
                    string da = Console.ReadLine();
                    if (da == "1")
                    {
                        int f = c; c = b; b = c;
                        Console.WriteLine("交换完成");
                        Console.ReadKey(false); return;
                    }
                    else if (da == "2")
                    {
                        c -= 6; if (c < 0) c = 0;
                        Console.WriteLine("轰炸完成");
                        Console.ReadKey(false); return;
                    }
                    else Console.WriteLine("输入不合理\n请重新输入");
                }
            }//幸运方块
            else if (ditu[b - namber] == 2)
            {
                Console.WriteLine("玩家{0}踩到了地雷，退五格", gamenames[a]);
                b -= 6; Console.ReadKey(false); return;
            }//地雷
            else if (ditu[b - namber] == 3)
            {
                Console.WriteLine("玩家{0}踩到了暂停，暂停一回合", gamenames[a]); Console.ReadKey(false); play(a + 1, ref c, ref b);
            }//暂停
            else if (ditu[b - namber] == 3)
            {
                Console.WriteLine("玩家{0}踩到了隧道，前进六格", gamenames[a]);
                Console.ReadKey(false);
                b += 6; return;
            }//隧道
        }
    }
}
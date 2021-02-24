using System;

namespace 井字棋
{
    class Program
    {
        public static string[] GamesName = new string[2];//玩家id
        public static int[] Gamessj = new int[2];//玩家id
        public static string[] Gamesplay = new string[9];//棋盘数据
        public static bool pk = true;
        static void Main(string[] args)
        {
            int ing = 0;
            gametou(); gamesj();
            for (int i = 1+ing; i < Gamesplay.Length + 2+ing && pk; i++)
            {
                ditu(i % 2); Console.Clear();
                if (pk == false)
                {
                    Gamessj[i % 2] += 1;
                    ditu(i % 2); Console.WriteLine("玩家{0}获胜\n当前比分{1}\t{2}\n按下任意键继续，输入0交换先手位置",GamesName[i%2], Gamessj[i % 2], Gamessj[1-i % 2]);
                    string vs = Console.ReadLine();
                    if (vs == "0") ing = 1;
                    i = 1;pk = true; gamesj();Console.Clear();
                }
            }
            Console.WriteLine("ssss");
            Console.ReadLine();
        }
        public static void gametou()
        {
            Console.Clear();
            Console.WriteLine("操作方法输入对应的数字完成输入\n7|8|9\n-----\n4|5|6\n-----\n1|2|3\n输入玩家1的id");
            GamesName[1] = Console.ReadLine();
            if (GamesName[1] == "") { Console.WriteLine("输入不能为空\n按下任意键继续"); Console.ReadLine(); gametou(); }
            Console.WriteLine("输入玩家2的id");
            GamesName[0] = Console.ReadLine();
            if (GamesName[0] == " " || GamesName[0].Equals(GamesName[1]))
            {
                Console.WriteLine(GamesName[1] == "" ? "输入不能为空" : "不能和玩家1的id相同" + "按下任意键继续");
                Console.ReadLine(); gametou();
            }
        }//玩家id处理
        public static void gamesj()
        {
            for (int i = 0; i < Gamesplay.Length; i++)
            {
                Gamesplay[i] = "  ";
            }
        }//
        public static void ditu(int a)
        {
            Console.WriteLine("{0}|{1}|{2}\n--------\n{3}|{4}|{5}\n--------\n{6}|{7}|{8}"
            , Gamesplay[6], Gamesplay[7], Gamesplay[8], Gamesplay[3], Gamesplay[4], Gamesplay[5], Gamesplay[0]
            , Gamesplay[1], Gamesplay[2]);
            if (pk)
            {
                Console.WriteLine("轮到玩家{0}进行输入", GamesName[a]);
                try
                {
                    int b = int.Parse(Console.ReadLine());
                    while (b < 1 || b > 9)
                    {
                        Console.WriteLine("输入不能超出棋盘\n重新输入");
                        b = int.Parse(Console.ReadLine());
                    }
                    if (Gamesplay[b - 1].Equals("  ")) Gamesplay[b - 1] = a == 1 ? "√" : "×";
                    else { Console.WriteLine("输入重复\n输入任意键继续"); Console.ReadLine(); ditu(a); }
                    panduan(Gamesplay[b - 1]);
                }
                catch
                {
                    Console.WriteLine("输入不合理"); Console.ReadLine();
                }
            }
        }
        public static void panduan(string vs)
        {
            int vs1 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = i * 3; j < i * 3 + 3; j++)
                {
                    if (Gamesplay[j].Equals(vs)) vs1++;
                }
                if (vs1 == 3) { pk = false; break; }
                else vs1 = 0;
                for (int j = i; j < i + 7; j += 3)
                {
                    if (Gamesplay[j].Equals(vs)) vs1++;
                }
                if (vs1 == 3) { pk = false; break; }
                else vs1 = 0;
            }
            if (Gamesplay[0] == vs && Gamesplay[4] == vs && Gamesplay[8] == vs) pk = false;
            else if (Gamesplay[6] == vs && Gamesplay[4] == vs && Gamesplay[2] == vs) pk = false;
        }
    }
}
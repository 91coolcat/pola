using System;

namespace 井字棋
{
    class Program
    {
        public static string[] GamesName = new string[2];//玩家id
        public static int[] Gamessj = new int[2];//玩家胜负信息保存
        public static string[] Gamesplay = new string[9];//棋盘数据
        public static bool pk = true;//判断是否需要进行游玩的变量
        static void Main(string[] args)
        {
            int ing = 0;//管理开始前后顺序
            gametou(); gamesj();
            for (int i = 1 + ing; i < Gamesplay.Length + 1 + ing; i++)
            {
                ditu(i % 2);
                if (pk == false)//对局结束1
                {
                    Gamessj[i % 2] += 1;
                    ditu(i % 2); Console.WriteLine("玩家{0}获胜\n当前比分{1}\t{2}\n按下任意键继续，输入0交换先手位置", GamesName[i % 2], Gamessj[i % 2], Gamessj[1 - i % 2]);
                    string vs = Console.ReadLine();
                    if (vs == "0") ing = 1;
                    i = 1; pk = true; gamesj(); Console.Clear();
                }
                if (i == 9)
                {
                    pk = false; ditu(i % 2);
                    Console.WriteLine("平局\n按下任意键开始下一句");
                    Console.ReadLine(); i = 1; pk = true;
                }//使用false打断判断程序运行
            }
        }
        public static void gametou()//录入玩家id信息
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
        public static void gamesj()//初始化地图
        {
            for (int i = 0; i < Gamesplay.Length; i++)
            {
                Gamesplay[i] = "  ";
            }
        }//
        public static void ditu(int a)//地图显示与玩家交互
        {
            Console.Clear();
            Console.WriteLine("{0}|{1}|{2}\n--------\n{3}|{4}|{5}\n--------\n{6}|{7}|{8}"
            , Gamesplay[6], Gamesplay[7], Gamesplay[8], Gamesplay[3], Gamesplay[4], Gamesplay[5], Gamesplay[0]
            , Gamesplay[1], Gamesplay[2]);//地图显示
            if (pk)//交互系统，依靠全局变量判断是否进行
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
                    Console.WriteLine("输入不合理"); Console.ReadLine(); ditu(a);
                }
            }
        }
        public static void panduan(string vs)//判断胜负
        {
            int vs1 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = i * 3; j < i * 3 + 3; j++)
                {
                    if (Gamesplay[j].Equals(vs)) vs1++;
                }//竖行
                if (vs1 == 3) { pk = false; break; }//进行判断
                else vs1 = 0;//判断机制数据重置
                for (int j = i; j < i + 7; j += 3)
                {
                    if (Gamesplay[j].Equals(vs)) vs1++;
                }//横行
                if (vs1 == 3) { pk = false; break; }
                else vs1 = 0;
            }
            if (Gamesplay[0] == vs && Gamesplay[4] == vs && Gamesplay[8] == vs) pk = false;//斜向判断
            else if (Gamesplay[6] == vs && Gamesplay[4] == vs && Gamesplay[2] == vs) pk = false;
        }
    }
}
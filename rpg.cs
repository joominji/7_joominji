using System.Diagnostics.Contracts;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Rpg
{
    internal class Program
    {
        private static Character player;
        private static Items item1;
        private static Items item2;
        private static Items item3;
        private static Items item4;
        private static Items item5;
        private static Items item6;
      
        static void Main(string[] args)
        {
           
            ItemSetting();
            GameDataSetting();
            DisplayGameIntro();
            
            Console.Clear();

        }

        static void GameDataSetting()
        {
           
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);
        }
        static void ItemSetting()
        { 
            item1 = new Items("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 300, 3, 0, 0);
            item2 = new Items("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 500, 0, 5, 50);
            item3 = new Items("오래된 목걸이", "주인도 모를만큼 오래된 목걸이입니다.", 200, 0, 2, 0);
            item4 = new Items("오래된 반지", "주인도 모를만큼 오래된 반지입니다.", 200, 2, 0, 0);
            item5 = new Items("오래된 귀걸이", "주인도 모를만큼 오래된 귀걸이입니다.", 200, 0, 0, 30);
            item6 = new Items("체력 물약", "체력을 회복시켜 주는 물약입니다.", 100, 0, 0, +30);
        }

        static void DisplayGameIntro()
        {
           
            Console.WriteLine("┌────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│       스파르타 마을에 오신 여러분 환영합니다.                  │");
            Console.WriteLine("│       이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.     │");
            Console.WriteLine("│                                                                │");
            Console.WriteLine("│        1. 상태보기                                             │");
            Console.WriteLine("│        2. 인벤토리                                             │");
            Console.WriteLine("│        3. 상점 가기                                            │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────┘");
            Console.WriteLine("  원하시는 행동을 입력해주세요.  ");
            Console.WriteLine("  >>  ");
            int input = CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;


                case 2:
                    DisplayInventory();
                    break;

                case 3:
                    DisplayStore();
                    break;
            }

        }

        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }


                Console.WriteLine("잘못된 입력입니다.");

            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();
           
            Console.WriteLine("┌────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│       상태보기                                                 │");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("└────────────────────────────────────────────────────────────────┘");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0
                :
                    DisplayGameIntro();
                    break;
            }
        }

        static void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│  인벤토리                                                      │");
            Console.WriteLine("│                                                                │");
            Console.WriteLine("│보유 중인 아이템을 관리할 수 있습니다.                          │");
            Console.WriteLine();
            Console.WriteLine($"│1.{item1.Name} : {item1. Atk} : {item1.Impo} ");
            Console.WriteLine($"│2.{item2.Name} : {item2.Atk} : {item2.Impo} ");
            Console.WriteLine("│                                                                │");
            Console.WriteLine("│1. 장착 관리                                                    │");
            Console.WriteLine("│0. 나가기                                                       │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────┘");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0
                :
                    DisplayGameIntro();
                    break;

                case 1 :
                    Console.WriteLine("장착 또는 해제할 아이템을 선택해 주세요");
                    break;
            }

           
           
         
        }

        static void DisplayStore()
        {
           
            Console.WriteLine("┌────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│   상점:                                                        │ ");
            Console.WriteLine("│                                                                │");
            Console.WriteLine("[아이템 목록]  가격          능력치       설명");
            Console.WriteLine("│                                                                │");
            Console.WriteLine($"{item3.Name} , {item3.Price} , 방어력 : {item3.Def}, {item3.Impo}");
            Console.WriteLine($"{item4.Name} , {item4.Price} ,공격력 :{item4.Atk}, {item4.Impo}");
            Console.WriteLine($"{item5.Name} , {item5.Price} ,체력 : {item5.Hp} , {item5.Impo}");
            Console.WriteLine($"{item6.Name} , {item6.Price} , 회복량 : {item6.Hp} ,  {item6.Impo}");
            Console.WriteLine("│                                                                │");
            Console.WriteLine("│                                                                │");
            Console.WriteLine("│ 0. 나가기                                                      │ "); 
            Console.WriteLine("└────────────────────────────────────────────────────────────────┘");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;

            }
        }

        public class Character
        {
            public string Name { get; }
            public string Job { get; }
            public int Level { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }
            public int Gold { get; }

            public Character(string name, string job, int level, int atk, int def, int hp, int gold)
            {
                Name = name;
                Job = job;
                Level = level;
                Atk = atk;
                Def = def;
                Hp = hp;
                Gold = gold;
            }
        }

        public class Items
        {
            public string Name { get; }
            public string Impo { get; }  
            public int Price { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }

            

            public Items(string name, string impo,int price, int atk, int def, int hp)
            {
                Name = name;
                Impo = impo; 
                Price = price;
                Atk = atk;
                Def = def;
                Hp = hp;
            }
        }
        static void SwordDraw()
        {
            Console.WriteLine(" │＼");
            Console.WriteLine(" │ │");
            Console.WriteLine(" │ │");
            Console.WriteLine(" │ │");
            Console.WriteLine("■■■");
            Console.WriteLine(" │ │");
            Console.WriteLine("  --");
        }

        static void ArmorDraw()
        {
            Console.WriteLine("  □■■  ■■□");
            Console.WriteLine("□□■■■■■□□");
            Console.WriteLine("□□■■■■■□□");
            Console.WriteLine("    ■■■■■");
            Console.WriteLine("    ■■■■■");
            Console.WriteLine("    ■■■■■");

         static void NecklessDraw()
            {
                Console.WriteLine("〔 〕");
                Console.WriteLine(" ☆");
            }


        }
    }
}

   



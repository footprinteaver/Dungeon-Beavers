using System;
using System.Collections.Generic;

internal class Program
{
    public class Character
    {
        public string Name { get; }

        public string Job { get; }

        public int Level { get; }

        public int Atk { get; }

        public int Def { get; }

        public int Hp { get; }

        public int Gold { get; }

        public Character (string name,string job, int level, int atk, int def, int hp, int gold )
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

    public class Item
    {
       
        public string Name { get; }

        public string Description { get; }

        public int Type { get;  }

        public int Atk { get; }       

        public int Def { get; }

        public int Price { get; }

        public bool Equipped { get; set; }

        public static int ItemCnt = 0;


        public Item(  string name, int type, int atk,int def, int price , string description)
        {
            
            Name = name;
            Type = type;
            Atk = atk;
            Def = def;
            Price = price; 
            Description = description;
            Equipped = false;
        }
    }
    static int gold = 800;
    static List<Item> inventory = new List<Item>();
    static List<Item> shopItems = new List<Item>
    {
        new Item( "수련자 갑옷", 0, 0, 5, 1000, "수련에 도움을 주는 갑옷입니다."),
        new Item( "무쇠갑옷", 0 ,0, 9, 1500, "무쇠로 만들어져 튼튼한 갑옷입니다."),
        new Item( "스파르타의 갑옷", 1, 0 , 15, 3500, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."),
        new Item( "낡은 검", 1, 2, 0, 600, "쉽게 볼 수 있는 낡은 검입니다."),
        new Item("청동 도끼", 1, 5, 0, 1500, "어디선가 사용됐던거 같은 도끼입니다."),
        new Item("스파르타의 창", 1, 7, 0, 2000, "스파르타의 전사들이 사용했다는 전설의 창입니다.")
    };

       static Character player;
       static Item[] items;
    

    
  
   
    static void Main(string[]args)
    {
        PrintStartLogo();
        GameDataSetting();
        Console.WriteLine("마을에 오신 여러분을 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전에 활동을 할 수 있습니다.");

        while (true)
        {
            Console.WriteLine("\n1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
      
                    break;
                case "2":
                    DisplayInventory();
                    break;
                case "3":
                    DisplayShop();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 1부터 3 사이의 숫자를 입력해주세요.");
                    break;
            }
        }
    }
    private static void GameDataSetting()
    {
        player = new Character("chad", "전사", 1, 10, 5, 100, 1500);
        items = new Item[10];


    }
    static void Additem(Item item)
    {
        if (Item.ItemCnt == 10) return;
        items[Item.ItemCnt] = item; //0ro > 0번인덱스 / 1개> 1번인덱스
        Item.ItemCnt++;
    }

    private static void PrintStartLogo()
    {
        Console.WriteLine("  ###   ####     #    ####  ######    #           ####   ## ##  #  ##   ###   #####   ###   #  ## ");
        Console.WriteLine(" ## ##  ## ##   ###   ## ##   ##     ###          ## ##  ## ##  ## ##  ## ##  ##     ## ##  ## ## ");
        Console.WriteLine(" ##     ## ##  ## ##  ## ##   ##    ## ##         ## ##  ## ##  #####  ##     ##     ## ##  ##### ");
        Console.WriteLine("  ###   ####   ## ##  ####    ##    ## ##         ## ##  ## ##  #####  #####  ####   ## ##  #####");
        Console.WriteLine("    ##  ##     #####  ###     ##    #####         ## ##  ## ##  #####  ## ##  ##     ## ##  ##### ");
        Console.WriteLine(" ## ##  ##     ## ##  ####    ##    ## ##         ## ##  ## ##  ## ##  ## ##  ##     ## ##  ## ## ");
        Console.WriteLine("  ###   ##     ## ##  ## ##   ##    ## ##         ####    ###   ##  #   ####  #####   ###   ##  #  ");
        Console.WriteLine("===================================================================================================");
        Console.WriteLine("                                 PRESS ANYKEY TO START                                               ");
        Console.WriteLine("======================================================================================================");
    }

    static void DisplayInventory()
    {
        Console.WriteLine("\n[인벤토리]");
        Console.WriteLine("\n[아이템 목록]");

        for (int i = 0; i < inventory.Count; i++)
        {
            string equippedMark = inventory[i].Equipped ? "[E]" : "";
            Console.WriteLine($"{i + 1}. {equippedMark}{inventory[i].Name} | {inventory[i].Description}");
        }

        Console.WriteLine("\n1. 장착 관리");
        Console.WriteLine("0. 나가기");

        string input = Console.ReadLine();

        if (input == "1")
        {
            ManageEquipments();
        }
        else if (input == "0")
        {
            // 나가기
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
        }
    }

    static void ManageEquipments()
    {
        Console.WriteLine("\n[인벤토리 - 장착 관리]");
        Console.WriteLine("\n[아이템 목록]");

        for (int i = 0; i < inventory.Count; i++)
        {
            string equippedMark = inventory[i].Equipped ? "[E]" : "";
            Console.WriteLine($"{i + 1}. {equippedMark}{inventory[i].Name} | {inventory[i].Description}");
        }

        Console.WriteLine("\n0. 나가기");

        string input = Console.ReadLine();

        if (int.TryParse(input, out int selectedItemIndex) && selectedItemIndex >= 1 && selectedItemIndex <= inventory.Count)
        {
            Item selected = inventory[selectedItemIndex - 1];
            if (selected.Equipped)
            {
                UnequipItem(selected);
            }
            else
            {
                EquipItem(selected);
            }
        }
        else if (input == "0")
        {
            // 나가기
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
        }
    }

    static void EquipItem(Item item)
    {
        Console.WriteLine($"[{item.Name}]을(를) 장착했습니다.");
        item.Equipped = true;
        UpdateStatus();
    }

    static void UnequipItem(Item item)
    {
        Console.WriteLine($"[{item.Name}]을(를) 장착 해제했습니다.");
        item.Equipped = false;
        UpdateStatus();
    }

    static void UpdateStatus()
    {
        // 캐릭터 상태 업데이트 로직 추가
        Console.WriteLine("[상태 보기]");
        Console.WriteLine("캐릭터의 정보가 업데이트되었습니다.");
    }

    static void DisplayShop()
    {
        Console.WriteLine("\n[상점]");
        Console.WriteLine($"\n[보유 골드]");
        Console.WriteLine($"{gold} G");
        Console.WriteLine("\n[아이템 목록]");

        for (int i = 0; i < shopItems.Count; i++)
        {
            string purchaseStatus = shopItems[i].Purchased ? "구매완료" : $"{shopItems[i].Price} G";
            Console.WriteLine($"{i + 1}. {shopItems[i].Name} | {shopItems[i].Description} | {purchaseStatus}");
        }

        Console.WriteLine("\n1. 아이템 구매");
        Console.WriteLine("0. 나가기");

        string input = Console.ReadLine();

        if (input == "1")
        {
            BuyItem();
        }
        else if (input == "0")
        {
            // 나가기
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
        }
    }

    static void BuyItem()
    {
        Console.WriteLine("\n[상점 - 아이템 구매]");
        Console.WriteLine("\n[아이템 목록]");

        for (int i = 0; i < shopItems.Count; i++)
        {
            string purchaseStatus = shopItems[i].Purchased ? "구매완료" : $"{shopItems[i].Price} G";
            Console.WriteLine($"{i + 1}. {shopItems[i].Name} | {shopItems[i].Description} | {purchaseStatus}");
        }

        Console.WriteLine("\n0. 나가기");

        string input = Console.ReadLine();

        if (int.TryParse(input, out int selectedItemIndex) && selectedItemIndex >= 1 && selectedItemIndex <= shopItems.Count)
        {
            Item selected = shopItems[selectedItemIndex - 1];
            if (selected.Purchased)
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            else if (gold >= selected.Price)
            {
                PurchaseItem(selected);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
            }
        }
        else if (input == "0")
        {
            // 나가기
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
        }
    }

    static void PurchaseItem(Item item)
    {
        Console.WriteLine($"[{item.Name}]을(를) 구매했습니다.");
        gold -= item.Price;
        inventory.Add(item);
        item.Purchased = true;
        UpdateStatus();
    }
}




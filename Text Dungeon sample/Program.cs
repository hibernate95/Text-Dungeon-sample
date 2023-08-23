using System;

class Program
{
    private static Character player;
    private static Item[] inventory;
    private static List<Item> equippedItems = new List<Item>();

    static void Main(string[] args)
    {
        GameDataSetting();
        DisplayGameIntro();


    }
    static void EquipItem()
    {
        Console.Clear();
        Console.WriteLine("장착할 아이템을 선택하세요:");

        for (int i = 0; i < inventory.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i].Name}");
        }
        int input = CheckValidInput(1, inventory.Length);
        Item selectedItem = inventory[input - 1];

        player.UpdateAtk(player.Atk + selectedItem.AtkBonus);
        player.UpdateDef(player.Def + selectedItem.DefBonus);

        Console.WriteLine($"{selectedItem.Name}을(를) 장착했습니다!");
        Console.WriteLine($"공격력이 {selectedItem.AtkBonus} 증가하였습니다.");
        Console.WriteLine($"방어력이 {selectedItem.DefBonus} 증가하였습니다.");
        Console.WriteLine("\n");

        equippedItems.Add(selectedItem); // 장착한 아이템 리스트에 추가
        RemoveItemFromInventory(selectedItem);

        Console.WriteLine("0. 나가기");
        Console.WriteLine("1. 인벤토리");

        input = CheckValidInput(0, 1);
        if (input == 0)
        {
            DisplayGameIntro();
        }
        else if (input == 1)
        {
            DisplayInventory();
        }

        static void RemoveItemFromInventory(Item item)
        {
            List<Item> updatedInventory = new List<Item>(inventory);
            updatedInventory.Remove(item);
            inventory = updatedInventory.ToArray();
        }


    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅
        player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

        // 아이템 정보 세팅

        Item item1 = new Item("지팡이", "주문을 시전할 수 있는 지팡이", 100, 10, 0, 0);
        Item item2 = new Item("철 갑옷", "튼튼한 갑옷", 200, 0, 20, 0);
        Item item3 = new Item("치료 물약", "체력을 회복시켜주는 물약", 50, 0, 0, 50);

        inventory = new Item[] { item1,item2,item3 };
    }

    static void DisplayGameIntro()
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(1, 2);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;
            case 2:
                DisplayInventory();
                break;
        }
    }

    static void DisplayMyInfo()
    {
        Console.Clear();

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보를 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name}({player.Job})");
        Console.WriteLine($"공격력: {player.Atk}");
        Console.WriteLine($"방어력: {player.Def}");
        Console.WriteLine($"체력: {player.Hp}");
        Console.WriteLine($"Gold: {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");

        int input = CheckValidInput(0, 0);
        if (input == 0)
        {
            DisplayGameIntro();

        }
    }

    static void DisplayInventory()
    {
        Console.Clear();

        Console.WriteLine("인벤토리");
        Console.WriteLine("보유한 아이템을 표시합니다.");
        Console.WriteLine();
        foreach (Item item in inventory)
        {
            Console.WriteLine("아이템 이름: " + item.Name);
            Console.WriteLine("아이템 설명: " + item.Description);
            Console.WriteLine("아이템 가격: " + item.Price);
            Console.WriteLine("공격력 증가: " + item.AtkBonus);
            Console.WriteLine("방어력 증가: " + item.DefBonus);
            Console.WriteLine("체력 회복: " + item.HpRegen);
            Console.WriteLine();
        }
        Console.WriteLine("0. 나가기");
        Console.WriteLine("1. 장착하기");

        int input = CheckValidInput(0, 1);
        if (input == 0)
        {
            DisplayGameIntro();
        }
        else if (input == 1)
        {
            EquipItem();
        }
    }

   public class Item
{
    public string Name { get; }
    public string Description { get; }
    public int Price { get; }
    public int AtkBonus { get; }
    public int DefBonus { get; }
    public int HpRegen { get; }

    public Item(string name, string description, int price, int atkBonus, int defBonus, int hpRegen)
    {
        Name = name;
        Description = description;
        Price = price;
        AtkBonus = atkBonus;
        DefBonus = defBonus;
        HpRegen = hpRegen;
    }
}


    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out int ret);
            if (parseSuccess && ret >= min && ret <= max)
            {
                return ret;
            }


            Console.WriteLine("잘못된 입력입니다.");
        }
    }
}

public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; private set; }
    public int Def { get; private set; }
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
    public void UpdateAtk(int newAtk)
    {
        Atk = newAtk;
    }

    public void UpdateDef(int newDef)
    {
        Def = newDef;
    }
}
public class Item
{
    public string Name { get; }
    public string Description { get; }
    public int Price { get; }
    public int AtkBonus { get; }
    public int DefBonus { get; }
    public int HpRegen { get; }

    public Item(string name, string description, int price, int atkBonus, int defBonus, int hpRegen)
    {
        Name = name;
        Description = description;
        Price = price;
        AtkBonus = atkBonus;
        DefBonus = defBonus;
        HpRegen = hpRegen;
    }
}

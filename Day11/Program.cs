using Day11;
using System.Numerics;

string[] Input = File.ReadAllLines("Input.txt");
int MaxMonkeys = (Input.Length + 1) / 7;
Monkey[] Monkeys = new Monkey[MaxMonkeys];
for (int monkeyCount = 0; monkeyCount < MaxMonkeys; monkeyCount++)
{
    Monkeys[monkeyCount] = new Monkey();
    Monkeys[monkeyCount].Number= (UInt16)monkeyCount;
}
for (int monkeyCount = 0; monkeyCount < MaxMonkeys; monkeyCount++)
{

   // Monkeys[monkeyCount] = new Monkey();
    string[] items = Input[monkeyCount * 7 + 1].Split(':')[1].Split(',');
    foreach (string item in items)
    {
        Monkeys[monkeyCount].Items.Add(Convert.ToUInt64(item.Substring(1, 2)));
    }
    Monkeys[monkeyCount].Operation = Input[monkeyCount * 7 + 2][23];
    if (Input[monkeyCount * 7 + 2].Length == 28)
    {
        Monkeys[monkeyCount].OperandIsItem = true;
    }
    else if (Input[monkeyCount * 7 + 2].Length == 27)
    {
        Monkeys[monkeyCount].Operand = Convert.ToInt32(Input[monkeyCount * 7 + 2].Substring(25, 2));
    }
    else
    {
        Monkeys[monkeyCount].Operand = Convert.ToInt32(Input[monkeyCount * 7 + 2].Substring(25, 1));
    }
    Monkeys[monkeyCount].Test = Convert.ToInt32(Input[monkeyCount * 7 + 3].Substring(21,
        Input[monkeyCount * 7 + 3].Length == 23 ? 2 : 1));

    Monkeys[monkeyCount].TrueMonkey = Monkeys[Convert.ToInt32(Input[monkeyCount * 7 + 4][29].ToString())];
    Monkeys[monkeyCount].FalseMonkey = Monkeys[Convert.ToInt32(Input[monkeyCount * 7 + 5][30].ToString())];
}

for (int RoundCount = 0; RoundCount < 10000; RoundCount++)
{
    bool report = false;
    if ((RoundCount + 1) % 100 == 0)
    {
        Console.WriteLine("Round " + (RoundCount + 1));
        report = true;
    }
    foreach (Monkey monkey in Monkeys)
    {
        monkey.Turn(report);
    }
}

List<UInt64> examines= new List<UInt64>();
foreach (Monkey monkey in Monkeys)
{
    examines.Add(monkey.ExamineCount);
}
examines.Sort();
Console.WriteLine(examines[examines.Count- 1] * examines[examines.Count - 2]);

public class Monkey
{
    private List<UInt128> items = new List<UInt128>();
    private int test;
    private Monkey trueMonkey;
    private Monkey falseMonkey;
    private char operation;
    private int operand;
    private bool operandIsItem;
    private UInt16 examineCount = 0;
    private UInt16 number;

    public List<UInt128> Items { get => items; set => items = value; }
    public int Test { get => test; set => test = value; }
    public Monkey TrueMonkey { get => trueMonkey; set => trueMonkey = value; }
    public Monkey FalseMonkey { get => falseMonkey; set => falseMonkey = value; }
    public char Operation { get => operation; set => operation = value; }
    public int Operand { get => operand; set => operand = value; }
    public bool OperandIsItem { get => operandIsItem; set => operandIsItem = value; }
    public UInt16 ExamineCount { get => examineCount; set => examineCount = value; }
    public UInt16 Number { get => number; set => number = value; }

    public void Turn(bool report)
    {
        if (report)
        {
            Console.Write("Monkey has " + Items.Count + " Items ");
        }
        while (items.Count > 0)
        {

            ExamineCount++;
            UInt128 currentItem = items[0];
            items.RemoveAt(0);

            if (Operation == '*')
            {
                if (operandIsItem)
                {
                    currentItem = currentItem * currentItem;
                }
                else
                {
                    currentItem = currentItem * (UInt64)operand;
                }
            }
            else
            {
                if (operandIsItem)
                {
                    currentItem = currentItem + currentItem;
                }
                else
                {
                    currentItem = currentItem + (UInt64)operand;
                }
            }
           // currentItem = (UInt64)Math.Floor(currentItem / 3.0);

            if (currentItem % (UInt64)test == 0)
            {
                TrueMonkey.items.Add(currentItem);
            }
            else
            {
                FalseMonkey.items.Add(currentItem);
            }
        }
        if (report)
        {
            Console.WriteLine("examination count now " + ExamineCount);
        }
    }
}
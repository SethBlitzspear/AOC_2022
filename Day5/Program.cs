// See https://aka.ms/new-console-template for more information
string[] Input = File.ReadAllLines("Input.txt");
Stack<char>[] Stacks = null;
bool Star2 = true;
for (int lineCount = 0; lineCount < Input.Length; lineCount++)
{
    if(Input[lineCount] == "")
    {
        //do nothing
    }
    else if (Input[lineCount][1] == '1')
    {
        int stackMax = Convert.ToInt32(Convert.ToString(Input[lineCount][Input[lineCount].Length - 2]));
        Stacks = new Stack<char>[stackMax];
        for (int stackCount = 0; stackCount < stackMax; stackCount++)
        {
            Stacks[stackCount] = new Stack<char>();
        }
        for (int lineCountBack = lineCount; lineCountBack >= 0; lineCountBack--)
        {
            for (int stackCount = 0; stackCount < stackMax; stackCount++)
            {
                if (Input[lineCountBack][1 + stackCount * 4] != ' ')
                {
                    Stacks[stackCount].Push(Input[lineCountBack][1 + stackCount * 4]);
                }
            }
        }
    }
    else if (Input[lineCount][0] == 'm')
    {
        int moveNum = Convert.ToInt32(Input[lineCount].Split(" from ")[0].Split(' ')[1]);
        int fromStack = Convert.ToInt32(Input[lineCount].Split(" from ")[1].Split(" to ")[0]);
        int toStack = Convert.ToInt32(Input[lineCount].Split(" from ")[1].Split(" to ")[1]);
        Stack<char> holder = new Stack<char>();
        for (int moveCount = 0; moveCount < moveNum; moveCount++)
        {
            if(Star2)
            {
                holder.Push(Stacks[fromStack - 1].Pop());

            }
            else
            {
                Stacks[toStack - 1].Push(Stacks[fromStack - 1].Pop());
            }
        }
        if(Star2)
        {
            for (int moveCount = 0; moveCount < moveNum; moveCount++)
            {
                Stacks[toStack - 1].Push(holder.Pop());
            }
        }
    }
}
string output = "";
for (int stackCount = 0; stackCount < Stacks.Length; stackCount++)
{
    output += Stacks[stackCount].Peek();    
}
Console.WriteLine(output);

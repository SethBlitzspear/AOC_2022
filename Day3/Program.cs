// See https://aka.ms/new-console-template for more information

string[] Input = File.ReadAllLines("Input.txt");
int PriorityCount = 0;
foreach (string rucksack in Input)
{
    int itemCount = rucksack.Length;
    string sack1 = rucksack.Substring(0, itemCount / 2);
    string sack2 = rucksack.Substring(itemCount / 2, itemCount / 2);
    bool found = false;
    foreach (char item in sack1)
    {
        
        if (!found)
        {
            if (sack2.Contains(item))
            {
                found = true;
                int itemValue = (int)item;
                if (itemValue >= 97)
                {
                    PriorityCount += (itemValue - 96);
                }
                else
                {
                    PriorityCount += (itemValue - 38);
                }
            }
        }
    }
}
Console.WriteLine(PriorityCount);
PriorityCount = 0;
for (int sackCount = 0; sackCount < Input.Length; sackCount+=3)
{
    bool found = false;
    foreach (char item in Input[sackCount])
    {
        if(!found)
        {
            if (Input[sackCount +1].Contains(item) && Input[sackCount +2].Contains(item))
            {
                found = true;
                int itemValue = (int)item;
                if (itemValue >= 97)
                {
                    PriorityCount += (itemValue - 96);
                }
                else
                {
                    PriorityCount += (itemValue - 38);
                }
            }
        }
    }
}
Console.WriteLine(PriorityCount);